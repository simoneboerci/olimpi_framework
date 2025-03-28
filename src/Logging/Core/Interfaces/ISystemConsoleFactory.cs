namespace Logging.Core.Interfaces;

/// <summary>
/// Interfaccia per la creazione di istanze di <see cref="ISystemConsole"/>.
/// Fornisce un metodo per ottenere una nuova implementazione concreta di un sistema console.
/// </summary>
public interface ISystemConsoleFactory
{
    /// <summary>
    /// Crea e restituisce una nuova istanza di <see cref="ISystemConsole"/>.
    /// </summary>
    /// <returns>Un'istanza che implementa l'interfaccia <see cref="ISystemConsole"/>.</returns>
    ISystemConsole Create();
}