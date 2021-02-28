/*
 * CHANGE LOG - keep only last 5 threads
 * 
 * RESOURCES
 */
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Gravity.Plugins.Utilities
{
    public class CliFactory
    {
        // members: constants
        private const string ArgumentPattern = @"(?<=--)(.*?)(?=\s+--|$)"; // pattern: gets all arguments within a command line
        private const string CliPattern = "(?<={{[$]).*(?=(}}))";          // pattern: command line pattern validation
        private const string KeyPattern = "^[^:]*";                        // pattern: use to extract arguments keys
        private const string ValuePattern = "(?<=:).*$";                   // pattern: use to extract arguments values

        // members: state
        private string cli;

        /// <summary>
        /// Creates a new <see cref="CliFactory"/> instance.
        /// </summary>
        public CliFactory() : this(string.Empty) { }

        /// <summary>
        /// Creates a new <see cref="CliFactory"/> instance.
        /// </summary>
        /// <param name="cli">Command line on which this factory is based.</param>
        public CliFactory(string cli)
        {
            Setup(cli);
        }

        /// <summary>
        /// Gets a value indicates if this <see cref="CliFactory"/> instance is command line compliant (i.e. have a valid command line).
        /// </summary>
        public bool CliCompliant { get; private set; }

        #region *** parsing   ***
        /// <summary>
        /// Parse all command arguments into a key/value collection - ignores trialling and leading value spaces.
        /// </summary>
        /// <returns>Command arguments collection.</returns>
        public IDictionary<string, string> Parse()
        {
            return GetCliArguments(cli, false);
        }

        /// <summary>
        /// Parse all command arguments into a key/value collection - ignores trialling and leading value spaces.
        /// </summary>
        /// <param name="cli">Command line on which this factory is based.</param>
        /// <returns>Command arguments collection.</returns>
        public IDictionary<string, string> Parse(string cli)
        {
            return GetCliArguments(cli, reset: true);
        }

        // parse all command arguments into a key/value collection
        private IDictionary<string, string> GetCliArguments(string cli, bool reset)
        {
            // exit conditions
            if (string.IsNullOrEmpty(cli))
            {
                return new Dictionary<string, string>();
            }

            // reset conditions
            if (reset)
            {
                Setup(cli);
            }

            // clean CLI
            var cleanCli = Regex.Match(input: cli, pattern: CliPattern).Value.Trim();

            // get all arguments as list
            var arguments = Regex
                .Matches(cleanCli, ArgumentPattern)
                .Cast<Match>()
                .Select(i => i.Value.Trim())
                .Where(i => !string.IsNullOrEmpty(i));

            // results
            return GetResults(arguments);
        }

        private static IDictionary<string, string> GetResults(IEnumerable<string> arguments)
        {
            // setup
            var results = new Dictionary<string, string>();

            // iterate
            foreach (var argument in arguments)
            {
                var key = Regex.Match(argument, KeyPattern).Value;
                results[key] = Regex.Match(argument, ValuePattern).Value ?? string.Empty;
            }

            // arguments collection
            return results;
        }
        #endregion

        #region *** compiling ***
        /// <summary>
        /// Gets a value indicates if this <see cref="CliFactory"/> instance is command line compliant (i.e. have a valid command line).
        /// </summary>
        /// <param name="cli">Command line on which this factory is based.</param>
        /// <returns><see cref="true"/> if compliant, <see cref="false"/> if not.</returns>
        public static bool Compile(string cli)
        {
            // set command line
            cli ??= string.Empty;

            // exit conditions
            return Regex.IsMatch(cli, CliPattern);
        }
        #endregion

        // setup this command line factory instance
        private void Setup(string cli)
        {
            // set command line
            cli ??= string.Empty;

            // exit conditions
            if (!Regex.IsMatch(cli, CliPattern))
            {
                CliCompliant = false;
                return;
            }

            // set state
            this.cli = Regex.Match(cli, CliPattern).Value;
            CliCompliant = true;
        }
    }
}