using System.Runtime.InteropServices;
using ConsoleOperations.Core.Errors;
using ConsoleOperations.Core.Interfaces;
using ConsoleOperations.Data;

namespace ConsoleOperations.Core
{
    /// <summary>
    /// Classe SystemConsoleFactory che implementa l'interfaccia <see cref="ISystemConsoleFactory"/>.
    /// È responsabile della creazione di un'istanza concreta di <see cref="ISystemConsole"/> in base al sistema operativo in uso.
    /// </summary>
    public class SystemConsoleFactory : ISystemConsoleFactory
    {
        /// <summary>
        /// Crea e restituisce una nuova istanza di <see cref="ISystemConsole"/> a seconda del sistema operativo.
        /// Se il sistema operativo è Windows viene restituita un'istanza di <see cref="WindowsConsole"/>.
        /// Se il sistema operativo è MacOS (OSX) viene restituita un'istanza di <see cref="MacOSConsole"/>.
        /// In caso di sistema operativo non supportato viene sollevata una PlatformNotSupportedException.
        /// </summary>
        /// <returns>Un'istanza di <see cref="ISystemConsole"/> adeguata al sistema operativo.</returns>
        public ISystemConsole CreateSystemConsoleBasedOnPlatoform()
        {
            // Verifica se il sistema operativo in uso è Windows.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return new WindowsConsole();
            // Verifica se il sistema operativo in uso è MacOS (OSX).
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return new MacOSConsole();
            // Se il sistema operativo non è supportato, solleva un'eccezione.
            else 
                throw new PlatformNotSupportedException("Sistema operativo non supportato.");
        }
    }
}