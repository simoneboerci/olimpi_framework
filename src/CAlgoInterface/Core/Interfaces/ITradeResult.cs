namespace CAlgoInterface.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta il risultato di un'operazione di trading.
/// Espone la posizione risultante dall'operazione.
/// </summary>
public interface ITradeResult
{
    /// <summary>
    /// Posizione risultante dall'operazione di trading.
    /// </summary>
    IPosition Position { get; }
}