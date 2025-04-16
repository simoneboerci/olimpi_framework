using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Core.Models;

internal readonly struct LimitOrder : ILimitOrder
{
    public Guid Id { get; }
    public TradeType TradeType { get; }
    public string SymbolName { get; }
    public double Volume { get; }
    public string Label { get; }
    public double? StopLossPips { get; }
    public double? TakeProfitPips { get; }
    public string Comment { get; }
    public bool HasTrailingStop { get; }
    public StopTriggerMethod? StopLossTriggerMethod { get; }

    public double TargetPrice { get; }
    public DateTime? ExpirationTime { get; }
    public ProtectionType? ProtectionType { get; }

    internal LimitOrder(Guid id, TradeType tradeType, string symbolName, double volume, string label,
        double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice, DateTime? expirationTime, ProtectionType? protectionType)
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
    }

    public override bool Equals(object obj) => obj is ILimitOrder other && Equals(other);
    public bool Equals(IOrder other) => other is ILimitOrder limitOrder && Equals(limitOrder);
    public bool Equals(IPendingOrder other) => other is ILimitOrder limitOrder && Equals(limitOrder);

    public bool Equals(ILimitOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop && StopLossTriggerMethod == other.StopLossTriggerMethod && TargetPrice == other.TargetPrice &&
               ExpirationTime == other.ExpirationTime && ProtectionType == other.ProtectionType;
    }

    public override string ToString()
    {
        return $"LimitOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop}), StopLossTriggerMethod: {StopLossTriggerMethod}" +
               $"TargetPrice: {TargetPrice}, ExpirationTime: {ExpirationTime}, ProtectionType: {ProtectionType}";
    }

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

        return hash.ToHashCode();
    }

    public static bool operator == (LimitOrder left, LimitOrder right) => left.Equals(right);
    public static bool operator != (LimitOrder left, LimitOrder right) => !left.Equals(right);
}