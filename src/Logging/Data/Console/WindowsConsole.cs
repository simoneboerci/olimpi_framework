using System.Diagnostics;
using Logging.Core.Interfaces;

namespace Logging.Data.Console;

/// <summary>
/// Implementazione di <see cref="ISystemConsole"/> per la gestione della console di Windows tramite cmd.exe.
/// Avvia un processo cmd.exe e scrive i messaggi sulla console utilizzando il comando "echo".
/// </summary>
public class WindowsConsole : ISystemConsole
{
    /// <summary>
    /// Riferimento al processo cmd.exe avviato.
    /// </summary>
    private Process _process;

    /// <summary>
    /// Avvia il processo della console (cmd.exe) con le impostazioni specificate.
    /// Configura il processo per non utilizzare ShellExecute, reindirizzare lo standard input
    /// e mostrare la finestra della console.
    /// </summary>
    public void Start()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/k",
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = false,
            CreateNoWindow = false,
        };

        // Avvia il processo cmd.exe e ne memorizza il riferimento.
        _process = Process.Start(psi);
    }

    /// <summary>
    /// Scrive una riga di testo sulla console.
    /// Se il processo è attivo e il flusso di input standard è scrivibile,
    /// invia il comando "echo" seguito dal testo specificato.
    /// </summary>
    /// <param name="text">Il testo da scrivere sulla console.</param>
    public void WriteLine(string text)
    {
        if (_process != null && !_process.HasExited)
        {
            if (_process.StandardInput.BaseStream.CanWrite)
            {
                // Scrive il comando "echo" seguito dal testo nella console.
                _process.StandardInput.WriteLine($"echo {text}");
            }
        }
    }

    /// <summary>
    /// Termina il processo della console e libera le risorse associate.
    /// Se il processo è attivo, tenta di terminarlo forzatamente e successivamente lo smaltisce.
    /// </summary>
    public void Dispose()
    {
        if (_process != null && !_process.HasExited)
        {
            try
            {
                // Tenta di terminare il processo.
                _process.Kill();
            }
            catch { }
            finally
            {
                // Smaltisce il processo per liberare le risorse.
                _process.Dispose();
            }
        }
    }
}