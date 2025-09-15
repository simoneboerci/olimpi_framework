using System;
using System.Collections.Generic;
using OrderCreation;
using OrderExecution.Core.Enums;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

/// <summary>
/// Struttura che implementa <see cref="ITradeOperation"/> e rappresenta un'operazione di trading.
/// Espone tutte le proprietà relative all'operazione, come identificatori, impatto sulla posizione, stato, tipo di trade, prezzo di esecuzione, volume, etichette, commenti, canale, tempi e relazioni con altre operazioni.
/// Può essere utilizzata per rappresentare sia operazioni di apertura che di chiusura.
/// </summary>
public readonly struct TradeOperation : ITradeOperation
{
    /// <summary>
    /// Identificatore univoco dell'operazione di trading.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Identificatore della posizione associata.
    /// </summary>
    public Guid PositionId { get; }

    /// <summary>
    /// Identificatore dell'ordine che ha generato l'operazione.
    /// </summary>
    public Guid OrderId { get; }

    /// <summary>
    /// Identificatore del simbolo/strumento finanziario.
    /// </summary>
    public Guid SymbolId { get; }

    /// <summary>
    /// Impatto dell'operazione sulla posizione (apertura/chiusura).
    /// </summary>
    public TradeOperationPositionImpact PositionImpact { get; }

    /// <summary>
    /// Stato dell'operazione di trading.
    /// </summary>
    public TradeOperationStatus Status { get; }

    /// <summary>
    /// Tipo di trade (Buy/Sell).
    /// </summary>
    public TradeType TradeType { get; }

    /// <summary>
    /// Prezzo di esecuzione dell'operazione, se disponibile.
    /// </summary>
    public double? ExecutionPrice { get; }

    /// <summary>
    /// Volume dell'operazione in unità.
    /// </summary>
    public double VolumeInUnits { get; }

    /// <summary>
    /// Quantità dell'operazione in lotti.
    /// </summary>
    public double QuantityInLots { get; }

    /// <summary>
    /// Etichetta associata all'operazione.
    /// </summary>
    public string Label { get; }

    /// <summary>
    /// Commento associato all'operazione.
    /// </summary>
    public string Comment { get; }

    /// <summary>
    /// Canale di esecuzione dell'operazione.
    /// </summary>
    public string Channel { get; }

    /// <summary>
    /// Data e ora di esecuzione dell'operazione.
    /// </summary>
    public DateTime ExecutionTime { get; }

    /// <summary>
    /// Lista delle operazioni che hanno chiuso questa operazione.
    /// </summary>
    public IReadOnlyList<ITradeOperation> ClosedBy { get; }

    /// <summary>
    /// Lista delle operazioni chiuse da questa operazione.
    /// </summary>
    public IReadOnlyList<ITradeOperation> Closing { get; }

    /// <summary>
    /// Costruttore che inizializza tutte le proprietà dell'operazione di trading.
    /// </summary>
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