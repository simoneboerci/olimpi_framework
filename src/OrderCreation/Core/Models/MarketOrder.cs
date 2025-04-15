using System;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Core.Models;

internal readonly struct MarketOrder : IMarketOrder
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

    internal MarketOrder(int id, TradeType tradeType, string symbolName, double volume, string label,
        double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop)
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
    }

    public override bool Equals(object obj) => obj is IMarketOrder other && Equals(other);
    public bool Equals(IOrder other) => other is IMarketOrder marketOrder && Equals(marketOrder);

    public bool Equals(IMarketOrder other)
    {
        return Id == other.Id && TradeType == other.TradeType && SymbolName == other.SymbolName &&
               Volume.Equals(other.Volume) && Label == other.Label && StopLossPips.Equals(other.StopLossPips) &&
               TakeProfitPips.Equals(other.TakeProfitPips) && Comment == other.Comment &&
               HasTrailingStop == other.HasTrailingStop;
    }



    public override string ToString()
    {
        return $"MarketOrder(Id: {Id}, TradeType: {TradeType}, SymbolName: {SymbolName}, Volume: {Volume}, " +
               $"Label: {Label}, StopLossPips: {StopLossPips}, TakeProfitPips: {TakeProfitPips}, " +
               $"Comment: {Comment}, HasTrailingStop: {HasTrailingStop})";
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
        return hash.ToHashCode();
    }

    public static bool operator ==(MarketOrder left, MarketOrder right) => left.Equals(right);
    public static bool operator !=(MarketOrder left, MarketOrder right) => !left.Equals(right);
}