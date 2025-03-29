using System.Diagnostics;
using ConsoleOperations.Core.Interfaces;
using ConsoleOperations.Core.Processes;

namespace ConsoleOperations.Data
{
    /// <summary>
    /// Implementazione di <see cref="ISystemConsole"/> per la gestione della console di Windows tramite cmd.exe.
    /// Avvia un processo cmd.exe e scrive i messaggi sulla console utilizzando il comando "echo".
    /// </summary>
    public class WindowsConsole : SystemConsoleBase
    {
        /// <summary>
        /// Avvia il processo della console (cmd.exe) con le impostazioni specificate.
        /// Configura il processo per non utilizzare ShellExecute, reindirizzare lo standard input
        /// e mostrare la finestra della console.
        /// </summary>
        public override void Start()
        {
            // Crea un'istanza di WindowsConsoleProcess che si occupa di configurare e avviare il processo cmd.exe.
            var windowsProcess = new WindowsConsoleProcess();
            // Avvia il processo cmd.exe via WindowsConsoleProcess e assegna il processo avviato alla proprietà Process.
            Process = windowsProcess.Start();
        }

        /// <summary>
        /// Scrive una riga di testo sulla console.
        /// Se il processo è attivo e il flusso di input standard è scrivibile,
        /// invia il comando "echo" seguito dal testo specificato.
        /// </summary>
        /// <param name="text">Il testo da scrivere sulla console.</param>
        public override void WriteLine(string text)
        {
            // Verifica se il processo è stato avviato ed è ancora in esecuzione.
            if (Process != null && !Process.HasExited)
            {
                // Controlla se lo stream di input standard del processo è disponibile per la scrittura.
                if (Process.StandardInput.BaseStream.CanWrite)
                {
                    // Invia il comando "echo" seguito dal testo da visualizzare nella console.
                    Process.StandardInput.WriteLine($"echo {text}");
                }
            }
        }
    }
}