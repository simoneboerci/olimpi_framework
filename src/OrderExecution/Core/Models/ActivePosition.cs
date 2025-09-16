using System;
using System.Collections.Generic;
using CAlgoInterface.Core.Interfaces;
using OrderCreation.Core.Enums;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Core.Models;

/// <summary>
/// Implementazione della posizione attiva di trading.
/// Espone tutte le proprietà relative a una posizione aperta, inclusi profitti, swap, commissioni, prezzi, margine e operazioni associate.
/// </summary>
public class ActivePosition : IActivePosition
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
    /// Profitto lordo della posizione.
    /// </summary>
    public double GrossProfit { get; }

    /// <summary>
    /// Profitto netto della posizione.
    /// </summary>
    public double NetProfit { get; }

    /// <summary>
    /// Swap maturato dalla posizione.
    /// </summary>
    public double Swap { get; }

    /// <summary>
    /// Commissioni associate alla posizione.
    /// </summary>
    public double Commissions { get; }

    /// <summary>
    /// Data e ora di apertura della posizione.
    /// </summary>
    public DateTime EntryTime { get; }

    /// <summary>
    /// Data e ora dell'ultimo aggiornamento della posizione (se presente).
    /// </summary>
    public DateTime? LastUpdateTime { get; }

    /// <summary>
    /// Prezzo corrente dell'asset relativo alla posizione.
    /// </summary>
    public double CurrentPrice { get; }

    /// <summary>
    /// Margine utilizzato dalla posizione.
    /// </summary>
    public double MarginUsed { get; }

    /// <summary>
    /// Lista delle operazioni di trading associate alla posizione.
    /// </summary>
    public IReadOnlyList<ITradeOperation> TradeOperations { get; }

    /// <summary>
    /// Costruttore che inizializza tutte le proprietà della posizione attiva.
    /// </summary>
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
