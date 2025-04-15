using System;
using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Interfaces;

public interface IPosition
{
    TradeType TradeType { get; }
    double VolumeInUnits { get; }
    double Quantity { get; }
    double GrossProfit { get; }
    double NetProfit { get; }
    double EntryPrice { get; }
    double? StopLoss { get; }
    double? TakeProfit { get; }
    bool HasTrailingStop { get; }
    StopTriggerMethod? StopLossTriggerMethod { get; }
    double Swap { get; }
    double Commission { get; }
    DateTime EntryTime { get; }
    double Pips { get; }
    string Label { get; }
    string Comment { get; }
    double MarginUsed { get; }
    double CurrentPrice { get; }
    
}