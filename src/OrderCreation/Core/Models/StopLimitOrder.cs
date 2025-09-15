using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Core.Models;

/// <summary>
/// Struttura che implementa <see cref="IStopLimitOrder"/> e rappresenta un ordine stop-limit di trading.
/// Espone tutte le proprietà di un ordine stop-limit, inclusi identificatori, tipo di trade, volume, prezzi, scadenza, tipo di protezione, range stop-limit, prezzo base e metodi di trigger.
/// Implementa l'uguaglianza e l'hash code per confronti e utilizzo in collezioni.
/// </summary>
internal readonly struct StopLimitOrder : IStopLimitOrder
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

    /// <inheritdoc/>
    public double StopLimitRangePips { get; }

    /// <summary>
    /// Costruttore che inizializza tutte le proprietà dell'ordine stop-limit.
    /// </summary>
    internal StopLimitOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
        StopTriggerMethod? stopOrderTriggerMethod,
        double stopLimitRangePips
    )
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

        StopLimitRangePips = stopLimitRangePips;
    }

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is IStopLimitOrder other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(IOrder other) => other is IStopLimitOrder stopLimitOrder && Equals(stopLimitOrder);

    /// <inheritdoc/>
    public bool Equals(IPendingOrder other) => other is IStopLimitOrder stopLimitOrder && Equals(stopLimitOrder);

    /// <inheritdoc/>
    public bool Equals(IStopOrder other) => other is IStopLimitOrder stopLimitOrder && Equals(stopLimitOrder);

    /// <inheritdoc/>
    public bool Equals(IStopLimitOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop && StopLossTriggerMethod == other.StopLossTriggerMethod &&
               StopLimitRangePips == other.StopLimitRangePips && StopOrderTriggerMethod == other.StopOrderTriggerMethod &&
               StopOrderPips == other.StopOrderPips && BasePrice == other.BasePrice &&
               TargetPrice == other.TargetPrice && ExpirationTime == other.ExpirationTime &&
               ProtectionType == other.ProtectionType;
    }

    /// <summary>
    /// Restituisce una rappresentazione testuale dell'ordine stop-limit.
    /// </summary>
    public override string ToString()
    {
        return $"StopLimitOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop}, StopLossTriggerMethod: {StopLossTriggerMethod}) " +
               $"StopLimitRangePips: {StopLimitRangePips}, StopOrderTriggerMethod: {StopOrderTriggerMethod}, StopOrderPips: {StopOrderPips}, " +
               $"BasePrice: {BasePrice}, TargetPrice: {TargetPrice}, ExpirationTime: {ExpirationTime}, " +
               $"ProtectionType: {ProtectionType}";
    }

    /// <summary>
    /// Restituisce il codice hash dell'ordine stop-limit.
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

        hash.Add(StopLimitRangePips);

        return hash.ToHashCode();
    }

    /// <summary>
    /// Operatore di uguaglianza tra due ordini stop-limit.
    /// </summary>
    public static bool operator == (StopLimitOrder left, StopLimitOrder right) => left.Equals(right);

    /// <summary>
    /// Operatore di disuguaglianza tra due ordini stop-limit.
    /// </summary>
    public static bool operator != (StopLimitOrder left, StopLimitOrder right) => !left.Equals(right);
}