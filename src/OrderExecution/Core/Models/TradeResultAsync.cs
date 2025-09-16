using CAlgoInterface.Core.Interfaces;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

/// <summary>
/// Struttura che implementa <see cref="ITradeResultAsync"/> e rappresenta il risultato asincrono di un'operazione di trading.
/// Espone la proprietà <see cref="TradeResult"/> che contiene il risultato dell'operazione.
/// </summary>
public readonly struct TradeResultAsync : ITradeResultAsync
{
    /// <summary>
    /// Risultato dell'operazione di trading eseguita in modo asincrono.
    /// </summary>
    public ITradeResult TradeResult { get; }

    /// <summary>
    /// Costruttore che inizializza la struttura con il risultato dell'operazione.
    /// </summary>
    /// <param name="tradeResult">Risultato dell'operazione di trading.</param>
    public TradeResultAsync(ITradeResult tradeResult)
    {
        TradeResult = tradeResult;
    }
}