using System;
using System.Collections.Generic;
using OrderCreation.Core.Enums;

namespace OrderExecution.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta una posizione di trading.
/// Espone proprietà per identificatori, tipo di trade, volume, prezzi di ingresso e uscita, trailing stop, tempi e operazioni associate.
/// Può essere implementata per rappresentare sia posizioni attive che pendenti.
/// </summary>
public interface IPosition
{
    /// <summary>
    /// Identificatore univoco della posizione.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Identificatore dell'ordine che ha generato la posizione.
    /// </summary>
    Guid OrderId { get; }

    /// <summary>
    /// Identificatore del simbolo/strumento finanziario.
    /// </summary>
    Guid SymbolId { get; }

    /// <summary>
    /// Tipo di trade (Buy/Sell).
    /// </summary>
    TradeType TradeType { get; }

    /// <summary>
    /// Volume della posizione in unità.
    /// </summary>
    double VolumeInUnits { get; }

    /// <summary>
    /// Quantità della posizione in lotti.
    /// </summary>
    double QuantityInLots { get; }

    /// <summary>
    /// Prezzo di ingresso della posizione.
    /// </summary>
    double EntryPrice { get; }

    /// <summary>
    /// Livello di stop loss, se impostato.
    /// </summary>
    double? StopLoss { get; }

    /// <summary>
    /// Livello di take profit, se impostato.
    /// </summary>
    double? TakeProfit { get; }

    /// <summary>
    /// Indica se la posizione ha trailing stop attivo.
    /// </summary>
    bool HasTrailingStop { get; }

    /// <summary>
    /// Metodo di trigger per lo stop (se presente).
    /// </summary>
    StopTriggerMethod? StopTriggerMethod { get; }    

    /// <summary>
    /// Data e ora di apertura della posizione.
    /// </summary>
    DateTime EntryTime { get; }

    /// <summary>
    /// Data e ora dell'ultimo aggiornamento della posizione (se presente).
    /// </summary>
    DateTime? LastUpdateTime { get; }

    /// <summary>
    /// Lista delle operazioni di trading associate alla posizione.
    /// </summary>
    IReadOnlyList<ITradeOperation> TradeOperations { get; }
}