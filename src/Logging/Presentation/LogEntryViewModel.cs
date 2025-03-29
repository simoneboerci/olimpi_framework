using System;
using System.Collections.Generic;
using System.Text.Json;
using Logging.Core.Enums;
using Logging.Core.Errors;
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
        public LogLevel LogLevel { get; set; }
        
        /// <summary>
        /// Contiene il messaggio del log.
        /// </summary>
        public string Message { get; set; } = "";
        
        /// <summary>
        /// Memorizza la data e l'ora in cui il log è stato generato.
        /// </summary>
        public DateTime Timestamp { get; set; }
        
        /// <summary>
        /// Tag associato al log, ad esempio per raggruppamenti o filtraggio.
        /// </summary>
        public string Tag { get; set; } = "";
        
        /// <summary>
        /// Contiene il messaggio dell'eccezione, se presente.
        /// </summary>
        public string ExceptionMessage { get; set; } = "";
        
        /// <summary>
        /// Informazioni aggiuntive sotto forma di dizionario.
        /// </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Converte un'entità LogEntry in un'istanza di LogEntryViewModel.
        /// </summary>
        /// <param name="entry">L'entità LogEntry da convertire.</param>
        /// <returns>Una nuova istanza di LogEntryViewModel con i dati mappati dall'entità.</returns>
        public static LogEntryViewModel FromEntity(LogEntry entry)
        {
            if (entry.Equals(null))
                throw new LogEntryIsNullException(entry);

            return new LogEntryViewModel
            {
                LogLevel = entry.LogLevel,
                Message = entry.Message,
                Timestamp = entry.Timestamp,
                Tag = entry.Tag,
                ExceptionMessage = entry.Exception?.Message ?? "",
                Metadata = entry.Metadata
            };
        }

        /// <summary>
        /// Crea un'istanza di LogEntryViewModel a partire da una stringa JSON.
        /// </summary>
        /// <param name="json">La stringa JSON da deserializzare.</param>
        /// <returns>Un'istanza di LogEntryViewModel ottenuta dalla stringa JSON.</returns>
        public static LogEntryViewModel FromJson(string json)
        {
            return JsonSerializer.Deserialize<LogEntryViewModel>(json)!;
        }

        /// <summary>
        /// Serializza l'oggetto LogEntryViewModel in una stringa JSON.
        /// </summary>
        /// <returns>La rappresentazione in formato JSON dell'istanza corrente.</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}