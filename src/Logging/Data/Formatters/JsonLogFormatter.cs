using Logging.Core.Interfaces;
using Logging.Core.Models;
using Logging.Presentation;

namespace Logging.Data.Formatters
{
    // Classe JsonLogFormatter che implementa l'interfaccia ILogFormatter.
    // Questa classe si occupa di formattare un oggetto LogEntry in una stringa in formato JSON.
    public class JsonLogFormatter : ILogFormatter
    {
        // Metodo Format che riceve un oggetto LogEntry e lo converte in una stringa JSON.
        public string Format(LogEntry entry)
        {
            // Converte l'entità LogEntry in un LogEntryViewModel per una migliore rappresentazione
            var viewModel = LogEntryViewModel.FromEntity(entry);
            // Serializza il LogEntryViewModel in una stringa JSON e la restituisce
            return viewModel.ToJson();
        }
    }
}