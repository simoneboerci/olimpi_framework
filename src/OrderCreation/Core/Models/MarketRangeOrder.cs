using System;
using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Interfaces;

namespace OrderCreation.Core.Models;

/// <summary>
/// Struttura che implementa <see cref="IMarketRangeOrder"/> e rappresenta un ordine di mercato con range di trading.
/// Espone tutte le proprietà di un ordine di mercato con range, inclusi identificatori, tipo di trade, volume, livelli di stop loss e take profit, etichetta, commento, trailing stop, metodo di trigger, range di prezzo e prezzo base.
/// Implementa l'uguaglianza e l'hash code per confronti e utilizzo in collezioni.
/// </summary>
internal readonly struct MarketRangeOrder : IMarketRangeOrder
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

    /// <inheritdoc/>
    public double MarketRangePips { get; }
    /// <inheritdoc/>
    public double BasePrice { get; }

    /// <summary>
    /// Costruttore che inizializza tutte le proprietà dell'ordine di mercato con range.
    /// </summary>
    internal MarketRangeOrder(Guid id, TradeType tradeType, string symbolName, double volume, string label,
        double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod,
        double marketRangePips, double basePrice)
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

        MarketRangePips = marketRangePips;
        BasePrice = basePrice;
    }

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is IMarketRangeOrder other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(IOrder other) => other is IMarketRangeOrder marketRangeOrder && Equals(marketRangeOrder);

    /// <inheritdoc/>
    public bool Equals(IMarketOrder other) => other is IMarketRangeOrder marketRangeOrder && Equals(marketRangeOrder);

    /// <inheritdoc/>
    public bool Equals(IMarketRangeOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop && StopLossTriggerMethod == other.StopLossTriggerMethod && MarketRangePips == other.MarketRangePips &&
               BasePrice == other.BasePrice;
    }

    /// <summary>
    /// Restituisce una rappresentazione testuale dell'ordine di mercato con range.
    /// </summary>
    public override string ToString()
    {
        return $"MarketRangeOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop}, StopLossTriggerMethod: {StopLossTriggerMethod}, MarketRangePips: {MarketRangePips}, " +
               $"BasePrice: {BasePrice})";
    }

    /// <summary>
    /// Restituisce il codice hash dell'ordine di mercato con range.
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

        hash.Add(MarketRangePips);
        hash.Add(BasePrice);

        return hash.ToHashCode();
    }

    /// <summary>
    /// Operatore di uguaglianza tra due ordini di mercato con range.
    /// </summary>
    public static bool operator == (MarketRangeOrder left, MarketRangeOrder right) => left.Equals(right);

    /// <summary>
    /// Operatore di disuguaglianza tra due ordini di mercato con range.
    /// </summary>
    public static bool operator != (MarketRangeOrder left, MarketRangeOrder right) => !left.Equals(right);
}