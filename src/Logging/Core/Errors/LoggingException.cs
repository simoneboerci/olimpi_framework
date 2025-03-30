using System;

namespace Logging.Core.Errors
{
    public class LoggingException : Exception
    {
        public LoggingException() 
            : base("Logging: An error occurred.") 
        { 
        }

        public LoggingException(string message) 
            : base($"Logging: {message}") 
        { 
        }

        public LoggingException(string message, Exception innerException) 
            : base($"Logging: {message}", innerException) 
        { 
        }
    }
}