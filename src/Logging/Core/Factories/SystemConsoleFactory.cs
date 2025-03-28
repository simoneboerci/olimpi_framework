using System;
using System.Runtime.InteropServices;
using Logging.Core.Interfaces;
using Logging.Data.Console;

namespace Logging.Core.Factories;

/// <summary>
/// Classe SystemConsoleFactory che implementa l'interfaccia <see cref="ISystemConsoleFactory"/>.
/// Responsabile della creazione di un'istanza concreta di <see cref="ISystemConsole"/> in base al sistema operativo in uso.
/// </summary>
public class SystemConsoleFactory : ISystemConsoleFactory
{
    /// <summary>
    /// Crea e restituisce una nuova istanza di <see cref="ISystemConsole"/> a seconda del sistema operativo.
    /// Se il sistema operativo è Windows viene restituita un'istanza di <see cref="WindowsConsole"/>.
    /// Se il sistema operativo è MacOS (OSX) viene restituita un'istanza di <see cref="MacOSConsole"/>.
    /// In caso di sistema operativo non supportato viene sollevata una NotSupportedException.
    /// </summary>
    /// <returns>Un'istanza di <see cref="ISystemConsole"/> adeguata al sistema operativo.</returns>
    public ISystemConsole Create()
    {
        // Verifica se il sistema operativo in uso è Windows.
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return new WindowsConsole();
        }
        // Verifica se il sistema operativo in uso è OSX.
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return new MacOSConsole();
        }   
        else
        {
            // Se il sistema operativo non è supportato, viene sollevata un'eccezione.
            throw new NotSupportedException("Sistema operativo non supportato.");
        }
    }
}