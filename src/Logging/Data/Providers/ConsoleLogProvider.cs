using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    // La classe ConsoleLogProvider gestisce il logging in console.
    // Estende BaseLogProvider per utilizzare un formatter comune e implementa i metodi sincrono e asincrono per la scrittura dei log.
    public class ConsoleLogProvider : BaseLogProvider
    {
        private Process _terminalProcess;
        private readonly string _logFilePath = "/tmp/olimpi.log";

        // Costruttore che inizializza il provider con il formatter specificato.
        public ConsoleLogProvider(ILogFormatter formatter) : base(formatter)
        {
            File.WriteAllText(_logFilePath, string.Empty);
            StartTail();
        }

        private void StartTail()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/k",
                    UseShellExecute = false,          // Necessario per poter redirigere l'input 
                    RedirectStandardInput = true,     // Per poter inviare comandi a cmd.exe
                    RedirectStandardOutput = false,
                    CreateNoWindow = false,
                };
                _terminalProcess = Process.Start(psi);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Creiamo uno script temporaneo che esegue tail -f sul file di log
                string scriptFile = Path.Combine(Path.GetTempPath(), "tail_olimpi.sh");
                string scriptContent = $"#!/bin/bash\n tail -f {_logFilePath}";
                File.WriteAllText(scriptFile, scriptContent);

                // Rende lo script eseguibile
                Process.Start(new ProcessStartInfo
                {
                    FileName = "chmod",
                    Arguments = $"+x {scriptFile}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }).WaitForExit();

                // Apriamo il Terminal e facciamo eseguire il nostro script
                var psi = new ProcessStartInfo
                {
                    FileName = "open",
                    Arguments = $"-a Terminal {scriptFile}",
                    UseShellExecute = true,
                };
                Process.Start(psi);
            }
            else
            {
                throw new PlatformNotSupportedException("Sistema operativo non supportato per l'apertura del terminale.");
            }
        }

        // Metodo sincrono che scrive una voce di log sulla console.
        // Utilizza il formatter ereditato per formattare l'entry prima di stamparla.
        
        public override void Write(LogEntry entry)
        {
            string formatted = FormatLogEntry(entry);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Invia il comando al terminale attivo (cmd.exe)
                if (_terminalProcess != null && !_terminalProcess.HasExited)
                {
                    using (var writer = _terminalProcess.StandardInput)
                    {
                        if (writer.BaseStream.CanWrite)
                        {
                            writer.WriteLine($"echo {formatted}");
                        }
                    }
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Su macOS, non esiste un canale diretto per scrivere sul Terminal aperto.
                // Qui conviene usare l'approccio tail: scrivere il log in un file che tail -f monitorerà.
                File.AppendAllText(_logFilePath, formatted + Environment.NewLine);
            }
            else
            {
                Console.WriteLine(formatted);
            }
        }

        // Metodo asincrono per scrivere una voce di log sulla console.
        // Esegue il metodo Write in un Task separato in modo asincrono.
        // Se viene passato un callback, lo invoca al termine dell'operazione.
        public override Task WriteAsync(LogEntry entry, Action callback = null)
        {
            return Task.Run(() =>
            {
                Write(entry);          // Chiama il metodo sincrono per scrivere il log
                callback?.Invoke();    // Invoca il callback se presente
            });
        }
    }
}