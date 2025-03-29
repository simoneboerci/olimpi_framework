using System;
using Logging.Core.Interfaces;

namespace Logging.Core.Errors
{
    public class LogProviderIsNullException : LoggingException
    {
        public LogProviderIsNullException(ILogProvider logProvider)
            : base("The log provider '" + nameof(logProvider) + "' cannot be null.")
        {
        }

        public LogProviderIsNullException(string message)
            : base(message)
        {
        }

        public LogProviderIsNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}