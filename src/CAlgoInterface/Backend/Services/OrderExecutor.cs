using System;
using cAlgo.API;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Data;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Services;

public class OrderExecutor : IOrderExecutor
{
    private readonly IExecuteCAlgoOrders _cAlgoOrderExecutor;

    private readonly IOrderMapper<IMarketOrder, CAlgoMarketOrderStruct> _marketOrderMapper;
    private readonly IOrderMapper<IMarketRangeOrder, CAlgoMarketRangeOrderStruct> _marketRangeOrderMapper;
    private readonly IOrderMapper<IStopOrder, CAlgoStopOrderStruct> _stopOrderMapper;
    private readonly IOrderMapper<ILimitOrder, CAlgoLimitOrderStruct> _limitOrderMapper;
    private readonly IOrderMapper<IStopLimitOrder, CAlgoStopLimitOrderStruct> _stopLimitOrderMapper;

    private readonly ITradeResultAdapter _tradeResultAdapter;
    private readonly ITradeOperationAdapter _tradeOperationAdapter;

    public OrderExecutor
    (
        IExecuteCAlgoOrders cAlgoOrderExecutor,
        IOrderMapper<IMarketOrder, CAlgoMarketOrderStruct> marketOrderMapper,
        IOrderMapper<IMarketRangeOrder, CAlgoMarketRangeOrderStruct> marketRangeOrderMapper,
        IOrderMapper<IStopOrder, CAlgoStopOrderStruct> stopOrderMapper,
        IOrderMapper<ILimitOrder, CAlgoLimitOrderStruct> limitOrderMapper,
        IOrderMapper<IStopLimitOrder, CAlgoStopLimitOrderStruct> stopLimitOrderMapper,
        ITradeResultAdapter tradeResultAdapter,
        ITradeOperationAdapter tradeOperationAdapter
    )
    {
        _cAlgoOrderExecutor = cAlgoOrderExecutor;

        _marketOrderMapper = marketOrderMapper;
        _marketRangeOrderMapper = marketRangeOrderMapper;
        _stopOrderMapper = stopOrderMapper;
        _limitOrderMapper = limitOrderMapper;
        _stopLimitOrderMapper = stopLimitOrderMapper;

        _tradeResultAdapter = tradeResultAdapter;
        _tradeOperationAdapter = tradeOperationAdapter;
    }

    public IMarketTradeResult ExecuteMarketOrder(IMarketOrder marketOrder)
    {
        var dto = MapMarketOrder(marketOrder);
        var cAlgoResult = _cAlgoOrderExecutor.ExecuteMarketOrder(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.Label,
            dto.StopLossPips,
            dto.TakeProfitPips,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopTriggerMethod
        );
        return _tradeResultAdapter.ToMarketTradeResult(cAlgoResult);

    }
    public IMarketTradeOperation ExecuteMarketOrderAsync(IMarketOrder marketOrder, Action<IMarketTradeResult> callback = null)
    {
        var dto = MapMarketOrder(marketOrder);
        var cAlgoOperation = _cAlgoOrderExecutor.ExecuteMarketOrderAsync(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.Label,
            dto.StopLossPips,
            dto.TakeProfitPips,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopTriggerMethod,
            tradeResult =>
            {
                var cAlgoResult = _tradeResultAdapter.ToMarketTradeResult(tradeResult);
                callback?.Invoke(cAlgoResult);
            }
        );        
        return _tradeOperationAdapter.ToMarketTradeOperation(cAlgoOperation);
    }

    public IMarketTradeResult ExecuteMarketRangeOrder(IMarketRangeOrder marketRangeOrder)
    {
        var dto = MapMarketRangeOrder(marketRangeOrder);
        var cAlgoResult = _cAlgoOrderExecutor.ExecuteMarketRangeOrder(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.MarketRangePips,
            dto.BasePrice,
            dto.Label,
            dto.StopLossPips,
            dto.TakeProfitPips,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopTriggerMethod
        );
        return _tradeResultAdapter.ToMarketTradeResult(cAlgoResult);
    }
    public IMarketTradeOperation ExecuteMarketRangeOrderAsync(IMarketRangeOrder marketRangeOrder, Action<IMarketTradeResult> callback = null)
    {
        var dto = MapMarketRangeOrder(marketRangeOrder);
        var cAlgoOperation = _cAlgoOrderExecutor.ExecuteMarketRangeOrderAsync(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.MarketRangePips,
            dto.BasePrice,
            dto.Label,
            dto.StopLossPips,
            dto.TakeProfitPips,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopTriggerMethod,
            tradeResult =>
            {
                var cAlgoResult = _tradeResultAdapter.ToMarketTradeResult(tradeResult);
                callback?.Invoke(cAlgoResult);
            }
        );
        return _tradeOperationAdapter.ToMarketTradeOperation(cAlgoOperation);
    }

