using System;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    /// <summary>
    /// Classe astratta che rappresenta un provider di log.
    /// Implementa l'interfaccia <see cref="ILogProvider"/> e fornisce funzionalità comuni
    /// per la formattazione delle entry di log.
    /// </summary>
    public abstract class BaseLogProvider : ILogProvider
    {
        /// <summary>
        /// Formatter utilizzato per convertire un <see cref="LogEntry"/> in una stringa formattata.
        /// </summary>
        protected readonly ILogFormatter Formatter;

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="BaseLogProvider"/> con il formatter specificato.
        /// Solleva un'eccezione <see cref="ArgumentNullException"/> se il parametro formatter è null.
        /// </summary>
        /// <param name="formatter">Il formatter da utilizzare per formattare le entry di log.</param>
        protected BaseLogProvider(ILogFormatter formatter)
        {
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        /// <summary>
        /// Metodo astratto per scrivere una voce di log in maniera sincrona.
        /// Le classi derivate devono implementare la logica specifica per la scrittura del log.
        /// </summary>
        /// <param name="entry">L'entry di log da scrivere.</param>
        public abstract void Write(LogEntry entry);

        /// <summary>
        /// Metodo astratto per scrivere una voce di log in maniera asincrona.
        /// Le classi derivate devono implementare la logica specifica per la scrittura
        /// del log in modo non bloccante, accettando un callback opzionale che verrà eseguito
        /// al termine dell'operazione.
        /// </summary>
        /// <param name="entry">L'entry di log da scrivere.</param>
        /// <param name="callback">Callback opzionale da invocare al termine della scrittura.</param>
        /// <returns>Un task che rappresenta l'operazione asincrona di scrittura del log.</returns>
        public abstract Task WriteAsync(LogEntry entry, Action callback = null);

        /// <summary>
        /// Metodo protetto che formatta una voce di log utilizzando il formatter in uso.
        /// </summary>
        /// <param name="entry">L'entry di log da formattare.</param>
        /// <returns>Una stringa che rappresenta il log formattato.</returns>
        protected string FormatLogEntry(LogEntry entry)
        {
            return Formatter.Format(entry);
        }
    }
}