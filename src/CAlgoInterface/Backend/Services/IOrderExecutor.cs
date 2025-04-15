using System;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Services;

public interface IOrderExecutor
{
    IMarketTradeResult ExecuteMarketOrder(IMarketOrder marketOrder);
    IMarketTradeOperation ExecuteMarketOrderAsync(IMarketOrder marketOrder, Action<IMarketTradeResult> callback = null);

    IMarketTradeResult ExecuteMarketRangeOrder(IMarketRangeOrder marketRangeOrder);
    IMarketTradeOperation ExecuteMarketRangeOrderAsync(IMarketRangeOrder marketRangeOrder, Action<IMarketTradeResult> callback = null);

    IPendingTradeResult PlaceStopOrder(IStopOrder stopOrder);
    IPendingTradeOperation PlaceStopOrderAsync(IStopOrder stopOrder, Action<IPendingTradeResult> callback = null);

    IPendingTradeResult PlaceLimitOrder(ILimitOrder limitOrder);
    IPendingTradeOperation PlaceLimitOrderAsync(ILimitOrder limitOrder, Action<IPendingTradeResult> callback = null);

    IPendingTradeResult PlaceStopLimitOrder(IStopLimitOrder stopLimitOrder);
    IPendingTradeOperation PlaceStopLimitOrderAsync(IStopLimitOrder stopLimitOrder, Action<IPendingTradeResult> callback = null);
}