using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Formatters
{
    /// <summary>
    /// Implementazione di <see cref="ILogFormatter"/> che formatta un oggetto <see cref="LogEntry"/>
    /// in una stringa di testo semplice.
    /// </summary>
    public class PlainTextLogFormatter : ILogFormatter
    {
        /// <summary>
        /// Formattta l'oggetto <see cref="LogEntry"/> in una stringa.
        /// Il formato risultante include:
        /// <list type="bullet">
        ///     <item>
        ///         <description>La data e l'ora del log nel formato "yyyy-MM-dd HH:mm:ss".</description>
        ///     </item>
        ///     <item>
        ///         <description>Il livello del log (ad esempio: Info, Warning, Error).</description>
        ///     </item>
        ///     <item>
        ///         <description>Il messaggio del log.</description>
        ///     </item>
        ///     <item>
        ///         <description>Se presente, il messaggio dell'eccezione associata preceduto da "Exception:".</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="entry">L'istanza di <see cref="LogEntry"/> da formattare.</param>
        /// <returns>Una stringa contenente il log formattato in testo semplice.</returns>
        public string Format(LogEntry entry)
        {
            return $"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}] [{entry.LogLevel}] {entry.Message}" +
                   (entry.Exception != null ? $" | Exception: {entry.Exception.Message}" : string.Empty);
        }
    }
}