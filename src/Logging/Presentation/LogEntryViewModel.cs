using System;
using System.Text.Json;
using Logging.Core.Enums;
using Logging.Core.Models;

namespace Logging.Presentation
{
    // Classe ViewModel che rappresenta un log entry in modo adatto alla presentazione
    public class LogEntryViewModel
    {
        // Proprietà che indica il livello del log (ad esempio: Info, Warning, Error)
        public LogLevel Level { get; set; }
        
        // Proprietà che contiene il messaggio del log
        public string Message { get; set; } = "";
        
        // Proprietà che memorizza la data e l'ora in cui il log è stato generato
        public DateTime Timestamp { get; set; }
        
        // Proprietà che contiene il messaggio dell'eccezione, se presente
        public string Exception { get; set; }

        // Metodo statico per convertire un'entità LogEntry in un LogEntryViewModel
        public static LogEntryViewModel FromEntity(LogEntry entry)
        {
            return new LogEntryViewModel
            {
                Level = entry.LogLevel,            // Imposta il livello di log a partire dall'entità
                Message = entry.Message,            // Imposta il messaggio di log
                Timestamp = entry.Timestamp,        // Imposta il timestamp del log
                Exception = entry.Exception?.Message // Imposta il messaggio dell'eccezione se presente
            };
        }

        // Metodo statico per creare un LogEntryViewModel da una stringa JSON
        public static LogEntryViewModel FromJson(string json)
        {
            // Deserializza la stringa JSON nel LogEntryViewModel
            return JsonSerializer.Deserialize<LogEntryViewModel>(json)!;
        }

        // Metodo per serializzare l'oggetto LogEntryViewModel in una stringa JSON
        public string ToJson()
        {
            // Serializza questo oggetto in formato JSON
            return JsonSerializer.Serialize(this);
        }
    }
}