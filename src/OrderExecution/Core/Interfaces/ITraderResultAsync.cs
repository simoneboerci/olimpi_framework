namespace OrderExecution.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta il risultato asincrono di un'operazione di trading.
/// Espone la proprietà <see cref="TradeResult"/> che contiene il risultato dell'operazione.
/// </summary>
public interface ITradeResultAsync
{
    /// <summary>
    /// Risultato dell'operazione di trading eseguita in modo asincrono.
    /// </summary>
    ITradeResult TradeResult { get; }
}