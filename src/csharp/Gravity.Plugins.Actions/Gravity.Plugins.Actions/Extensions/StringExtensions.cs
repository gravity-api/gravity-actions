/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * on-line resources
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.XPath;

namespace Gravity.Plugins.Actions.Extensions
{
    public static class StringExtensions
    {
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
            if (isObj && isArr)
            {
                try
                {
                    JToken.Parse(str);
                    return true;
                }
                catch (Exception e) when (e is JsonReaderException)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Attempts to create a <see cref="TimeSpan"/> object from the given string. If the string is
        /// an integer, it will be considered as milliseconds.
        /// </summary>
        /// <param name="str">The <see cref="string"/> from which to parse a new <see cref="TimeSpan"/>.</param>
        /// <returns>New <see cref="TimeSpan"/> instance.</returns>
        public static TimeSpan AsTimeSpan(this string str)
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

        /// <summary>
        /// Gets the size in bytes of this <see cref="string"/>.
        /// </summary>
        /// <param name="str"><see cref="string"/> to get size from.</param>
        /// <returns>Number of bytes.</returns>
        public static long GetSize(this string str) => (str.Length * sizeof(char)) + sizeof(long);

        /// <summary>
        /// Encrypts a <see cref="string"/> using the provided encryption key.
        /// </summary>
        /// <param name="clearText"><see cref="string"/> to encrypt.</param>
        /// <param name="key">Encryption key to use for encryption.</param>
        /// <returns>Encrypted <see cref="string"/>.</returns>
        public static string Encrypt(this string clearText, string key)
        {
            var encryptionKey = key;
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            using (var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
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
        /// <param name="cipherText"><see cref="string"/> to decrypt.</param>
        /// <param name="key">Encryption key to use for decryption.</param>
        /// <returns>Decrypted <see cref="string"/>.</returns>
        public static string Decrypt(this string cipherText, string key)
        {
            var encryptionKey = key;
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (var encryptor = Aes.Create())
            using (var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
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
    }
}