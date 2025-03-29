using System;
using System.Collections.Generic;
using Logging.Core.Enums;

namespace Logging.Core.Models
{
    /// <summary>
    /// Struttura immutabile che rappresenta una voce di log.
    /// Contiene le informazioni essenziali come il livello del log, il messaggio, il timestamp e, opzionalmente, l'eccezione associata.
    /// </summary>
    public readonly struct LogEntry
    {
        /// <summary>
        /// Proprietà che indica il livello del log (es. Info, Warning, Error).
        /// </summary>
        public LogLevel LogLevel { get; }
        
        /// <summary>
        /// Proprietà che contiene il messaggio del log.
        /// </summary>
        public string Message { get; }
        
        /// <summary>
        /// Proprietà che memorizza la data e l'ora (in formato UTC) in cui il log è stato generato.
        /// </summary>
        public DateTime Timestamp { get; }

        public string Tag { get; }
        
        /// <summary>
        /// Proprietà che contiene l'eccezione associata al log, se presente.
        /// </summary>
        public Exception Exception { get; }

        public IReadOnlyDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Costruttore che inizializza una nuova istanza di <see cref="LogEntry"/>.
        /// Imposta il livello del log, il messaggio e, facoltativamente, l'eccezione associata.
        /// Il <see cref="Timestamp"/> viene automaticamente assegnato all'orario corrente in formato UTC.
        /// </summary>
        /// <param name="logLevel">Il livello del log.</param>
        /// <param name="message">Il messaggio associato al log.</param>
        /// <param name="exception">L'eccezione associata al log, se presente. Valore predefinito = null.</param>
        public LogEntry(LogLevel logLevel, string message, string tag = null, Exception exception = null, IReadOnlyDictionary<string, string> metadata = null)
        {
            LogLevel = logLevel;
            Message = message;
            Timestamp = DateTime.UtcNow;
            Tag = tag;
            Exception = exception;
            Metadata = metadata ?? new Dictionary<string, string>();
        }     
    }
}