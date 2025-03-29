using System;
using System.Diagnostics;
using System.IO;
using ConsoleOperations.Core.Interfaces;

namespace ConsoleOperations.Core.Processes;

/// <summary>
/// Classe che rappresenta il processo per la console su MacOS.
/// Implementa l'interfaccia IProcess per centralizzare la logica di configurazione e avvio del processo
/// che avvia il Terminale per visualizzare in tempo reale il contenuto di un file di log.
/// </summary>
public sealed class MacOSConsoleProcess : IProcess
{
    // In questo scenario, _logFilePath rappresenta il percorso (fisso) della cartella o il nome base del file.
    private readonly string _logFilePath;

    // Nome base dello script shell che verrà creato per eseguire il comando tail sul file di log.
    private readonly string _tailScriptName;

    /// <summary>
    /// Costruttore che inizializza il processo con il percorso (o nome base) del file di log e un nome opzionale per lo script.
    /// </summary>
    /// <param name="logFilePath">Il percorso (o nome base) del file di log.</param>
    /// <param name="tailScriptName">Nome opzionale dello script shell (default "tail.sh").</param>
    public MacOSConsoleProcess(string logFilePath, string tailScriptName = "tail.sh")
    {
        _logFilePath = logFilePath;
        _tailScriptName = tailScriptName;
    }

    /// <summary>
    /// Avvia il processo che configura e lancia il Terminale su MacOS per monitorare il file di log.
    /// Per ogni finestra viene creato un file di log univoco nella stessa cartella; quando la finestra viene chiusa,
    /// il file associato viene eliminato.
    /// </summary>
    /// <returns>L'istanza del processo avviato.</returns>
    public Process Start()
    {
        // Genera un file di log univoco nella stessa cartella.
        // Ad esempio, se _logFilePath = "/tmp/olimpi.log", si genera "/tmp/olimpi_{GUID}.log".
        string directory = Path.GetDirectoryName(_logFilePath);
        if (string.IsNullOrEmpty(directory))
            directory = Path.GetTempPath();
        string baseName = Path.GetFileNameWithoutExtension(_logFilePath);
        string extension = Path.GetExtension(_logFilePath);
        string uniqueLogFile = Path.Combine(directory, $"{baseName}_{Guid.NewGuid()}{extension}");
        
        // Pulisce (crea vuoto) il file di log univoco.
        File.WriteAllText(uniqueLogFile, string.Empty);

        // Genera un file di script univoco all'interno della cartella temporanea.
        // Esempio: "tail_{GUID}.sh"
        string uniqueScriptFile = Path.Combine(Path.GetTempPath(), $"{Path.GetFileNameWithoutExtension(_tailScriptName)}_{Guid.NewGuid()}{Path.GetExtension(_tailScriptName)}");

        // Crea il contenuto dello script shell: esegue il comando tail in modalità "follow" sul file di log univoco.
        string scriptContent = $"#!/bin/bash\n tail -f {uniqueLogFile}";

        // Scrive il contenuto dello script nel file temporaneo.
        File.WriteAllText(uniqueScriptFile, scriptContent);

        // Imposta i permessi eseguibili sul file di script usando il comando "chmod +x".
        Process.Start(new ProcessStartInfo
        {
            FileName = "chmod",
            Arguments = $"+x {uniqueScriptFile}",
            UseShellExecute = false,
            CreateNoWindow = true,
        }).WaitForExit();

        // Configura il ProcessStartInfo per aprire il Terminale ed eseguire lo script.
        var psi = new ProcessStartInfo
        {
            FileName = "open",
            Arguments = $"-a Terminal {uniqueScriptFile}",
            UseShellExecute = false,
        };

        // Avvia il processo e ottiene il riferimento al processo.
        Process process = Process.Start(psi);

        // Se il processo è avviato correttamente, abilita gli eventi per rilevare la chiusura della finestra.
        if (process != null)
        {
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) =>
            {
                try
                {
                    if (File.Exists(uniqueLogFile))
                        File.Delete(uniqueLogFile);
                    if (File.Exists(uniqueScriptFile))
                        File.Delete(uniqueScriptFile);
                }
                catch { }
            };
        }

        return process;
    }
}