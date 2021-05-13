/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Gravity.Extensions
{
    /// <summary>
    /// Extensions for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        #region *** Encryption ***
        /// <summary>
        /// Encrypts a <see cref="string"/> using the provided encryption key.
        /// </summary>
        /// <param name="clearText"><see cref="string"/> to encrypt.</param>
        /// <param name="key">Encryption key to use for encryption.</param>
        /// <returns>Encrypted <see cref="string"/>.</returns>
        public static string Encrypt(this string clearText, string key)
        {
            // setup
            var salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

            // encrypt
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            using (var pdb = new Rfc2898DeriveBytes(password: key, salt))
            {
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using var memoryStream = new MemoryStream();
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(clearBytes, 0, clearBytes.Length);
                }
                clearText = Convert.ToBase64String(memoryStream.ToArray());
            }
            return clearText;
        }

        /// <summary>
        /// Decrypts a <see cref="string"/> using the provided encryption key.
        /// </summary>
        /// <param name="cipherText">Encrypted <see cref="string"/>.</param>
        /// <param name="key">Encryption key to use for decryption.</param>
        /// <returns>Decrypted <see cref="string"/>.</returns>
        public static string Decrypt(this string cipherText, string key)
        {
            // setup
            var salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

            // decrypt
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var encryptor = Aes.Create())
            using (var pdb = new Rfc2898DeriveBytes(key, salt))
            {
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using var memoryStream = new MemoryStream();
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                }
                cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
            }
            return cipherText;
        }
        #endregion

        #region *** Validation ***
        /// <summary>
        /// Return a value indicates if this string is a valid, able to compile JSON.
        /// </summary>
        /// <param name="str">This string instance on which to perform validation.</param>
        /// <returns>True if this string is a valid JSON, False if not.</returns>
        public static bool IsJson(this string str)
        {
            // process string
            str = str.Trim();

            // setup conditions
            var isObj = str.StartsWith("{") && str.EndsWith("}");
            var isArr = str.StartsWith("[") && str.EndsWith("]");

            // parse
            if (isObj || isArr)
            {
                try
                {
                    JsonDocument.Parse(str);
                    return true;
                }
                catch (Exception e) when (e != null)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Return a value indicates if this string is a valid, able to compile XML.
        /// </summary>
        /// <param name="xml">This string instance on which to perform validation.</param>
        /// <returns>True if this string is a valid XML, False if not.</returns>
        public static bool IsXml(this string xml)
        {
            try
            {
                return XDocument.Parse(xml) != null;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicates if this <see cref="string"/> is a valid <see cref="XPathException"/>.
        /// </summary>
        /// <param name="str"><see cref="string"/> to evaluate.</param>
        /// <param name="isRelative">Set to <see cref="true"/> to assert if the <see cref="XPathExpression"/> is relative.</param>
        /// <returns><see cref="true"/> if this a valid <see cref="XPathException"/>, <see cref="false"/> if not.</returns>
        public static bool IsXpath(this string str, bool isRelative)
        {
            try
            {
                // setup
                var isSyntax = str.StartsWith("./") || str.StartsWith("(./");

                // compile
                XPathExpression.Compile(str);

                // result
                return isRelative ? isSyntax : !isSyntax;
            }
            catch (Exception e) when (e != null)
            {
                return false;
            }
        }
        #endregion

        #region *** Operators  ***
        /// <summary>
        /// Evaluates if source <see cref="string"/> meets a logical condition against a target <see cref="string"/>.
        /// </summary>
        /// <param name="source">Source <see cref="string"/>.</param>
        /// <param name="operation">Operation to execute. Check 'About Comparison Operators Powershell' for more information.</param>
        /// <param name="target">Target <see cref="string"/>.</param>
        /// <returns>True if condition met. False if not.</returns>
        public static bool Evaluate(this string source, string operation, string target) => (operation.ToUpper()) switch
        {
            "NE" => !source.Equals(target, StringComparison.Ordinal),
            "EQ" => source.Equals(target, StringComparison.Ordinal),
            "MATCH" => Regex.IsMatch(source, target),
            "NOTMATCH" => !Regex.IsMatch(source, target),
            "LT" => Evaluate(source, target, true),
            "GT" => Evaluate(source, target, false),
            "LE" => Evaluate(source, target, true, true),
            "GE" => Evaluate(source, target, false, true),
            _ => false,
        };

        private static bool Evaluate(string source, string target, bool isLowerThan, bool isEqual = false)
        {
            _ = int.TryParse(source, out int sourceOut);
            _ = int.TryParse(target, out int targetOut);

            if (!isEqual)
            {
                return isLowerThan ? sourceOut < targetOut : sourceOut > targetOut;
            }
            return isLowerThan ? sourceOut <= targetOut : sourceOut >= targetOut;
        }
        #endregion

        #region *** Parsing    ***
        /// <summary>
        /// Converts a PascalCase <see cref="string"/> to kebab-case <see cref="string"/>.
        /// </summary>
        /// <param name="str"><see cref="string"/> to convert.</param>
        /// <returns>kebab-case representation of the <see cref="string"/>.</returns>
        public static string PascalToKebabCase(this string str) => ToCase(str, "-$1");

        /// <summary>
        /// Converts a PascalCase <see cref="string"/> to Space Case <see cref="string"/>.
        /// </summary>
        /// <param name="str"><see cref="string"/> to convert.</param>
        /// <returns>Space Case representation of the <see cref="string"/>.</returns>
        public static string PascalToSpaceCase(this string str) => ToCase(str, " $1");

        /// <summary>
        /// Converts a PascalCase <see cref="string"/> to camelCase <see cref="string"/>.
        /// </summary>
        /// <param name="str"><see cref="string"/> to convert.</param>
        /// <returns>camelCase representation of the <see cref="string"/>.</returns>
        public static string PascalToCamelCase(this string str)
        {
            // exit conditions
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            if (str.Length < 2)
            {
                return str.ToLower();
            }

            // split the string into words
            var words = str.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);

            // combine the words
            var result = new StringBuilder(words[0].ToLower());
            for (int i = 1; i < words.Length; i++)
            {
                result.Append(words[i].Substring(0, 1).ToUpper()).Append(words[i].Substring(1));
            }
            return $"{result}";
        }

        /// <summary>
        /// Converts a string to <see cref="int"/>, or return 0 if not possible.
        /// </summary>
        /// <param name="str"><see cref="string"/> to convert.</param>
        /// <returns><see cref="int"/> representation of the <see cref="string"/>.</returns>
        public static int ToInt(this string str)
        {
            _ = int.TryParse(str, out int sOut);
            return sOut;
        }

        /// <summary>
        /// Converts a <see cref="string"/> to Base64.
        /// </summary>
        /// <param name="str"><see cref="string"/> to convert.</param>
        /// <param name="omitPaddaing">Replace all '=' chars in the string (defaults to true).</param>
        /// <returns>Base64 representation of the <see cref="string"/>.</returns>
        public static string ToBase64(this string str, bool omitPaddaing = true)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            // convert
            var encoded = Convert.ToBase64String(bytes);

            // results
            return omitPaddaing ? encoded.Replace("=", string.Empty) : encoded;
        }

        /// <summary>
        /// Converts a <see cref="string"/> from Base64.
        /// </summary>
        /// <param name="str"><see cref="string"/> to convert.</param>
        /// <returns><see cref="string"/> instance.</returns>
        public static string FromBase64(this string str)
        {
            var bytes = Convert.FromBase64String(str);

            // convert
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Attempts to create a <see cref="TimeSpan"/> object from the given string. If the string is
        /// an integer, it will be considered as milliseconds.
        /// </summary>
        /// <param name="str">The <see cref="string"/> from which to parse a new <see cref="TimeSpan"/>.</param>
        /// <returns>New <see cref="TimeSpan"/> instance.</returns>
        public static TimeSpan ToTimeSpan(this string str)
        {
            var isNumber = double.TryParse(str, out double numberOut);
            var isTimeSp = TimeSpan.TryParse(str, out TimeSpan timespanOut);

            // number handling
            if (isNumber)
            {
                return TimeSpan.FromMilliseconds(numberOut);
            }

            // timespan handling
            if (isTimeSp)
            {
                return timespanOut;
            }

            // default timespan
            return default;
        }

        private static string ToCase(string s, string seprator)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            const string PATTERN = "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])";
            return Regex.Replace(s, PATTERN, seprator, RegexOptions.Compiled).Trim().ToLower();
        }
        #endregion

        /// <summary>
        /// Splits a given string by new lines and cleans up any empty lines and trim the substrings.
        /// </summary>
        /// <param name="str"><see cref="string"/> to split.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in separator.</returns>
        public static IEnumerable<string> SplitByLines(this string str)
        {
            return Regex
                .Split(str, @"((\r)+)?(\n)+((\r)+)?")
                .Select(i => i.Trim())
                .Where(i => !string.IsNullOrEmpty(i));
        }

        /// <summary>
        /// Removes all lines from a given string.
        /// </summary>
        /// <param name="str"><see cref="string"/> to split.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in separator.</returns>
        public static string RemoveLines(this string str)
        {
            return Regex.Replace(input: str, pattern: @"((\r)+)?(\n)+((\r)+)?", replacement: " ");
        }

        /// <summary>
        /// Gets the size in bytes of a <see cref="string"/>.
        /// </summary>
        /// <param name="str"><see cref="string"/> to get size from.</param>
        /// <returns>Number of bytes.</returns>
        public static long GetSize(this string str) => (str.Length * sizeof(char)) + sizeof(long);

        /// <summary>
        /// Replicates string for each <see cref="DataRow"/> and replace all {{column-name}} with
        /// the actual data from the <see cref="DataRow"/>.
        /// </summary>
        /// <param name="str">This <see cref="string"/> instance to populate into.</param>
        /// <param name="dataTable"><see cref="DataTable"/> to populate from.</param>
        /// <returns>A collection of populated <see cref="string"/>, string for each <see cref="DataRow"/>.</returns>
        public static IEnumerable<(string s, DataRow d)> FromTable(this string str, DataTable dataTable)
        {
            // collect columns
            var columns = Regex.Matches(str, "(?<={{)[^$].*?(?=}})").Cast<Match>();

            // iterate rows and collect results
            var strings = new List<(string s, DataRow d)>();
            foreach (DataRow row in dataTable.Rows)
            {
                var innerStr = str;
                foreach (Match column in columns)
                {
                    innerStr = innerStr.Replace("{{@" + column.Value + "}}", row[column.Value].ToString());
                }
                strings.Add((s: innerStr, d: row));
            }
            return strings;
        }
    }
}