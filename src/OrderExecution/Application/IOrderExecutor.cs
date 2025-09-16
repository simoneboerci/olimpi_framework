using System;
using CAlgoInterface.Core.Interfaces;
using OrderCreation.Core.Interfaces;

namespace OrderExecution.Application;

/// <summary>
/// Interfaccia che definisce i metodi per l'esecuzione di ordini di trading.
/// Supporta ordini di mercato, range, limite, stop e stop-limit, sia in modalità sincrona che asincrona.
/// </summary>
public interface IOrderExecutor
{
    /// <summary>
    /// Esegue un ordine di mercato in modo sincrono.
    /// </summary>
    /// <param name="marketOrder">Ordine di mercato da eseguire.</param>
    /// <returns>Risultato dell'operazione di trading.</returns>
    public ITradeResult ExecuteMarketOrder(IMarketOrder marketOrder);

    /// <summary>
    /// Esegue un ordine di mercato in modo asincrono.
    /// </summary>
    /// <param name="marketOrder">Ordine di mercato da eseguire.</param>
    /// <returns>Operazione di trading asincrona.</returns>
    public ITradeOperation ExecuteMarketOrderAsync(IMarketOrder marketOrder, Action<ITradeResult> callback);

    /// <summary>
    /// Esegue un ordine di mercato con range in modo sincrono.
    /// </summary>
    /// <param name="marketRangeOrder">Ordine di mercato con range da eseguire.</param>
    /// <returns>Risultato dell'operazione di trading.</returns>
    public ITradeResult ExecuteMarketRangeOrder(IMarketRangeOrder marketRangeOrder);

    /// <summary>
    /// Esegue un ordine di mercato con range in modo asincrono.
    /// </summary>
    /// <param name="marketRangeOrder">Ordine di mercato con range da eseguire.</param>
    /// <returns>Operazione di trading asincrona.</returns>
    public ITradeOperation ExecuteMarketRangeOrderAsync(IMarketRangeOrder marketRangeOrder, Action<ITradeResult> callback);

    /// <summary>
    /// Inserisce un ordine limite in modo sincrono.
    /// </summary>
    /// <param name="limitOrder">Ordine limite da inserire.</param>
    /// <returns>Risultato dell'operazione di trading.</returns>
    public ITradeResult PlaceLimitOrder(ILimitOrder limitOrder);

    /// <summary>
    /// Inserisce un ordine limite in modo asincrono.
    /// </summary>
    /// <param name="limitOrder">Ordine limite da inserire.</param>
    /// <returns>Operazione di trading asincrona.</returns>
    public ITradeOperation PlaceLimitOrderAsync(ILimitOrder limitOrder, Action<ITradeResult> callback);

    /// <summary>
    /// Inserisce un ordine stop in modo sincrono.
    /// </summary>
    /// <param name="stopOrder">Ordine stop da inserire.</param>
    /// <returns>Risultato dell'operazione di trading.</returns>
    public ITradeResult PlaceStopOrder(IStopOrder stopOrder);

    /// <summary>
    /// Inserisce un ordine stop in modo asincrono.
    /// </summary>
    /// <param name="stopOrder">Ordine stop da inserire.</param>
    /// <returns>Operazione di trading asincrona.</returns>
    public ITradeOperation PlaceStopOrderAsync(IStopOrder stopOrder, Action<ITradeResult> callback);

    /// <summary>
    /// Inserisce un ordine stop-limit in modo sincrono.
    /// </summary>
    /// <param name="stopLimitOrder">Ordine stop-limit da inserire.</param>
    /// <returns>Risultato dell'operazione di trading.</returns>
    public ITradeResult PlaceStopLimitOrder(IStopLimitOrder stopLimitOrder);

    /// <summary>
    /// Inserisce un ordine stop-limit in modo asincrono.
    /// </summary>
    /// <param name="stopLimitOrder">Ordine stop-limit da inserire.</param>
    /// <returns>Operazione di trading asincrona.</returns>
    public ITradeOperation PlaceStopLimitOrderAsync(IStopLimitOrder stopLimitOrder, Action<ITradeResult> callback);
}