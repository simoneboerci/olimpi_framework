using System.Diagnostics;
using ConsoleOperations.Core.Interfaces;

namespace ConsoleOperations.Core.Processes;

/// <summary>
/// Classe che rappresenta il processo per la console su Windows.
/// Implementa l'interfaccia IProcess per centralizzare la logica di configurazione e avvio del processo,
/// in questo caso il prompt dei comandi (cmd.exe).
/// </summary>
public sealed class WindowsConsoleProcess : IProcess
{
    /// <summary>
    /// Configura ed avvia il processo cmd.exe.
    /// Viene impostato l'uso di ShellExecute a false, in modo da poter reindirizzare lo standard input,
    /// e viene visualizzata la finestra della console.
    /// </summary>
    /// <returns>L'istanza del processo cmd.exe avviato.</returns>
    public Process Start()
    {
        // Definisce le impostazioni per l'avvio del processo cmd.exe.
        var psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",                      // Nome del comando da eseguire.
            Arguments = "/k",                          // Argomento per mantenere aperta la finestra dopo l'esecuzione.
            UseShellExecute = false,                   // Necessario per poter reindirizzare lo standard input.
            RedirectStandardInput = true,              // Consente di scrivere comandi sul processo.
            RedirectStandardOutput = false,            // Non reindirizziamo l'output standard.
            CreateNoWindow = false,                      // Mostra la finestra della console.
        };

        // Avvia il processo cmd.exe con le impostazioni specificate e ne restituisce il riferimento.
        return Process.Start(psi);
    }
}