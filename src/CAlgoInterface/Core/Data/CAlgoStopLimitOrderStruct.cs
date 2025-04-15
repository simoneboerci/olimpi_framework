using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Data;

public readonly struct CAlgoStopLimitOrderStruct
{
    public TradeType TradeType { get; }
    public string SymbolName { get; }
    public double Volume { get; }
    public double TargetPrice { get; }
    public double StopLimitRangePips { get; }
    public string Label { get; }
    public double? StopLoss { get; }
    public double? TakeProfit { get; }
    public ProtectionType? ProtectionType { get; }
    public DateTime? Expiration { get; }
    public string Comment { get; }
    public bool HasTrailingStop { get; }
    public StopTriggerMethod? StopLossTriggerMethod { get; }
    public StopTriggerMethod StopOrderTriggerMethod { get; } 

    public CAlgoStopLimitOrderStruct(
        TradeType tradeType,
        string symbolName,
        double volume,
        double targetPrice,
        double stopLimitRangePips,
        string label,
        double? stopLoss,
        double? takeProfit,
        ProtectionType? protectionType,
        DateTime? expiration,
        string comment,
        bool hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        StopTriggerMethod stopOrderTriggerMethod
    )
    {
        TradeType = tradeType;
        SymbolName = symbolName;
        Volume = volume;
        TargetPrice = targetPrice;
        StopLimitRangePips = stopLimitRangePips;
        Label = label;
        StopLoss = stopLoss;
        TakeProfit = takeProfit;
        ProtectionType = protectionType;
        Expiration = expiration;
        Comment = comment;
        HasTrailingStop = hasTrailingStop;
        StopLossTriggerMethod = stopLossTriggerMethod;
        StopOrderTriggerMethod = stopOrderTriggerMethod;
    }
}