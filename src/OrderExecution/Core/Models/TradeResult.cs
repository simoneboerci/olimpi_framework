using CAlgoInterface.Core.Interfaces;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

/// <summary>
/// Struttura che implementa <see cref="ITradeResult"/> e rappresenta il risultato di un'operazione di trading.
/// Espone la posizione risultante dall'operazione.
/// </summary>
public readonly struct TradeResult : ITradeResult
{
    /// <summary>
    /// Posizione risultante dall'operazione di trading.
    /// </summary>
    public IPosition Position { get; }

    /// <summary>
    /// Costruttore che inizializza la struttura con la posizione risultante.
    /// </summary>
    /// <param name="position">Posizione risultante dall'operazione di trading.</param>
    public TradeResult(IPosition position)
    {
        Position = position;
    } 
}