using System;
using System.IO;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    /// <summary>
    /// La classe FileLogProvider gestisce il logging su file.
    /// Estende <see cref="BaseLogProvider"/> e implementa i metodi sincroni e asincroni per la scrittura dei log.
    /// Supporta anche l'opzione di rotazione dei file, creando file separati basati sulla data corrente.
    /// </summary>
    public class FileLogProvider : BaseLogProvider
    {
        /// <summary>
        /// Percorso base del file dove verranno salvati i log.
        /// </summary>
        private readonly string _filePath;
        /// <summary>
        /// Flag che indica se abilitare la rotazione dei file (es. un file per ogni data).
        /// </summary>
        private readonly bool _rotateFiles;

        /// <summary>
        /// Inizializza una nuova istanza di <see cref="FileLogProvider"/>.
        /// </summary>
        /// <param name="formatter">Il formatter utilizzato per formattare il log.</param>
        /// <param name="filePath">Il percorso del file di log.</param>
        /// <param name="rotateFiles">Se impostato su true, abilita la rotazione dei file in base alla data.</param>
        public FileLogProvider(ILogFormatter formatter, string filePath, bool rotateFiles = false) : base(formatter)
        {
            _filePath = filePath;
            _rotateFiles = rotateFiles;
        }

        /// <summary>
        /// Scrive sincronicamente una voce di log su file.
        /// </summary>
        /// <param name="entry">L'entry di log da scrivere.</param>
        protected override void DisplayLogEntryImplementation(LogEntry entry, string formattedText)
        {
            // Appende il testo del log al file specificato, aggiungendo una nuova riga alla fine.
            File.AppendAllText(GetFilePath(), formattedText + Environment.NewLine);
        }

        /// <summary>
        /// Determina il percorso del file da utilizzare per il log.
        /// Se la rotazione dei file è abilitata, aggiunge un suffisso basato sulla data corrente (formato "yyyyMMdd").
        /// </summary>
        /// <returns>Il percorso completo del file di log.</returns>
        private string GetFilePath()
        {
            if (_rotateFiles)
            {
                // Ottiene la directory del file di log base.
                var directory = Path.GetDirectoryName(_filePath);
                // Ottiene il nome del file senza estensione.
                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(_filePath);
                // Ottiene l'estensione del file.
                var extension = Path.GetExtension(_filePath);
                // Crea un suffisso basato sulla data corrente nel formato "yyyyMMdd".
                var dateSuffix = DateTime.Now.ToString("yyyyMMdd");
                // Combina directory, nome del file, suffisso e estensione per creare il nuovo percorso.
                return Path.Combine(directory!, $"{fileNameWithoutExt}_{dateSuffix}{extension}");
            }

            // Se la rotazione non è abilitata, ritorna il percorso originario.
            return _filePath;
        }
    }
}