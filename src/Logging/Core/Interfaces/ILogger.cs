using Logging.Core.Models;

namespace Logging.Core.Interfaces
{
    /// <summary>
    /// Interfaccia ILogger che definisce le operazioni di logging da implementare.
    /// Ogni implementazione di questa interfaccia fornisce metodi per registrare una voce di log in maniera sincrona e asincrona.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Metodo sincrono per registrare una voce di log.
        /// Riceve un'istanza di <see cref="LogEntry"/> che contiene le informazioni del log da registrare.
        /// </summary>
        /// <param name="entry">L'istanza di <see cref="LogEntry"/> contenente i dettagli del log.</param>
        void Log(LogEntry entry);

        void SwapLogQueue(ILogQueue newLogQueue);

        void AttachLogProvider(ILogProvider logProvider, bool loadPreviousLogEntries = true);
        void DetachLogProvider(ILogProvider logProvider);
    }
}