using System;
using System.Collections.Generic;
using OrderCreation;

namespace OrderExecution.Core.Interfaces;

public interface IPosition
{
    Guid Id { get; }
    Guid OrderId { get; }
    Guid SymbolId { get; }

    TradeType TradeType { get; }

    double VolumeInUnits { get; }
    double QuantityInLots { get; }

    double EntryPrice { get; }
    double? StopLoss { get; }
    double? TakeProfit { get; }

    bool HasTrailingStop { get; }
    StopTriggerMethod? StopTriggerMethod { get; }    

    DateTime EntryTime { get; }
    DateTime? LastUpdateTime { get; }

    IReadOnlyList<ITradeOperation> TradeOperations { get; }
}