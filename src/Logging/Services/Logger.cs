using System.Collections.Generic;
using Logging.Core.Errors;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Services
{
    /// <summary>
    /// Implementazione dell'interfaccia <see cref="ILogger"/> per la gestione del logging.
    /// Utilizza una collezione di provider per scrivere le voci di log.
    /// </summary>
    public sealed class Logger : ILogger
    {
        private ILogQueue _logQueue;

        /// <summary>
        /// Collezione dei provider che gestiscono le operazioni di scrittura del log.
        /// </summary>
        private readonly IList<ILogProvider> _logProviders;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="Logger"/>.
        /// </summary>
        /// <param name="logProviders">I provider utilizzati per scrivere le voci di log.</param>
        public Logger(ILogQueue logQueue, IList<ILogProvider> logProviders)
        {
            _logQueue = logQueue;
            _logProviders = logProviders;
        }

        /// <summary>
        /// Registra sincronicamente una voce di log inviandola a tutti i provider configurati.
        /// </summary>
        /// <param name="logEntry">La voce di log da registrare.</param>
        public void Log(LogEntry logEntry)
        {
            if (logEntry.Equals(null))
            {
                throw new LogEntryIsNullException(logEntry);
            }

            _logQueue.Enqueue(logEntry);
        }

        public void SwapLogQueue(ILogQueue newLogQueue)
        {
            _logQueue = newLogQueue ?? throw new LogQueueIsNullException(newLogQueue);
        }

        public void AttachLogProvider(ILogProvider logProvider, bool loadPreviousLogEntries = true)
        {
            if (logProvider == null)
            {
                throw new LogProviderIsNullException(logProvider);
            }

            if (_logQueue != null)
            {
                if (loadPreviousLogEntries)
                {
                    foreach(LogEntry logEntry in _logQueue.GetLogs())
                    {
                        logProvider.DisplayLogEntry(logEntry);
                    }
                }

                _logQueue.LogEntryAdded += logProvider.DisplayLogEntry;
            }

            _logProviders.Add(logProvider);
        }

        public void DetachLogProvider(ILogProvider logProvider)
        {
            if (logProvider == null)
            {
                throw new LogProviderIsNullException(logProvider);
            }

            if (!_logProviders.Contains(logProvider))
            {
                throw new LogProviderNotFoundException(logProvider);
            }

            if (_logQueue != null)
            {
                _logQueue.LogEntryAdded -= logProvider.DisplayLogEntry;
            }

            _logProviders.Remove(logProvider);
        }
    }
}