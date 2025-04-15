using System;
using System.Collections.Generic;
using OrderCreation;
using OrderExecution.Core.Enums;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

public readonly struct TradeOperation : ITradeOperation
{
    public Guid Id { get; }
    public Guid PositionId { get; }
    public Guid OrderId { get; }
    public Guid SymbolId { get; }

    public TradeOperationPositionImpact PositionImpact { get; }
    public TradeOperationStatus Status { get; }

    public TradeType TradeType { get; }

    public double? ExecutionPrice { get; }

    public double VolumeInUnits { get; }
    public double QuantityInLots { get; }

    public string Label { get; }
    public string Comment { get; }

    public string Channel { get; }

    public DateTime ExecutionTime { get; }

    public IReadOnlyList<ITradeOperation> ClosedBy { get; }
    public IReadOnlyList<ITradeOperation> Closing { get; }

    public TradeOperation(
        Guid id,
        Guid positionId,
        Guid orderId,
        Guid symbolId,
        TradeOperationPositionImpact positionImpact,
        TradeOperationStatus status,
        TradeType tradeType,
        double? executionPrice,
        double volumeInUnits,
        double quantityInLots,
        string label,
        string comment,
        string channel,
        DateTime executionTime,
        IReadOnlyList<ITradeOperation> closedBy,
        IReadOnlyList<ITradeOperation> closing
    )
    {
        Id = id;
        PositionId = positionId;
        OrderId = orderId;
        SymbolId = symbolId;
        PositionImpact = positionImpact;
        Status = status;
        TradeType = tradeType;
        ExecutionPrice = executionPrice;
        VolumeInUnits = volumeInUnits;
        QuantityInLots = quantityInLots;
        Label = label;
        Comment = comment;
        Channel = channel;
        ExecutionTime = executionTime;
        ClosedBy = closedBy ?? Array.Empty<ITradeOperation>();
        Closing = closing ?? Array.Empty<ITradeOperation>();
    }
}