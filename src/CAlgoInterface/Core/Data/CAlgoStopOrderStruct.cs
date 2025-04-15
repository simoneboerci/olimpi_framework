using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Data;

public readonly struct CAlgoStopOrderStruct
{
    public TradeType TradeType { get; }
    public string SymbolName { get; }
    public double Volume { get; }
    public double TargetPrice { get; }
    public string Label { get; }
    public double? StopLoss { get; }
    public double? TakeProfit { get; }
    public ProtectionType? ProtectionType { get; }
    public DateTime? Expiration { get; }
    public string Comment { get; }
    public bool HasTrailingStop { get; }
    public StopTriggerMethod? StopLossTriggerMethod { get; }
    public StopTriggerMethod StopOrderTriggerMethod { get; }

    public CAlgoStopOrderStruct(
        TradeType tradeType,
        string symbolName,
        double volume,
        double targetPrice,
        string label,
        double? stopLoss,
        double? takeProfit,
        ProtectionType? protectionType,
        DateTime? expiration,
        string comment,
        bool hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        StopTriggerMethod stopOrderTriggerMethod)
    {
        TradeType = tradeType;
        SymbolName = symbolName;
        Volume = volume;
        TargetPrice = targetPrice;
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