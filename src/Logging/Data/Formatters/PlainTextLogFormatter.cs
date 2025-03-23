using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Formatters
{
    // Classe PlainTextLogFormatter che implementa l'interfaccia ILogFormatter.
    // Questa classe si occupa di formattare un oggetto LogEntry in una stringa in formato testo semplice.
    public class PlainTextLogFormatter : ILogFormatter
    {
        // Metodo che formatta un oggetto LogEntry in una stringa.
        // Il formato include:
        // - La data e l'ora del log nel formato "yyyy-MM-dd HH:mm:ss"
        // - Il livello del log (ad esempio: Info, Warning, Error)
        // - Il messaggio del log
        // - Se presente, il messaggio dell'eccezione associata al log, preceduto dalla parola "Exception:"
        public string Format(LogEntry entry)
        {
            return $"[{entry.Timestamp:yyyy-MM-dd HH:mm:ss}] [{entry.LogLevel}] {entry.Message}" +
                   (entry.Exception != null ? $" | Exception: {entry.Exception.Message}" : string.Empty);
        }
    }
}