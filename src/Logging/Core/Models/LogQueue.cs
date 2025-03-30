using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Logging.Core.Errors;
using Logging.Core.Interfaces;

namespace Logging.Core.Models;

public sealed class LogQueue : ILogQueue
{
    public event Action<LogEntry> LogEntryAdded;

    private readonly ConcurrentQueue<LogEntry> _queue = new();

    public void Enqueue(LogEntry logEntry)
    {
        if (logEntry.Equals(null))
        {
            throw new LogEntryIsNullException(logEntry);
        }

        _queue.Enqueue(logEntry);

        LogEntryAdded?.Invoke(logEntry);
    }

    public List<LogEntry> GetLogs(int? maxLogs = null)
    {
        var logs = _queue.ToArray();
        if (maxLogs.HasValue && maxLogs.Value > 0)
        {
            logs = logs.Skip(Math.Max(0, logs.Length - maxLogs.Value)).ToArray();
        }
        return logs.OrderBy(log => log.Timestamp).ToList();
    }
}