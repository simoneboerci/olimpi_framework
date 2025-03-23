using System;
using Logging.Core.Enums;

namespace Logging.Core.Models
{
    // Struttura immutabile che rappresenta una voce di log.
    // Contiene le informazioni essenziali come il livello di log, il messaggio, il timestamp e, opzionalmente, un'eccezione.
    public readonly struct LogEntry
    {
        // Proprietà che indica il livello del log (es. Info, Warning, Error)
        public LogLevel LogLevel { get; }
        
        // Proprietà che contiene il messaggio del log
        public string Message { get; }
        
        // Proprietà che memorizza la data e l'ora (in formato UTC) in cui il log è stato generato
        public DateTime Timestamp { get; }
        
        // Proprietà che contiene l'eccezione associata al log, se presente
        public Exception Exception { get; }

        // Costruttore che inizializza una nuova istanza di LogEntry.
        // Imposta il livello del log, il messaggio e, facoltativamente, l'eccezione.
        // Il Timestamp viene automaticamente assegnato all'orario corrente in formato UTC.
        public LogEntry(LogLevel logLevel, string message, Exception exception = null)
        {
            LogLevel = logLevel;
            Message = message;
            Timestamp = DateTime.UtcNow;
            Exception = exception;
        }     
    }
}