using System;
using System.IO;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    // La classe FileLogProvider gestisce il logging su file. Estende BaseLogProvider e implementa i metodi sincroni e asincroni per la scrittura dei log.
    public class FileLogProvider : BaseLogProvider
    {
        // Percorso del file dove verranno salvati i log
        private readonly string _filePath;
        // Flag che indica se devono essere usati file rotanti, ad esempio per creare un file per ogni data
        private readonly bool _rotateFiles;

        // Costruttore che inizializza il provider con il formatter, il percorso e l'opzione per la rotazione dei file
        public FileLogProvider(ILogFormatter formatter, string filePath, bool rotateFiles = false) : base(formatter)
        {
            _filePath = filePath;
            _rotateFiles = rotateFiles;
        }

        // Metodo sincrono che scrive una voce di log su file
        public override void Write(LogEntry entry)
        {
            // Recupera il percorso completo del file, eventualmente rotato in base alla data
            var path = GetFilePath();
            // Format del messaggio di log utilizzando il formatter ereditato
            var logText = FormatLogEntry(entry);
            // Appende il testo del log al file specificato aggiungendo una nuova riga alla fine
            File.AppendAllText(path, logText + Environment.NewLine);
        }

        // Metodo asincrono per scrivere una voce di log su file
        public override Task WriteAsync(LogEntry entry, Action callback = null)
        {
            // Recupera il percorso completo del file, eventualmente rotato in base alla data
            var path = GetFilePath();
            // Format del messaggio di log utilizzando il formatter ereditato
            var logText = FormatLogEntry(entry);
            // Esegue la scrittura in modo asincrono
            return Task.Run(() =>
            {
                // Appende il testo del log al file specificato aggiungendo una nuova riga
                File.AppendAllText(path, logText + Environment.NewLine);
                // Invochi il callback se specificato, una volta terminata la scrittura
                callback?.Invoke();
            });
        }

        // Metodo privato per determinare il percorso del file da utilizzare
        // Se la rotazione dei file è abilitata, aggiunge un suffisso basato sulla data corrente
        private string GetFilePath()
        {
            if (_rotateFiles)
            {
                // Ottiene la directory del file di log di base
                var directory = Path.GetDirectoryName(_filePath);
                // Ottiene il nome del file senza estensione
                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(_filePath);
                // Ottiene l'estensione del file
                var extension = Path.GetExtension(_filePath);
                // Crea un suffisso basato sulla data nel formato "yyyyMMdd"
                var dateSuffix = DateTime.Now.ToString("yyyyMMdd");
                // Combina directory, nome del file, suffisso della data ed estensione per creare il nuovo percorso
                return Path.Combine(directory!, $"{fileNameWithoutExt}_{dateSuffix}{extension}");
            }

            // Se la rotazione non è abilitata, ritorna semplicemente il percorso originario
            return _filePath;
        }
    }
}