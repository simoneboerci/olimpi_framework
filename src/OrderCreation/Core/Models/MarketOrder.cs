using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Core.Models;

/// <summary>
/// Struttura che implementa <see cref="IMarketOrder"/> e rappresenta un ordine di mercato di trading.
/// Espone tutte le proprietà di un ordine di mercato, inclusi identificatori, tipo di trade, volume, livelli di stop loss e take profit, etichetta, commento, trailing stop e metodo di trigger.
/// Implementa l'uguaglianza e l'hash code per confronti e utilizzo in collezioni.
/// </summary>
internal readonly struct MarketOrder : IMarketOrder
{
    /// <inheritdoc/>
    public Guid Id { get; }
    /// <inheritdoc/>
    public TradeType TradeType { get; }
    /// <inheritdoc/>
    public string SymbolName { get; }
    /// <inheritdoc/>
    public double Volume { get; }
    /// <inheritdoc/>
    public string Label { get; }
    /// <inheritdoc/>
    public double? StopLossPips { get; }
    /// <inheritdoc/>
    public double? TakeProfitPips { get; }
    /// <inheritdoc/>
    public string Comment { get; }
    /// <inheritdoc/>
    public bool HasTrailingStop { get; }
    /// <inheritdoc/>
    public StopTriggerMethod? StopLossTriggerMethod { get; }

    /// <summary>
    /// Costruttore che inizializza tutte le proprietà dell'ordine di mercato.
    /// </summary>
    internal MarketOrder(Guid id, TradeType tradeType, string symbolName, double volume, string label,
        double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod)
    {
        Id = id;
        TradeType = tradeType;
        SymbolName = symbolName;
        Volume = volume;
        Label = label;
        StopLossPips = stopLossPips;
        TakeProfitPips = takeProfitPips;
        Comment = comment;
        HasTrailingStop = hasTrailingStop;
        StopLossTriggerMethod = stopLossTriggerMethod;
    }

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is IMarketOrder other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(IOrder other) => other is IMarketOrder marketOrder && Equals(marketOrder);

    /// <inheritdoc/>
    public bool Equals(IMarketOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop && StopLossTriggerMethod == other.StopLossTriggerMethod;
    }

    /// <summary>
    /// Restituisce una rappresentazione testuale dell'ordine di mercato.
    /// </summary>
    public override string ToString()
    {
        return $"MarketOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop}, StopLossTriggerMethod: {StopLossTriggerMethod})";
    }

    /// <summary>
    /// Restituisce il codice hash dell'ordine di mercato.
    /// </summary>
    public override int GetHashCode()
    {
        var hash = new HashCode();

        hash.Add(Id);
        hash.Add(TradeType);
        hash.Add(SymbolName);
        hash.Add(Volume);
        hash.Add(Label);
        hash.Add(StopLossPips);
        hash.Add(TakeProfitPips);
        hash.Add(Comment);
        hash.Add(HasTrailingStop);
        hash.Add(StopLossTriggerMethod);

        return hash.ToHashCode();
    }

    /// <summary>
    /// Operatore di uguaglianza tra due ordini di mercato.
    /// </summary>
    public static bool operator ==(MarketOrder left, MarketOrder right) => left.Equals(right);

    /// <summary>
    /// Operatore di disuguaglianza tra due ordini di mercato.
    /// </summary>
    public static bool operator !=(MarketOrder left, MarketOrder right) => !left.Equals(right);
}