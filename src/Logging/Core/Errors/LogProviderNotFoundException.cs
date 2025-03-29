using System;
using Logging.Core.Interfaces;

namespace Logging.Core.Errors
{
    public class LogProviderNotFoundException : LoggingException
    {
        public LogProviderNotFoundException(ILogProvider logProvider)
            : base("Log provider '" + nameof(logProvider) + "' not found.")
        {
        }

        public LogProviderNotFoundException(string message)
            : base(message)
        {
        }

        public LogProviderNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}