using cAlgo.API;

namespace CAlgoInterface.Core.Data;

public readonly struct CAlgoMarketRangeOrderStruct
{
    public TradeType TradeType { get; }
    public string SymbolName { get; }
    public double Volume { get; }
    public double MarketRangePips { get; }
    public double BasePrice { get; }
    public string Label { get; }
    public double? StopLossPips { get; }
    public double? TakeProfitPips { get; }
    public string Comment { get; }
    public bool HasTrailingStop { get; }
    public StopTriggerMethod? StopTriggerMethod { get; }

    public CAlgoMarketRangeOrderStruct(
        TradeType tradeType,
        string symbolName,
        double volume,
        double marketRangePips,
        double basePrice,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool hasTrailingStop,
        StopTriggerMethod? stopTriggerMethod
    )
    {
        TradeType = tradeType;
        SymbolName = symbolName;
        Volume = volume;
        MarketRangePips = marketRangePips;
        BasePrice = basePrice;
        Label = label;
        StopLossPips = stopLossPips;
        TakeProfitPips = takeProfitPips;
        Comment = comment;
        HasTrailingStop = hasTrailingStop;
        StopTriggerMethod = stopTriggerMethod;
    }
}