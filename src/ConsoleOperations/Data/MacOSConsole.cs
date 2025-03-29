using System;
using System.IO;
using ConsoleOperations.Core.Interfaces;
using ConsoleOperations.Core.Processes;

namespace ConsoleOperations.Data
{
    /// <summary>
    /// Implementazione di <see cref="ISystemConsole"/> per MacOS.
    /// Questo provider scrive i log in un file temporaneo e utilizza un processo separato per mostrare il contenuto del file in una finestra del terminale.
    /// </summary>
    public class MacOSConsole : SystemConsoleBase
    {
        // Percorso del file di log temporaneo utilizzato per scrivere i messaggi.
        private readonly string _logFilePath = "/tmp/olimpi.log";

        /// <summary>
        /// Avvia il processo per il logging su MacOS.
        /// Crea un file di log temporaneo, genera uno script shell per visualizzare in tempo reale i log,
        /// ne imposta i permessi eseguibili e infine apre il Terminale per eseguire lo script.
        /// </summary>
        public override void Start()
        {
            // Crea un'istanza di MacOSConsoleProcess passando il percorso del file di log.
            var macOSProcess = new MacOSConsoleProcess(_logFilePath);
            // Avvia il processo configurato da MacOSConsoleProcess e assegna l'istanza del processo al campo Process.
            Process = macOSProcess.Start();
        }

        /// <summary>
        /// Scrive una riga di testo nel file di log.
        /// Ogni chiamata a questa funzione aggiunge il testo seguito da una nuova riga.
        /// </summary>
        /// <param name="text">Il testo da aggiungere al file di log.</param>
        public override void WriteLine(string text)
            // Aggiunge il testo passato e una nuova riga al file di log.
            => File.AppendAllText(_logFilePath, text + Environment.NewLine);
    }
}
