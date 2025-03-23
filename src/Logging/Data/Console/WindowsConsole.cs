using System.Diagnostics;
using Logging.Core.Interfaces;

namespace Logging.Data.Console;

public class WindowsConsole : ISystemConsole
{
    private Process _process;

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

        _process = Process.Start(psi);
    }

    public void WriteLine(string text)
    {
        if(_process != null && !_process.HasExited)
        {
            if (_process.StandardInput.BaseStream.CanWrite)
            {
                _process.StandardInput.WriteLine($"echo {text}");
            }
        }
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