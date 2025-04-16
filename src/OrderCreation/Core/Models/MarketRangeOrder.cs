using System;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Core.Models;

internal readonly struct MarketRangeOrder : IMarketRangeOrder
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

    public double MarketRangePips { get; }
    public double BasePrice { get; }

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

    public override bool Equals(object obj) => obj is IMarketRangeOrder other && Equals(other);
    public bool Equals(IOrder other) => other is IMarketRangeOrder marketRangeOrder && Equals(marketRangeOrder);
    public bool Equals(IMarketOrder other) => other is IMarketRangeOrder marketRangeOrder && Equals(marketRangeOrder);

    public bool Equals(IMarketRangeOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop && StopLossTriggerMethod == other.StopLossTriggerMethod && MarketRangePips == other.MarketRangePips &&
               BasePrice == other.BasePrice;
    }

    public override string ToString()
    {
        return $"MarketRangeOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop}, StopLossTriggerMethod: {StopLossTriggerMethod}, MarketRangePips: {MarketRangePips}, " +
               $"BasePrice: {BasePrice})";
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

        hash.Add(MarketRangePips);
        hash.Add(BasePrice);

        return hash.ToHashCode();
    }

    public static bool operator == (MarketRangeOrder left, MarketRangeOrder right) => left.Equals(right);
    public static bool operator != (MarketRangeOrder left, MarketRangeOrder right) => !left.Equals(right);
}