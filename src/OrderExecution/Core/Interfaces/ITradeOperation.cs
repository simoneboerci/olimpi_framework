using System;
using System.Collections.Generic;
using OrderCreation;
using OrderExecution.Core.Enums;

namespace OrderExecution.Core.Interfaces;

public interface ITradeOperation
{
    Guid Id { get; }
    Guid PositionId { get; }
    Guid OrderId { get; }
    Guid SymbolId { get; }

    TradeOperationPositionImpact PositionImpact { get; }
    TradeOperationStatus Status { get; }

    TradeType TradeType { get; }

    double? ExecutionPrice { get; }

    double VolumeInUnits { get; }
    double QuantityInLots { get; }

    string Label { get; }
    string Comment { get; }

    string Channel { get; }

    DateTime ExecutionTime { get; }

    IReadOnlyList<ITradeOperation> ClosedBy { get; }
    IReadOnlyList<ITradeOperation> Closing { get; }
}