using OrderCreation.Core.Interfaces;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Application;

public class OrderExecutor : IOrderExecutor
{
    //TODO: Implement the order execution logic here

    public ITradeResult ExecuteMarketOrder(IMarketOrder marketOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeOperation ExecuteMarketOrderAsync(IMarketOrder marketOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeResult ExecuteMarketRangeOrder(IMarketRangeOrder marketRangeOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeOperation ExecuteMarketRangeOrderAsync(IMarketRangeOrder marketRangeOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeResult PlaceLimitOrder(ILimitOrder limitOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeOperation PlaceLimitOrderAsync(ILimitOrder limitOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeResult PlaceStopLimitOrder(IStopLimitOrder stopLimitOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeOperation PlaceStopLimitOrderAsync(IStopLimitOrder stopLimitOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeResult PlaceStopOrder(IStopOrder stopOrder)
    {
        throw new System.NotImplementedException();
    }

    public ITradeOperation PlaceStopOrderAsync(IStopOrder stopOrder)
    {
        throw new System.NotImplementedException();
    }
}