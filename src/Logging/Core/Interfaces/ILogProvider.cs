using System;
using System.Threading.Tasks;
using Logging.Core.Models;

namespace Logging.Core.Interfaces
{
    // Interfaccia ILogProvider che definisce le operazioni di logging.
    // Ogni implementazione di questa interfaccia deve fornire i metodi per scrivere log in maniera sincrona e asincrona.
    public interface ILogProvider
    {
        // Metodo sincrono per scrivere una voce di log.
        // Riceve un LogEntry che contiene le informazioni del log da registrare.
        void Write(LogEntry entry);

        // Metodo asincrono per scrivere una voce di log.
        // Riceve un LogEntry e, opzionalmente, un callback da eseguire al termine dell'operazione.
        Task WriteAsync(LogEntry entry, Action callback = null);
    }
}