using System;
using System.Runtime.InteropServices;
using Logging.Core.Interfaces;
using Logging.Data.Console;

namespace Logging.Core.Factories;

public class SystemConsoleFactory : ISystemConsoleFactory
{
    public ISystemConsole Create()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return new WindowsConsole();
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return new MacOSConsole();
        }   
        else
        {
            throw new NotSupportedException("Sistema operativo non supportato.");
        }
    }
}