using System;
using Logging.Core.Models;

namespace Logging.Core.Errors
{
    public class LogEntryIsNullException : LoggingException
    {
        public LogEntryIsNullException(LogEntry logEntry)
            : base("The log '" + nameof(logEntry) + "' entry cannot be null.") { }

        public LogEntryIsNullException(string message)
            : base(message) { }

        public LogEntryIsNullException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}