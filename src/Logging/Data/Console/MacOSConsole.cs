using System;
using System.Diagnostics;
using System.IO;
using Logging.Core.Interfaces;

namespace Logging.Data.Console;

public class MacOSConsole : ISystemConsole
{
    private Process _process;
    private readonly string _logFilePath = "/tmp/olimpi.log";

    public void Start()
    {
        File.WriteAllText(_logFilePath, string.Empty);

        string scriptFile = Path.Combine(Path.GetTempPath(), "tail_olimpi.sh");
        string scriptContent = $"#!/bin/bash\n tail -f {_logFilePath}";
        File.WriteAllText(scriptFile, scriptContent);

        Process.Start(new ProcessStartInfo
        {
            FileName = "chmod",
            Arguments = $"+x {scriptFile}",
            UseShellExecute = false,
            CreateNoWindow = true,
        }).WaitForExit();

        var psi = new ProcessStartInfo
        {
            FileName = "open",
            Arguments = $"-a Terminal {scriptFile}",
            UseShellExecute = false,
        };

        _process = Process.Start(psi);
    }

    public void WriteLine(string text)
    { 
        File.AppendAllText(_logFilePath, text + Environment.NewLine);
    }

    public void Dispose()
    {
        if(_process != null && !_process.HasExited)
        {
            try
            {
                _process.Kill();
            }
            catch {}
            finally
            {
                _process.Dispose();
            }
        }
    }
}