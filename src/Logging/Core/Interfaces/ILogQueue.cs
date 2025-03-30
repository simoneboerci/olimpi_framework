using System;
using System.Collections.Generic;
using Logging.Core.Models;

namespace Logging.Core.Interfaces
{
    /// <summary>
    /// Interfaccia per la gestione della coda di log.
    /// </summary>
    public interface ILogQueue
    {
        event Action<LogEntry> LogEntryAdded;

        void Enqueue(LogEntry entry);

        public List<LogEntry> GetLogs(int? maxLogs = null);
    }
}