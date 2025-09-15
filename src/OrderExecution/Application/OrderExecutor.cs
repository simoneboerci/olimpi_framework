using OrderCreation.Core.Interfaces;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Application;

/// <summary>
/// Implementazione dell'interfaccia <see cref="IOrderExecutor"/>.
/// Fornisce i metodi per eseguire ordini di trading di vari tipi (mercato, range, limite, stop, stop-limit),
/// sia in modalità sincrona che asincrona.
/// Ogni metodo deve essere implementato per interagire con il sistema di trading sottostante.
/// </summary>
public class OrderExecutor : IOrderExecutor
{
    //TODO: Implement the order execution logic here

    /// <inheritdoc/>
    public ITradeResult ExecuteMarketOrder(IMarketOrder marketOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeOperation ExecuteMarketOrderAsync(IMarketOrder marketOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeResult ExecuteMarketRangeOrder(IMarketRangeOrder marketRangeOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeOperation ExecuteMarketRangeOrderAsync(IMarketRangeOrder marketRangeOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeResult PlaceLimitOrder(ILimitOrder limitOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeOperation PlaceLimitOrderAsync(ILimitOrder limitOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeResult PlaceStopLimitOrder(IStopLimitOrder stopLimitOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeOperation PlaceStopLimitOrderAsync(IStopLimitOrder stopLimitOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeResult PlaceStopOrder(IStopOrder stopOrder)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    public ITradeOperation PlaceStopOrderAsync(IStopOrder stopOrder)
    {
        throw new System.NotImplementedException();
    }
}