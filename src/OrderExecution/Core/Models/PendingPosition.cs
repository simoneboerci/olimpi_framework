using System;
using System.Collections.Generic;
using OrderCreation;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

public class PendingPosition : IPendingPosition
{
    public Guid Id { get; }
    public Guid OrderId { get; }
    public Guid SymbolId { get; }

    public TradeType TradeType { get; }

    public double VolumeInUnits { get; }
    public double QuantityInLots { get; }

    public double EntryPrice { get; }

    public double? StopLoss { get; }
    public double? TakeProfit { get; }

    public bool HasTrailingStop { get; }
    public StopTriggerMethod? StopTriggerMethod { get; }

    public DateTime EntryTime { get; }
    public DateTime? LastUpdateTime { get; }

    public IReadOnlyList<ITradeOperation> TradeOperations { get; }

    public PendingPosition(
        Guid id,
        Guid orderId,
        Guid symbolId,
        TradeType tradeType,
        double volumeInUnits,
        double quantityInLots,
        double entryPrice,
        double? stopLoss,
        double? takeProfit,
        bool hasTrailingStop,
        StopTriggerMethod? stopTriggerMethod,
        DateTime entryTime,
        DateTime? lastUpdateTime
    )
    {
        Id = id;
        OrderId = orderId;
        SymbolId = symbolId;
        TradeType = tradeType;
        VolumeInUnits = volumeInUnits;
        QuantityInLots = quantityInLots;
        EntryPrice = entryPrice;
        StopLoss = stopLoss;
        TakeProfit = takeProfit;
        HasTrailingStop = hasTrailingStop;
        StopTriggerMethod = stopTriggerMethod;
        EntryTime = entryTime;
        LastUpdateTime = lastUpdateTime;
    }
}