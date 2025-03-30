using System;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    /// <summary>
    /// Classe astratta che rappresenta un provider di log.
    /// Fornisce funzionalità comuni per la formattazione delle entry di log e definisce il meccanismo per visualizzarle.
    /// Le classi derivate devono implementare il metodo astratto DisplayLogEntryImplementation per gestire
    /// la scrittura dei log in maniera specifica (es. su file, console, etc.).
    /// </summary>
    public abstract class BaseLogProvider : ILogProvider
    {
        /// <summary>
        /// Formatter utilizzato per convertire un oggetto <see cref="LogEntry"/> in una stringa formattata.
        /// </summary>
        protected readonly ILogFormatter Formatter;
        
        /// <summary>
        /// Funzione di filtro che permette di determinare se una specifica entry deve essere processata.
        /// Se non viene specificato, tutte le entry vengono processate.
        /// </summary>
        protected readonly Func<LogEntry, bool> Filter;

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="BaseLogProvider"/> con il formatter specificato e un filtro opzionale.
        /// Se il parametro <paramref name="formatter"/> è null, viene sollevata un'eccezione ArgumentNullException.
        /// </summary>
        /// <param name="formatter">Il formatter da utilizzare per formattare le entry di log.</param>
        /// <param name="filter">Un delegato che consente di filtrare le entry di log; default accetta tutte le entry.</param>
        protected BaseLogProvider(ILogFormatter formatter, Func<LogEntry, bool> filter = null)
        {
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            Filter = filter ?? (entry => true);
        }

        /// <summary>
        /// Metodo pubblico per processare e visualizzare una voce di log.
        /// Se il filtro applicato all'entry restituisce false, la voce di log viene ignorata.
        /// Altrimenti, la entry viene formattata utilizzando il formatter e viene delegato il rendering al metodo astratto.
        /// </summary>
        /// <param name="entry">L'entry di log da visualizzare.</param>
        public void DisplayLogEntry(LogEntry entry)
        {
            if (!Filter(entry))
            {
                return;
            }
            // Formattta l'entry e invoca il metodo astratto per la visualizzazione.
            DisplayLogEntryImplementation(entry, Formatter.Format(entry));
        }

        /// <summary>
        /// Metodo astratto che deve essere implementato dalle classi derivate per definire la logica specifica di scrittura della voce di log.
        /// Ad esempio, un provider potrebbe scrivere il log su file o sulla console.
        /// </summary>
        /// <param name="entry">L'entry di log originale.</param>
        /// <param name="formattedText">La stringa formattata ottenuta dal formatter.</param>
        protected abstract void DisplayLogEntryImplementation(LogEntry entry, string formattedText);
    }
}