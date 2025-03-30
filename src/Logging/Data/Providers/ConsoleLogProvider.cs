using System;
using ConsoleOperations.Core.Interfaces;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    /// <summary>
    /// La classe ConsoleLogProvider gestisce il logging verso la console.
    /// Estende BaseLogProvider per utilizzare un formatter comune e implementare la logica per visualizzare
    /// le entry di log sulla console.
    /// Inoltre, implementa IDisposable per liberare le risorse (in particolare la gestione della system console).
    /// </summary>
    public class ConsoleLogProvider : BaseLogProvider, IDisposable
    {
        // Istanza di ISystemConsole per interagire con la console.
        private readonly ISystemConsole _systemConsole;

        /// <summary>
        /// Inizializza una nuova istanza di ConsoleLogProvider.
        /// Avvia il servizio di system console e configura il formatter ereditato.
        /// </summary>
        /// <param name="systemConsole">L'interfaccia per la gestione della console.</param>
        /// <param name="formatter">Il formatter da utilizzare per formattare le entry di log.</param>
        public ConsoleLogProvider(ISystemConsole systemConsole, ILogFormatter formatter) 
            : base(formatter)
        {
            _systemConsole = systemConsole;
            // Avvia la console al momento dell'inizializzazione,
            // così da preparare l'ambiente per la scrittura dei log.
            _systemConsole.Start();
        }

        /// <summary>
        /// Implementazione del metodo astratto ereditato che si occupa della visualizzazione sincrona del log.
        /// Formattta l'entry di log utilizzando il formatter configurato e invia il testo formattato alla console.
        /// </summary>
        /// <param name="entry">L'entry di log originale.</param>
        /// <param name="formattedText">La stringa formattata ottenuta dal formatter.</param>
        protected override void DisplayLogEntryImplementation(LogEntry entry, string formattedText)
        {
            // Invia il messaggio formattato alla console.
            _systemConsole.WriteLine(formattedText);
        }

        /// <summary>
        /// Libera le risorse gestite dalla classe, in particolare quella associata alla system console.
        /// Chiama il Dispose() della system console e sopprime il finalizzatore.
        /// </summary>
        public void Dispose()
        {
            _systemConsole.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}