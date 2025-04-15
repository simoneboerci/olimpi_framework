using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Core.Models;

internal readonly struct StopLimitOrder : IStopLimitOrder
{
    public int Id { get; }
    public TradeType TradeType { get; }
    public string SymbolName { get; }
    public double Volume { get; }
    public string Label { get; }
    public double? StopLossPips { get; }
    public double? TakeProfitPips { get; }
    public string Comment { get; }
    public bool HasTrailingStop { get; }

    public double TargetPrice { get; }
    public DateTime? ExpirationTime { get; }
    public ProtectionType? ProtectionType { get; }

    public double StopOrderPips { get; }
    public double BasePrice { get; }

    public double StopLimitRangePips { get; }

    internal StopLimitOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool hasTrailingStop,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
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
        TargetPrice = targetPrice;
        ExpirationTime = expirationTime;
        ProtectionType = protectionType;
        StopOrderPips = stopOrderPips;
        BasePrice = basePrice;
        StopLimitRangePips = stopLimitRangePips;
    }

    public override bool Equals(object obj) => obj is IStopLimitOrder other && Equals(other);
    public bool Equals(IOrder other) => other is IStopLimitOrder stopLimitOrder && Equals(stopLimitOrder);
    public bool Equals(IPendingOrder other) => other is IStopLimitOrder stopLimitOrder && Equals(stopLimitOrder);
    public bool Equals(IStopOrder other) => other is IStopLimitOrder stopLimitOrder && Equals(stopLimitOrder);

    public bool Equals(IStopLimitOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop && StopLimitRangePips == other.StopLimitRangePips &&
               StopOrderPips == other.StopOrderPips && BasePrice == other.BasePrice &&
               TargetPrice == other.TargetPrice && ExpirationTime == other.ExpirationTime &&
               ProtectionType == other.ProtectionType;
    }

    public override string ToString()
    {
        return $"StopLimitOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop}) " +
               $"StopLimitRangePips: {StopLimitRangePips}, StopOrderPips: {StopOrderPips}, " +
               $"BasePrice: {BasePrice}, TargetPrice: {TargetPrice}, ExpirationTime: {ExpirationTime}, " +
               $"ProtectionType: {ProtectionType}";
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
        hash.Add(StopLimitRangePips);
        hash.Add(StopOrderPips);
        hash.Add(BasePrice);
        hash.Add(TargetPrice);
        hash.Add(ExpirationTime);
        hash.Add(ProtectionType);
        return hash.ToHashCode();
    }

    public static bool operator == (StopLimitOrder left, StopLimitOrder right) => left.Equals(right);
    public static bool operator != (StopLimitOrder left, StopLimitOrder right) => !left.Equals(right);
}