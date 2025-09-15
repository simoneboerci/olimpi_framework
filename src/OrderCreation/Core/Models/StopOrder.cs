using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Core.Models;

/// <summary>
/// Struttura che implementa <see cref="IStopOrder"/> e rappresenta un ordine stop di trading.
/// Espone tutte le proprietà di un ordine stop, inclusi identificatori, tipo di trade, volume, prezzi, scadenza, tipo di protezione, prezzo base e metodi di trigger.
/// Implementa l'uguaglianza e l'hash code per confronti e utilizzo in collezioni.
/// </summary>
internal readonly struct StopOrder : IStopOrder
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
    public double TargetPrice { get; }
    /// <inheritdoc/>
    public DateTime? ExpirationTime { get; }
    /// <inheritdoc/>
    public ProtectionType? ProtectionType { get; }

    /// <inheritdoc/>
    public double StopOrderPips { get; }
    /// <inheritdoc/>
    public double BasePrice { get; }
    /// <inheritdoc/>
    public StopTriggerMethod? StopOrderTriggerMethod { get; }

    /// <summary>
    /// Costruttore che inizializza tutte le proprietà dell'ordine stop.
    /// </summary>
    internal StopOrder(Guid id, TradeType tradeType, string symbolName, double volume, string label,
        double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice, DateTime? expirationTime, ProtectionType? protectionType,
        double stopOrderPips, double basePrice, StopTriggerMethod? stopOrderTriggerMethod)
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

        TargetPrice = targetPrice;
        ExpirationTime = expirationTime;
        ProtectionType = protectionType;

        StopOrderPips = stopOrderPips;
        BasePrice = basePrice;
        StopOrderTriggerMethod = stopOrderTriggerMethod;
    }

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is IStopOrder other && Equals(other);
    /// <inheritdoc/>
    public bool Equals(IOrder other) => other is IStopOrder stopOrder && Equals(stopOrder);
    /// <inheritdoc/>
    public bool Equals(IPendingOrder other) => other is IStopOrder stopOrder && Equals(stopOrder);

    /// <inheritdoc/>
    public bool Equals(IStopOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop && StopLossTriggerMethod == other.StopLossTriggerMethod && StopOrderPips == other.StopOrderPips &&
               BasePrice == other.BasePrice && TargetPrice == other.TargetPrice &&
               ExpirationTime == other.ExpirationTime && ProtectionType == other.ProtectionType && StopOrderTriggerMethod == other.StopOrderTriggerMethod;
    }

    /// <summary>
    /// Restituisce una rappresentazione testuale dell'ordine stop.
    /// </summary>
    public override string ToString()
    {
        return $"StopOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop}, StopLossTriggerMethod: {StopLossTriggerMethod}, StopOrderPips: {StopOrderPips}, " +
               $"BasePrice: {BasePrice}, TargetPrice: {TargetPrice}, ExpirationTime: {ExpirationTime}, " +
               $"ProtectionType: {ProtectionType}, StopOrderTriggerMethod: {StopOrderTriggerMethod})";
    }

    /// <summary>
    /// Restituisce il codice hash dell'ordine stop.
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

        hash.Add(TargetPrice);
        hash.Add(ExpirationTime);
        hash.Add(ProtectionType);

        hash.Add(StopOrderPips);
        hash.Add(BasePrice);
        hash.Add(StopOrderTriggerMethod);

        return hash.ToHashCode();
    }

    /// <summary>
    /// Operatore di uguaglianza tra due ordini stop.
    /// </summary>
    public static bool operator ==(StopOrder left, StopOrder right) => left.Equals(right);
    /// <summary>
    /// Operatore di disuguaglianza tra due ordini stop.
    /// </summary>
    public static bool operator !=(StopOrder left, StopOrder right) => !left.Equals(right);
}