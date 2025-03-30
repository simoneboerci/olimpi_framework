using System;
using Logging.Core.Interfaces;

namespace Logging.Core.Errors
{
    /// <summary>
    /// Exception thrown when the log queue is null.
    /// </summary>
    public class LogQueueIsNullException : LoggingException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogQueueIsNullException"/> class.
        /// </summary>
        public LogQueueIsNullException(ILogQueue logQueue)
            : base("The log '" + nameof(logQueue) + "' queue cannot be null.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogQueueIsNullException"/> class with a custom message.
        /// </summary>
        /// <param name="message">The custom error message.</param>
        public LogQueueIsNullException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogQueueIsNullException"/> class with a custom message and an inner exception.
        /// </summary>
        /// <param name="message">The custom error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public LogQueueIsNullException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}