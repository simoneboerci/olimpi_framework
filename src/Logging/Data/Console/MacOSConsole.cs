using System;
using System.Diagnostics;
using System.IO;
using Logging.Core.Interfaces;

namespace Logging.Data.Console
{
    /// <summary>
    /// Implementazione di <see cref="ISystemConsole"/> per MacOS.
    /// Questo provider scrive i log in un file temporaneo e utilizza un processo separato per mostrare il contenuto del file in una finestra del terminale.
    /// </summary>
    public class MacOSConsole : ISystemConsole
    {
        /// <summary>
        /// Riferimento al processo del terminale avviato.
        /// </summary>
        private Process _process;
        /// <summary>
        /// Percorso del file di log temporaneo utilizzato per scrivere i messaggi.
        /// </summary>
        private readonly string _logFilePath = "/tmp/olimpi.log";

        /// <summary>
        /// Avvia il processo per il logging su MacOS.
        /// Crea un file di log temporaneo, genera uno script shell per visualizzare in tempo reale i log,
        /// ne imposta i permessi eseguibili e infine apre il Terminale per eseguire lo script.
        /// </summary>
        public void Start()
        {
            // Pulisce il file di log, se già esistente.
            File.WriteAllText(_logFilePath, string.Empty);

            // Crea un file di script temporaneo per visualizzare i log in tempo reale.
            string scriptFile = Path.Combine(Path.GetTempPath(), "tail_olimpi.sh");
            string scriptContent = $"#!/bin/bash\n tail -f {_logFilePath}";
            File.WriteAllText(scriptFile, scriptContent);

            // Imposta i permessi eseguibili sul file di script.
            Process.Start(new ProcessStartInfo
            {
                FileName = "chmod",
                Arguments = $"+x {scriptFile}",
                UseShellExecute = false,
                CreateNoWindow = true,
            }).WaitForExit();

            // Avvia il Terminale per eseguire lo script e mostrare il contenuto aggiornato del file di log.
            var psi = new ProcessStartInfo
            {
                FileName = "open",
                Arguments = $"-a Terminal {scriptFile}",
                UseShellExecute = false,
            };

            _process = Process.Start(psi);
        }

        /// <summary>
        /// Scrive una riga di testo nel file di log.
        /// Ogni chiamata a questa funzione aggiunge il testo seguito da una nuova riga.
        /// </summary>
        /// <param name="text">Il testo da aggiungere al file di log.</param>
        public void WriteLine(string text)
        {
            // Appende il testo al file di log.
            File.AppendAllText(_logFilePath, text + Environment.NewLine);
        }

        /// <summary>
        /// Termina il processo del terminale e libera le risorse associate.
        /// Se il processo è attivo, viene terminato in modo forzato e successivamente smaltito.
        /// </summary>
        public void Dispose()
        {
            if(_process != null && !_process.HasExited)
            {
                try
                {
                    // Tenta di terminare il processo attivo.
                    _process.Kill();
                }
                catch { }
                finally
                {
                    // Libera le risorse occupate dal processo.
                    _process.Dispose();
                }
            }
        }
    }
}