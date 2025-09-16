using System;
using CAlgoInterface.Application;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;
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
    private readonly ICAlgoOrderExecutor _cAlgoOrderExecutor;

    private readonly ITradeTypeMapper _tradeTypeMapper;
    private readonly IStopTriggerMethodMapper _stopLossTriggerMethodMapper;
    private readonly IProtectionTypeMapper _protectionTypeMapper;

    public OrderExecutor(
        ICAlgoOrderExecutor cAlgoOrderExecutor,
        ITradeTypeMapper tradeTypeMapper,
        IStopTriggerMethodMapper stopLossTriggerMethodMapper,
        IProtectionTypeMapper protectionTypeMapper
    )
    {
        _cAlgoOrderExecutor = cAlgoOrderExecutor;
        _tradeTypeMapper = tradeTypeMapper;
        _stopLossTriggerMethodMapper = stopLossTriggerMethodMapper;
        _protectionTypeMapper = protectionTypeMapper;
    }

    /// <inheritdoc/>
    public ITradeResult ExecuteMarketOrder(IMarketOrder marketOrder)
    {
        var cAlgoTradeResult = _cAlgoOrderExecutor.ExecuteMarketOrder(
            _tradeTypeMapper.ToCAlgoTradeType(marketOrder.TradeType),
            marketOrder.SymbolName,
            marketOrder.Volume,
            marketOrder.Label,
            marketOrder.StopLossPips,
            marketOrder.TakeProfitPips,
            marketOrder.Comment,
            marketOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(marketOrder.StopLossTriggerMethod ?? default)
        );

        return ConvertTradeResult(cAlgoTradeResult);
    }

    /// <inheritdoc/>
    public ITradeOperation ExecuteMarketOrderAsync(IMarketOrder marketOrder, Action<ITradeResult> callback)
    {
        var cAlgoTradeOperation = _cAlgoOrderExecutor.ExecuteMarketOrderAsync(
            _tradeTypeMapper.ToCAlgoTradeType(marketOrder.TradeType),
            marketOrder.SymbolName,
            marketOrder.Volume,
            marketOrder.Label,
            marketOrder.StopLossPips,
            marketOrder.TakeProfitPips,
            marketOrder.Comment,
            marketOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(marketOrder.StopLossTriggerMethod ?? default),
            (cAlgoTradeResult) =>
            {
                var tradeResult = ConvertTradeResult(cAlgoTradeResult);
                callback.Invoke(tradeResult);
            }
        );

        return ConvertTradeOperation(cAlgoTradeOperation);
    }

    /// <inheritdoc/>
    public ITradeResult ExecuteMarketRangeOrder(IMarketRangeOrder marketRangeOrder)
    {
        var cAlgoTradeResult = _cAlgoOrderExecutor.ExecuteMarketRangeOrder(
            _tradeTypeMapper.ToCAlgoTradeType(marketRangeOrder.TradeType),
            marketRangeOrder.SymbolName,
            marketRangeOrder.Volume,
            marketRangeOrder.MarketRangePips,
            marketRangeOrder.BasePrice,
            marketRangeOrder.Label,
            marketRangeOrder.StopLossPips,
            marketRangeOrder.TakeProfitPips,
            marketRangeOrder.Comment,
            marketRangeOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(marketRangeOrder.StopLossTriggerMethod ?? default)
        );

        return ConvertTradeResult(cAlgoTradeResult);
    }

    /// <inheritdoc/>
    public ITradeOperation ExecuteMarketRangeOrderAsync(IMarketRangeOrder marketRangeOrder, Action<ITradeResult> callback)
    {
        var cAlgoTradeOperation = _cAlgoOrderExecutor.ExecuteMarketRangeOrderAsync(
            _tradeTypeMapper.ToCAlgoTradeType(marketRangeOrder.TradeType),
            marketRangeOrder.SymbolName,
            marketRangeOrder.Volume,
            marketRangeOrder.MarketRangePips,
            marketRangeOrder.BasePrice,
            marketRangeOrder.Label,
            marketRangeOrder.StopLossPips,
            marketRangeOrder.TakeProfitPips,
            marketRangeOrder.Comment,
            marketRangeOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(marketRangeOrder.StopLossTriggerMethod ?? default),
            (cAlgoTradeResult) =>
            {
                var tradeResult = ConvertTradeResult(cAlgoTradeResult);
                callback.Invoke(tradeResult);
            }
        );

        return ConvertTradeOperation(cAlgoTradeOperation);
    }

    /// <inheritdoc/>
    public ITradeResult PlaceLimitOrder(ILimitOrder limitOrder)
    {
        var cAlgoTradeResult = _cAlgoOrderExecutor.PlaceLimitOrder(
            _tradeTypeMapper.ToCAlgoTradeType(limitOrder.TradeType),
            limitOrder.SymbolName,
            limitOrder.Volume,
            limitOrder.TargetPrice,
            limitOrder.Label,
            limitOrder.StopLossPips,
            limitOrder.TakeProfitPips,
            _protectionTypeMapper.ToCAlgoProtectionType(limitOrder.ProtectionType ?? default),
            limitOrder.ExpirationTime,
            limitOrder.Comment,
            limitOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(limitOrder.StopLossTriggerMethod ?? default)
        );

        return ConvertTradeResult(cAlgoTradeResult);
    }

    /// <inheritdoc/>
    public ITradeOperation PlaceLimitOrderAsync(ILimitOrder limitOrder, Action<ITradeResult> callback)
    {
        var cAlgoTradeOperation = _cAlgoOrderExecutor.PlaceLimitOrderAsync(
            _tradeTypeMapper.ToCAlgoTradeType(limitOrder.TradeType),
            limitOrder.SymbolName,
            limitOrder.Volume,
            limitOrder.TargetPrice,
            limitOrder.Label,
            limitOrder.StopLossPips,
            limitOrder.TakeProfitPips,
            _protectionTypeMapper.ToCAlgoProtectionType(limitOrder.ProtectionType ?? default),
            limitOrder.ExpirationTime,
            limitOrder.Comment,
            limitOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(limitOrder.StopLossTriggerMethod ?? default),
            (cAlgoTradeResult) =>
            {
                var tradeResult = ConvertTradeResult(cAlgoTradeResult);
                callback.Invoke(tradeResult);
            }
        );

        return ConvertTradeOperation(cAlgoTradeOperation);
    }

    /// <inheritdoc/>
    public ITradeResult PlaceStopLimitOrder(IStopLimitOrder stopLimitOrder)
    {
        var cAlgoTradeResult = _cAlgoOrderExecutor.PlaceStopLimitOrder(
            _tradeTypeMapper.ToCAlgoTradeType(stopLimitOrder.TradeType),
            stopLimitOrder.SymbolName,
            stopLimitOrder.Volume,
            stopLimitOrder.TargetPrice,
            stopLimitOrder.StopLimitRangePips,
            stopLimitOrder.Label,
            stopLimitOrder.StopLossPips,
            stopLimitOrder.TakeProfitPips,
            _protectionTypeMapper.ToCAlgoProtectionType(stopLimitOrder.ProtectionType ?? default),
            stopLimitOrder.ExpirationTime,
            stopLimitOrder.Comment,
            stopLimitOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(stopLimitOrder.StopLossTriggerMethod ?? default),
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(stopLimitOrder.StopOrderTriggerMethod ?? default)
        );

        return ConvertTradeResult(cAlgoTradeResult);
    }

    /// <inheritdoc/>
    public ITradeOperation PlaceStopLimitOrderAsync(IStopLimitOrder stopLimitOrder, Action<ITradeResult> callback)
    {
        var cAlgoTradeOperation = _cAlgoOrderExecutor.PlaceStopLimitOrderAsync(
            _tradeTypeMapper.ToCAlgoTradeType(stopLimitOrder.TradeType),
            stopLimitOrder.SymbolName,
            stopLimitOrder.Volume,
            stopLimitOrder.TargetPrice,
            stopLimitOrder.StopLimitRangePips,
            stopLimitOrder.Label,
            stopLimitOrder.StopLossPips,
            stopLimitOrder.TakeProfitPips,
            _protectionTypeMapper.ToCAlgoProtectionType(stopLimitOrder.ProtectionType ?? default),
            stopLimitOrder.ExpirationTime,
            stopLimitOrder.Comment,
            stopLimitOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(stopLimitOrder.StopLossTriggerMethod ?? default),
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(stopLimitOrder.StopOrderTriggerMethod ?? default),
            (cAlgoTradeResult) =>
            {
                var tradeResult = ConvertTradeResult(cAlgoTradeResult);
                callback.Invoke(tradeResult);
            }
        );

        return ConvertTradeOperation(cAlgoTradeOperation);
    }

    /// <inheritdoc/>
    public ITradeResult PlaceStopOrder(IStopOrder stopOrder)
    {
        var cAlgoTradeResult = _cAlgoOrderExecutor.PlaceLimitOrder(
            _tradeTypeMapper.ToCAlgoTradeType(stopOrder.TradeType),
            stopOrder.SymbolName,
            stopOrder.Volume,
            stopOrder.TargetPrice,
            stopOrder.Label,
            stopOrder.StopLossPips,
            stopOrder.TakeProfitPips,
            _protectionTypeMapper.ToCAlgoProtectionType(stopOrder.ProtectionType ?? default),
            stopOrder.ExpirationTime,
            stopOrder.Comment,
            stopOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(stopOrder.StopLossTriggerMethod ?? default)
        );

        return ConvertTradeResult(cAlgoTradeResult);
    }

    /// <inheritdoc/>
    public ITradeOperation PlaceStopOrderAsync(IStopOrder stopOrder, Action<ITradeResult> callback)
    {
        var cAlgoTradeOperation = _cAlgoOrderExecutor.PlaceLimitOrderAsync(
            _tradeTypeMapper.ToCAlgoTradeType(stopOrder.TradeType),
            stopOrder.SymbolName,
            stopOrder.Volume,
            stopOrder.TargetPrice,
            stopOrder.Label,
            stopOrder.StopLossPips,
            stopOrder.TakeProfitPips,
            _protectionTypeMapper.ToCAlgoProtectionType(stopOrder.ProtectionType ?? default),
            stopOrder.ExpirationTime,
            stopOrder.Comment,
            stopOrder.HasTrailingStop,
            _stopLossTriggerMethodMapper.ToCAlgoStopTriggerMethod(stopOrder.StopLossTriggerMethod ?? default),
            (cAlgoTradeResult) =>
            {
                var tradeResult = ConvertTradeResult(cAlgoTradeResult);
                callback.Invoke(tradeResult);
            }
        );

        return ConvertTradeOperation(cAlgoTradeOperation);
    }

    private ITradeResult ConvertTradeResult(cAlgo.API.TradeResult cAlgoTradeResult)
    {
        var positionAdapter = new PositionAdapter(cAlgoTradeResult.Position, _tradeTypeMapper, _stopLossTriggerMethodMapper);
        return new TradeResultAdapter(cAlgoTradeResult, positionAdapter);
    }

    private ITradeOperation ConvertTradeOperation(cAlgo.API.TradeOperation cAlgoTradeOperation)
    {
        return new TradeOperationAdapter(cAlgoTradeOperation);
    }
}