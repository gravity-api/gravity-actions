using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Interface allowing handling of driver logs.
    /// </summary>
    /// <seealso cref="ILogs" />
    public class MockLogs : ILogs
    {
        private readonly IList<LogEntry> m_LogEntries = new List<LogEntry>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MockLogs"/> class.
        /// </summary>
        public MockLogs()
        {
            AvailableLogTypes = new ReadOnlyCollection<string>(new List<string>
            {
                "Mock"
            });
        }

        /// <summary>
        /// Gets the list of available log types for this driver.
        /// </summary>
        public ReadOnlyCollection<string> AvailableLogTypes { get; }

        /// <summary>
        /// Gets the set of <see cref="T:OpenQA.Selenium.LogEntry" /> objects for a specified log.
        /// </summary>
        /// <param name="logKind">The log for which to retrieve the log entries.
        /// Log types can be found in the <see cref="LogType" /> class.</param>
        /// <returns>
        /// The list of <see cref="LogEntry" /> objects for the specified log.
        /// </returns>
        public ReadOnlyCollection<LogEntry> GetLog(string logKind)
        {
            return new ReadOnlyCollection<LogEntry>(m_LogEntries);
        }
    }
}
