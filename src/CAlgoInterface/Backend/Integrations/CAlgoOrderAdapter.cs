using CAlgoInterface.Core.Data;
using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Integrations;

public class CAlgoOrderAdapter : ICAlgoOrderAdapter
{
    private readonly ITradeTypeMapper _tradeTypeMapper;
    private readonly IProtectionTypeMapper _protectionTypeMapper;
    private readonly IStopTriggerMethodMapper _stopTriggerMethodMapper;

    public CAlgoOrderAdapter(
        ITradeTypeMapper tradeTypeMapper,
        IProtectionTypeMapper protectionTypeMapper,
        IStopTriggerMethodMapper stopTriggerMethodMapper)
    {
        _tradeTypeMapper = tradeTypeMapper;
        _protectionTypeMapper = protectionTypeMapper;
        _stopTriggerMethodMapper = stopTriggerMethodMapper;
    }

    public CAlgoMarketOrderStruct ToCAlgoMarketOrder(IMarketOrder marketOrder)
    {
        var cAlgoTradeType = _tradeTypeMapper.ToCAlgoTradeType(marketOrder.TradeType);
        var cAlgoStopTriggerMethod = _stopTriggerMethodMapper.ToCAlgoStopTriggerMethod((StopTriggerMethod)marketOrder.StopLossTriggerMethod);

        return new CAlgoMarketOrderStruct(
            cAlgoTradeType,
            marketOrder.SymbolName,
            marketOrder.Volume,
            marketOrder.Label,
            marketOrder.StopLossPips,
            marketOrder.TakeProfitPips,
            marketOrder.Comment,
            marketOrder.HasTrailingStop,
            cAlgoStopTriggerMethod
        );
    }

    public CAlgoMarketRangeOrderStruct ToCAlgoMarketRangeOrder(IMarketRangeOrder marketRangeOrder)
    {
        var cAlgoTradeType = _tradeTypeMapper.ToCAlgoTradeType(marketRangeOrder.TradeType);
        var cAlgoStopTriggerMethod = _stopTriggerMethodMapper.ToCAlgoStopTriggerMethod((StopTriggerMethod)marketRangeOrder.StopLossTriggerMethod);

        return new CAlgoMarketRangeOrderStruct(
            cAlgoTradeType,
            marketRangeOrder.SymbolName,
            marketRangeOrder.Volume,
            marketRangeOrder.MarketRangePips,
            marketRangeOrder.BasePrice,
            marketRangeOrder.Label,
            marketRangeOrder.StopLossPips,
            marketRangeOrder.TakeProfitPips,
            marketRangeOrder.Comment,
            marketRangeOrder.HasTrailingStop,
            cAlgoStopTriggerMethod
        );
    }

    public CAlgoLimitOrderStruct ToCAlgoLimitOrder(ILimitOrder limitOrder)
    {
        var cAlgoTradeType = _tradeTypeMapper.ToCAlgoTradeType(limitOrder.TradeType);
        var cAlgoProtectionType = _protectionTypeMapper.ToCAlgoProtectionType((ProtectionType)limitOrder.ProtectionType);
        var cAlgoStopLossTriggerMethod = _stopTriggerMethodMapper.ToCAlgoStopTriggerMethod((StopTriggerMethod)limitOrder.StopLossTriggerMethod);

        return new CAlgoLimitOrderStruct(
            cAlgoTradeType,
            limitOrder.SymbolName,
            limitOrder.Volume,
            limitOrder.TargetPrice,
            limitOrder.Label,
            limitOrder.StopLossPips,
            limitOrder.TakeProfitPips,
            cAlgoProtectionType,
            limitOrder.ExpirationTime,
            limitOrder.Comment,
            limitOrder.HasTrailingStop,
            cAlgoStopLossTriggerMethod
        );
    }

    public CAlgoStopOrderStruct ToCAlgoStopOrder(IStopOrder stopOrder)
    {
        var cAlgoTradeType = _tradeTypeMapper.ToCAlgoTradeType(stopOrder.TradeType);
        var cAlgoProtectionType = _protectionTypeMapper.ToCAlgoProtectionType((ProtectionType)stopOrder.ProtectionType);
        var cAlgoStopLossTriggerMethod = _stopTriggerMethodMapper.ToCAlgoStopTriggerMethod((StopTriggerMethod)stopOrder.StopLossTriggerMethod);
        var cAlgoStopOrderTriggerMethod = _stopTriggerMethodMapper.ToCAlgoStopTriggerMethod((StopTriggerMethod)stopOrder.StopOrderTriggerMethod);

        return new CAlgoStopOrderStruct(
            cAlgoTradeType,
            stopOrder.SymbolName,
            stopOrder.Volume,
            stopOrder.TargetPrice,
            stopOrder.Label,
            stopOrder.StopLossPips,
            stopOrder.TakeProfitPips,
            cAlgoProtectionType,
            stopOrder.ExpirationTime,
            stopOrder.Comment,
            stopOrder.HasTrailingStop,
            cAlgoStopLossTriggerMethod,
            cAlgoStopOrderTriggerMethod
        );
    }

    public CAlgoStopLimitOrderStruct ToCAlgoStopLimitOrder(IStopLimitOrder stopLimitOrder)
    {
        var cAlgoTradeType = _tradeTypeMapper.ToCAlgoTradeType(stopLimitOrder.TradeType);
        var cAlgoProtectionType = _protectionTypeMapper.ToCAlgoProtectionType((ProtectionType)stopLimitOrder.ProtectionType);
        var cAlgoStopLossTriggerMethod = _stopTriggerMethodMapper.ToCAlgoStopTriggerMethod((StopTriggerMethod)stopLimitOrder.StopLossTriggerMethod);
        var cAlgoStopOrderTriggerMethod = _stopTriggerMethodMapper.ToCAlgoStopTriggerMethod((StopTriggerMethod)stopLimitOrder.StopOrderTriggerMethod);

        return new CAlgoStopLimitOrderStruct(
            cAlgoTradeType,
            stopLimitOrder.SymbolName,
            stopLimitOrder.Volume,
            stopLimitOrder.TargetPrice,
            stopLimitOrder.StopLimitRangePips,
            stopLimitOrder.Label,
            stopLimitOrder.StopLossPips,
            stopLimitOrder.TakeProfitPips,
            cAlgoProtectionType,
            stopLimitOrder.ExpirationTime,
            stopLimitOrder.Comment,
            stopLimitOrder.HasTrailingStop,
            cAlgoStopLossTriggerMethod,
            cAlgoStopOrderTriggerMethod
        );
    }
}