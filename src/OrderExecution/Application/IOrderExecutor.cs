using OrderCreation.Core.Interfaces;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Application;

public interface IOrderExecutor
{
    public ITradeResult ExecuteMarketOrder(IMarketOrder marketOrder);
    public ITradeOperation ExecuteMarketOrderAsync(IMarketOrder marketOrder);

    public ITradeResult ExecuteMarketRangeOrder(IMarketRangeOrder marketRangeOrder);
    public ITradeOperation ExecuteMarketRangeOrderAsync(IMarketRangeOrder marketRangeOrder);

    public ITradeResult PlaceLimitOrder(ILimitOrder limitOrder);
    public ITradeOperation PlaceLimitOrderAsync(ILimitOrder limitOrder);

    public ITradeResult PlaceStopOrder(IStopOrder stopOrder);
    public ITradeOperation PlaceStopOrderAsync(IStopOrder stopOrder);

    public ITradeResult PlaceStopLimitOrder(IStopLimitOrder stopLimitOrder);
    public ITradeOperation PlaceStopLimitOrderAsync(IStopLimitOrder stopLimitOrder);
}