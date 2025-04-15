using cAlgo.API;

namespace CAlgoInterface.Core.Data;

public readonly struct CAlgoMarketOrderStruct
{
    public TradeType TradeType { get; }
    public string SymbolName { get; }
    public double Volume { get; }
    public string Label { get; }
    public double? StopLossPips { get; }
    public double? TakeProfitPips { get; }
    public string Comment { get; }
    public bool HasTrailingStop { get; }
    public StopTriggerMethod? StopTriggerMethod { get; }

    public CAlgoMarketOrderStruct(
        TradeType tradeType,
        string symbolName,
        double volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool hasTrailingStop,
        StopTriggerMethod? stopTriggerMethod)
    {
        TradeType = tradeType;
        SymbolName = symbolName;
        Volume = volume;
        Label = label;
        StopLossPips = stopLossPips;
        TakeProfitPips = takeProfitPips;
        Comment = comment;
        HasTrailingStop = hasTrailingStop;
        StopTriggerMethod = stopTriggerMethod;
    } 
}