    public IPendingTradeResult PlaceLimitOrder(ILimitOrder limitOrder)
    {
        var dto = MapLimitOrder(limitOrder);
        var cAlgoResult = _cAlgoOrderExecutor.PlaceLimitOrder(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.TargetPrice,
            dto.Label,
            dto.StopLoss,
            dto.TakeProfit,
            dto.ProtectionType,
            dto.Expiration,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopLossTriggerMethod
        );
        return _tradeResultAdapter.ToPendingTradeResult(cAlgoResult);
    }
    public IPendingTradeOperation PlaceLimitOrderAsync(ILimitOrder limitOrder, Action<IPendingTradeResult> callback = null)
    {
        var dto = MapLimitOrder(limitOrder);
        var cAlgoOperation = _cAlgoOrderExecutor.PlaceLimitOrderAsync(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.TargetPrice,
            dto.Label,
            dto.StopLoss,
            dto.TakeProfit,
            dto.ProtectionType,
            dto.Expiration,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopLossTriggerMethod,
            tradeResult =>
            {
                var cAlgoResult = _tradeResultAdapter.ToPendingTradeResult(tradeResult);
                callback?.Invoke(cAlgoResult);
            }
        );
        return _tradeOperationAdapter.ToPendingTradeOperation(cAlgoOperation);
    }

    public IPendingTradeResult PlaceStopLimitOrder(IStopLimitOrder stopLimitOrder)
    {
        var dto = MapStopLimitOrder(stopLimitOrder);
        var cAlgoResult = _cAlgoOrderExecutor.PlaceStopLimitOrder(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.TargetPrice,
            dto.StopLimitRangePips,
            dto.Label,
            dto.StopLoss,
            dto.TakeProfit,
            dto.ProtectionType,
            dto.Expiration,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopLossTriggerMethod
        );
        return _tradeResultAdapter.ToPendingTradeResult(cAlgoResult);
    }
    public IPendingTradeOperation PlaceStopLimitOrderAsync(IStopLimitOrder stopLimitOrder, Action<IPendingTradeResult> callback = null)
    {
        var dto = MapStopLimitOrder(stopLimitOrder);
        var cAlgoOperation = _cAlgoOrderExecutor.PlaceStopLimitOrderAsync(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.TargetPrice,
            dto.StopLimitRangePips,
            dto.Label,
            dto.StopLoss,
            dto.TakeProfit,
            dto.ProtectionType,
            dto.Expiration,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopLossTriggerMethod,
            tradeResult =>
            {
                var cAlgoResult = _tradeResultAdapter.ToPendingTradeResult(tradeResult);
                callback?.Invoke(cAlgoResult);
            }
        );
        return _tradeOperationAdapter.ToPendingTradeOperation(cAlgoOperation);
    }

    public IPendingTradeResult PlaceStopOrder(IStopOrder stopOrder)
    {
        var dto = MapStopOrder(stopOrder);
        var cAlgoResult = _cAlgoOrderExecutor.PlaceStopOrder(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.TargetPrice,
            dto.Label,
            dto.StopLoss,
            dto.TakeProfit,
            dto.ProtectionType,
            dto.Expiration,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopLossTriggerMethod,
            dto.StopOrderTriggerMethod
        );
        return _tradeResultAdapter.ToPendingTradeResult(cAlgoResult);
    }
    public IPendingTradeOperation PlaceStopOrderAsync(IStopOrder stopOrder, Action<IPendingTradeResult> callback = null)
    {
        var dto = MapStopOrder(stopOrder);
        var cAlgoOperation = _cAlgoOrderExecutor.PlaceStopOrderAsync(
            dto.TradeType,
            dto.SymbolName,
            dto.Volume,
            dto.TargetPrice,
            dto.Label,
            dto.StopLoss,
            dto.TakeProfit,
            dto.ProtectionType,
            dto.Expiration,
            dto.Comment,
            dto.HasTrailingStop,
            dto.StopLossTriggerMethod,
            dto.StopOrderTriggerMethod,
            tradeResult =>
            {
                var cAlgoResult = _tradeResultAdapter.ToPendingTradeResult(tradeResult);
                callback?.Invoke(cAlgoResult);
            }
        );
        return _tradeOperationAdapter.ToPendingTradeOperation(cAlgoOperation);
    }

    private CAlgoMarketOrderStruct MapMarketOrder(IMarketOrder marketOrder) => _marketOrderMapper.Map(marketOrder);
    private CAlgoMarketRangeOrderStruct MapMarketRangeOrder(IMarketRangeOrder marketRangeOrder) => _marketRangeOrderMapper.Map(marketRangeOrder);
    private CAlgoStopOrderStruct MapStopOrder(IStopOrder stopOrder) => _stopOrderMapper.Map(stopOrder);
    private CAlgoLimitOrderStruct MapLimitOrder(ILimitOrder limitOrder) => _limitOrderMapper.Map(limitOrder);
    private CAlgoStopLimitOrderStruct MapStopLimitOrder(IStopLimitOrder stopLimitOrder) => _stopLimitOrderMapper.Map(stopLimitOrder);
}