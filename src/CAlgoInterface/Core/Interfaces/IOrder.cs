using System;
using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta un ordine di trading.
/// Espone proprietà per identificatore, tipo di trade, simbolo, volume, etichetta, livelli di stop loss e take profit, commento, trailing stop e metodo di trigger.
/// Può essere implementata per ordini di mercato, limite, stop e stop-limit.
/// </summary>
public interface IOrder : IEquatable<IOrder>
{
    /// <summary>
    /// Identificatore univoco dell'ordine.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Tipo di operazione di trading (Buy/Sell).
    /// </summary>
    TradeType TradeType { get; }

    /// <summary>
    /// Nome del simbolo/strumento finanziario.
    /// </summary>
    string SymbolName { get; }

    /// <summary>
    /// Volume dell'ordine.
    /// </summary>
    double Volume { get; }

    /// <summary>
    /// Etichetta associata all'ordine.
    /// </summary>
    string Label { get; }

    /// <summary>
    /// Livello di stop loss in pips, se impostato.
    /// </summary>
    double? StopLossPips { get; }

    /// <summary>
    /// Livello di take profit in pips, se impostato.
    /// </summary>
    double? TakeProfitPips { get; }

    /// <summary>
    /// Commento associato all'ordine.
    /// </summary>
    string Comment { get; }

    /// <summary>
    /// Indica se l'ordine ha trailing stop attivo.
    /// </summary>
    bool HasTrailingStop { get; }

    /// <summary>
    /// Metodo di trigger per lo stop loss, se presente.
    /// </summary>
    StopTriggerMethod? StopLossTriggerMethod { get; }
}