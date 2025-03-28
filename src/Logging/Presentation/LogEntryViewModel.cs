using System;
using System.Text.Json;
using Logging.Core.Enums;
using Logging.Core.Models;

namespace Logging.Presentation
{
    /// <summary>
    /// Classe ViewModel che rappresenta un log entry in modo adatto alla presentazione.
    /// Fornisce metodi per la conversione da un'entità LogEntry e per la serializzazione/deserializzazione in formato JSON.
    /// </summary>
    public class LogEntryViewModel
    {
        /// <summary>
        /// Indica il livello del log (ad esempio, Info, Warning, Error).
        /// </summary>
        public LogLevel Level { get; set; }
        
        /// <summary>
        /// Contiene il messaggio del log.
        /// </summary>
        public string Message { get; set; } = "";
        
        /// <summary>
        /// Memorizza la data e l'ora in cui il log è stato generato.
        /// </summary>
        public DateTime Timestamp { get; set; }
        
        /// <summary>
        /// Contiene il messaggio dell'eccezione, se presente.
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Converte un'entità LogEntry in un'istanza di LogEntryViewModel.
        /// </summary>
        /// <param name="entry">L'entità LogEntry da convertire.</param>
        /// <returns>Una nuova istanza di LogEntryViewModel con i dati mappati dall'entità.</returns>
        public static LogEntryViewModel FromEntity(LogEntry entry)
        {
            return new LogEntryViewModel
            {
                Level = entry.LogLevel,             // Mappa il livello di log dall'entità.
                Message = entry.Message,             // Mappa il messaggio del log.
                Timestamp = entry.Timestamp,         // Mappa il timestamp del log.
                Exception = entry.Exception?.Message // Mappa il messaggio dell'eccezione, se presente.
            };
        }

        /// <summary>
        /// Crea un'istanza di LogEntryViewModel a partire da una stringa JSON.
        /// </summary>
        /// <param name="json">La stringa JSON da deserializzare.</param>
        /// <returns>Un'istanza di LogEntryViewModel ottenuta dalla stringa JSON.</returns>
        public static LogEntryViewModel FromJson(string json)
        {
            // Deserializza la stringa JSON nel LogEntryViewModel.
            return JsonSerializer.Deserialize<LogEntryViewModel>(json)!;
        }

        /// <summary>
        /// Serializza l'oggetto LogEntryViewModel in una stringa JSON.
        /// </summary>
        /// <returns>La rappresentazione in formato JSON dell'istanza corrente di LogEntryViewModel.</returns>
        public string ToJson()
        {
            // Serializza questo oggetto in formato JSON.
            return JsonSerializer.Serialize(this);
        }
    }
}