using Logging.Core.Models;

namespace Logging.Core.Interfaces
{
    /// <summary>
    /// Interfaccia ILogFormatter che definisce il metodo per formattare una voce di log.
    /// Ogni implementazione di questa interfaccia deve fornire il metodo <see cref="Format"/> per convertire un <see cref="LogEntry"/> in una stringa formattata.
    /// </summary>
    public interface ILogFormatter
    {
        /// <summary>
        /// Converte una voce di log in una stringa formattata.
        /// </summary>
        /// <param name="entry">L'istanza di <see cref="LogEntry"/> contenente i dettagli del log.</param>
        /// <returns>Una stringa che rappresenta il log formattato.</returns>
        string Format(LogEntry entry);
    }
}