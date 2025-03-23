using Logging.Core.Models;

namespace Logging.Core.Interfaces
{
    // Interfaccia ILogFormatter che definisce il metodo per formattare una voce di log.
    // Ogni implementazione di questa interfaccia deve fornire il metodo Format per convertire un LogEntry in una stringa formattata.
    public interface ILogFormatter
    {
        // Metodo che riceve una voce di log (LogEntry) e la converte in una stringa formattata.
        string Format(LogEntry entry);
    }
}