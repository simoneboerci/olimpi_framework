using Logging.Core.Interfaces;
using Logging.Core.Models;
using Logging.Presentation;

namespace Logging.Data.Formatters
{
    /// <summary>
    /// Classe JsonLogFormatter che implementa l'interfaccia <see cref="ILogFormatter"/>.
    /// Si occupa di formattare un oggetto <see cref="LogEntry"/> in una stringa in formato JSON.
    /// </summary>
    public class JsonLogFormatter : ILogFormatter
    {
        /// <summary>
        /// Converte l'oggetto <see cref="LogEntry"/> in una stringa JSON.
        /// Per fare ciò, trasforma prima il log in un <see cref="LogEntryViewModel"/>
        /// e successivamente serializza il viewmodel in formato JSON.
        /// </summary>
        /// <param name="entry">L'istanza di <see cref="LogEntry"/> da formattare.</param>
        /// <returns>Una stringa contenente il log in formato JSON.</returns>
        public string Format(LogEntry entry)
        {
            // Converte l'entità LogEntry in un LogEntryViewModel per una migliore rappresentazione.
            var viewModel = LogEntryViewModel.FromEntity(entry);
            // Serializza il LogEntryViewModel in una stringa JSON e la restituisce.
            return viewModel.ToJson();
        }
    }
}