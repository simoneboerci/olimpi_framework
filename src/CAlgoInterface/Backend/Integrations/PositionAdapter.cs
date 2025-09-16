using System;
using System.Collections.Generic;
using CAlgoInterface.Backend.Services;
using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Integrations;

public class PositionAdapter : IPositionAdapter
{
    private readonly cAlgo.API.Position _cAlgoPosition;

    private readonly ITradeTypeMapper _tradeTypeMapper;
    private readonly IStopTriggerMethodMapper _stopTriggerMethodMapper;

    public PositionAdapter(cAlgo.API.Position cAlgoPosition, ITradeTypeMapper tradeTypeMapper, IStopTriggerMethodMapper stopTriggerMethodMapper)
    {
        _cAlgoPosition = cAlgoPosition;
        _tradeTypeMapper = tradeTypeMapper;
        _stopTriggerMethodMapper = stopTriggerMethodMapper;
    }

    public cAlgo.API.Position GetCAlgoPosition() => _cAlgoPosition;

    public Guid Id => GuidHelper.IntToGuid(_cAlgoPosition.Id);
    public Guid OrderId => GuidHelper.IntToGuid(_cAlgoPosition.Id);
    public Guid SymbolId => GuidHelper.LongToGuid(_cAlgoPosition.Symbol.Id);
    public TradeType TradeType => _tradeTypeMapper.ToTradeType(_cAlgoPosition.TradeType);
    public double VolumeInUnits => _cAlgoPosition.VolumeInUnits;
    public double QuantityInLots => _cAlgoPosition.Quantity;
    public double EntryPrice => _cAlgoPosition.EntryPrice;
    public double? StopLoss => _cAlgoPosition.StopLoss;
    public double? TakeProfit => _cAlgoPosition.TakeProfit;
    public bool HasTrailingStop => _cAlgoPosition.HasTrailingStop;
    public StopTriggerMethod? StopTriggerMethod => _stopTriggerMethodMapper.ToCustomStopTriggerMethod(_cAlgoPosition.StopLossTriggerMethod ?? default);
    public DateTime EntryTime => _cAlgoPosition.EntryTime;
    public DateTime? LastUpdateTime => _cAlgoPosition.LastUpdateTime;
    public IReadOnlyList<ITradeOperation> TradeOperations => throw new NotImplementedException(); //TODO: Implement this 
}