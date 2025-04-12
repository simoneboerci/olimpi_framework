using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Interfaces;

public interface IOrder
{
    TradeType TradeType { get; }
    string SymbolName { get; }
    double Volume { get; }
    string Label { get; }
    double? StopLossPips { get; }
    double? TakeProfitPips { get; }
    string Comment { get; }
    bool HasTrailingStop { get; }
    StopTriggerMethod? StopTriggerMethod { get; }
}