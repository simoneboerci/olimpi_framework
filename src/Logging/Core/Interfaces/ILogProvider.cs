using System;
using System.Threading.Tasks;
using Logging.Core.Models;

namespace Logging.Core.Interfaces
{
    /// <summary>
    /// Interfaccia ILogProvider che definisce le operazioni di logging.
    /// Ogni implementazione di questa interfaccia deve fornire i metodi per scrivere log in maniera sincrona e asincrona.
    /// </summary>
    public interface ILogProvider
    {
        /// <summary>
        /// Metodo sincrono per scrivere una voce di log.
        /// Riceve un <see cref="LogEntry"/> che contiene le informazioni del log da registrare.
        /// </summary>
        /// <param name="entry">L'istanza di <see cref="LogEntry"/> contenente i dettagli del log.</param>
        void Write(LogEntry entry);

        /// <summary>
        /// Metodo asincrono per scrivere una voce di log.
        /// Riceve un <see cref="LogEntry"/> e, opzionalmente, un callback da eseguire al termine dell'operazione.
        /// </summary>
        /// <param name="entry">L'istanza di <see cref="LogEntry"/> contenente i dettagli del log.</param>
        /// <param name="callback">Un'azione opzionale da eseguire al termine dell'operazione.</param>
        /// <returns>Un task che rappresenta l'operazione asincrona di scrittura del log.</returns>
        Task WriteAsync(LogEntry entry, Action callback = null);
    }
}