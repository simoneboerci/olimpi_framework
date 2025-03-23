using System;
using System.Threading.Tasks;
using Logging.Core.Models;

namespace Logging.Core.Interfaces
{
    // Interfaccia ILogger che definisce le operazioni di logging da implementare.
    // Ogni implementazione di questa interfaccia deve fornire metodi per registrare una voce di log in maniera sincrona e asincrona.
    public interface ILogger
    {
        // Metodo sincrono per registrare una voce di log.
        // Riceve un LogEntry che contiene le informazioni del log da registrare.
        void Log(LogEntry entry);

        // Metodo asincrono per registrare una voce di log.
        // Riceve un LogEntry da scrivere e, opzionalmente, un callback da eseguire al termine dell'operazione.
        Task LogAsync(LogEntry entry, Action callback = null);
    }
}