using System;
using System.Collections.Generic;
using OrderCreation.Core.Enums;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

/// <summary>
/// Implementazione di una posizione pendente di trading.
/// Espone tutte le proprietà relative a una posizione non ancora attiva, come identificatori, tipo di trade, volume, prezzi, trailing stop e operazioni associate.
/// </summary>
public class PendingPosition : IPendingPosition
{
    /// <summary>
    /// Identificatore univoco della posizione.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Identificatore dell'ordine che ha generato la posizione.
    /// </summary>
    public Guid OrderId { get; }

    /// <summary>
    /// Identificatore del simbolo/strumento finanziario.
    /// </summary>
    public Guid SymbolId { get; }

    /// <summary>
    /// Tipo di trade (Buy/Sell).
    /// </summary>
    public TradeType TradeType { get; }

    /// <summary>
    /// Volume della posizione in unità.
    /// </summary>
    public double VolumeInUnits { get; }

    /// <summary>
    /// Quantità della posizione in lotti.
    /// </summary>
    public double QuantityInLots { get; }

    /// <summary>
    /// Prezzo di ingresso della posizione.
    /// </summary>
    public double EntryPrice { get; }

    /// <summary>
    /// Livello di stop loss, se impostato.
    /// </summary>
    public double? StopLoss { get; }

    /// <summary>
    /// Livello di take profit, se impostato.
    /// </summary>
    public double? TakeProfit { get; }

    /// <summary>
    /// Indica se la posizione ha trailing stop attivo.
    /// </summary>
    public bool HasTrailingStop { get; }

    /// <summary>
    /// Metodo di trigger per lo stop (se presente).
    /// </summary>
    public StopTriggerMethod? StopTriggerMethod { get; }

    /// <summary>
    /// Data e ora di apertura della posizione.
    /// </summary>
    public DateTime EntryTime { get; }

    /// <summary>
    /// Data e ora dell'ultimo aggiornamento della posizione (se presente).
    /// </summary>
    public DateTime? LastUpdateTime { get; }

    /// <summary>
    /// Lista delle operazioni di trading associate alla posizione.
    /// </summary>
    public IReadOnlyList<ITradeOperation> TradeOperations { get; }

    /// <summary>
    /// Costruttore che inizializza tutte le proprietà della posizione pendente.
    /// </summary>
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