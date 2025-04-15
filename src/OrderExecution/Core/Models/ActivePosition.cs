using System;
using System.Collections.Generic;
using OrderCreation;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

public class ActivePosition : IActivePosition
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

    public double GrossProfit { get; }
    public double NetProfit { get; }

    public double Swap { get; }
    public double Commissions { get; }

    public DateTime EntryTime { get; }
    public DateTime? LastUpdateTime { get; }

    public double CurrentPrice { get; }

    public double MarginUsed { get; }

    public IReadOnlyList<ITradeOperation> TradeOperations { get; }

    public ActivePosition(
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
        double grossProfit,
        double netProfit,
        double swap,
        double commissions,
        DateTime entryTime,
        DateTime? lastUpdateTime,
        double currentPrice,
        double marginUsed,
        IReadOnlyList<ITradeOperation> tradeOperations
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
        GrossProfit = grossProfit;
        NetProfit = netProfit;
        Swap = swap;
        Commissions = commissions;
        EntryTime = entryTime;
        LastUpdateTime = lastUpdateTime;
        CurrentPrice = currentPrice;
        MarginUsed = marginUsed;
        TradeOperations = tradeOperations ?? new List<ITradeOperation>();
    }
}
