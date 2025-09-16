using System;
using System.Collections.Generic;
using CAlgoInterface.Backend.Services;
using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Backend.Integrations;

//TODO: Rework Trade Operation class because missing variables int the cAlgo API
public class TradeOperationAdapter : ITradeOperationAdapter
{
    private readonly cAlgo.API.TradeOperation _cAlgoTradeOperation;

    public TradeOperationAdapter(cAlgo.API.TradeOperation cAlgoTradeOperation)
    {
        _cAlgoTradeOperation = cAlgoTradeOperation;
    }

    public cAlgo.API.TradeOperation GetCAlgoTradeOperation() => _cAlgoTradeOperation;

    public Guid Id => throw new NotImplementedException(); //TODO: Implement Trade Operation ID Assignment
    public Guid PositionId => GuidHelper.IntToGuid(_cAlgoTradeOperation.TradeResult.Position.Id);
    public Guid OrderId => GuidHelper.IntToGuid(_cAlgoTradeOperation.TradeResult.PendingOrder.Id);
    public Guid SymbolId => GuidHelper.LongToGuid(_cAlgoTradeOperation.TradeResult.Position.Symbol.Id);
    public TradeOperationPositionImpact PositionImpact => throw new NotImplementedException();
    public TradeOperationStatus Status => throw new NotImplementedException();
    public TradeType TradeType => throw new NotImplementedException();
    public double? ExecutionPrice => throw new NotImplementedException();
    public double VolumeInUnits => _cAlgoTradeOperation.TradeResult.Position.VolumeInUnits;
    public double QuantityInLots => _cAlgoTradeOperation.TradeResult.Position.Quantity;
    public string Label => _cAlgoTradeOperation.TradeResult.Position.Label;
    public string Comment => _cAlgoTradeOperation.TradeResult.Position.Comment;
    public string Channel => _cAlgoTradeOperation.TradeResult.Position.Channel;
    public DateTime ExecutionTime => throw new NotImplementedException();
    public IReadOnlyList<ITradeOperation> ClosedBy => throw new NotImplementedException();
    public IReadOnlyList<ITradeOperation> Closing => throw new NotImplementedException();
}