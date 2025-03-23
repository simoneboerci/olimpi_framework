using System;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    // Classe astratta che rappresenta un provider di log.
    // Implementa l'interfaccia ILogProvider e fornisce funzionalità comuni per la formattazione dei log.
    public abstract class BaseLogProvider : ILogProvider
    {
        // Formatter utilizzato per convertire un LogEntry in una stringa formattata.
        protected readonly ILogFormatter Formatter;

        // Costruttore che inizializza il BaseLogProvider con un formatter.
        // Se il formatter è null, viene sollevata un'eccezione ArgumentNullException.
        protected BaseLogProvider(ILogFormatter formatter)
        {
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        // Metodo astratto per scrivere una voce di log in modo sincrono.
        public abstract void Write(LogEntry entry);

        // Metodo astratto per scrivere una voce di log in modo asincrono.
        // Accetta un callback opzionale da invocare al termine dell'operazione.
        public abstract Task WriteAsync(LogEntry entry, Action callback = null);

        // Metodo protetto per formattare una voce di log utilizzando il formatter in uso.
        // Ritorna una stringa che rappresenta il log formattato.
        protected string FormatLogEntry(LogEntry entry)
        {
            return Formatter.Format(entry);
        }
    }
}