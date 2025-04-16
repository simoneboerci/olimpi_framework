using System;

namespace OrderCreation.Core.Interfaces;

public interface IOrder : IEquatable<IOrder>
{
    Guid Id { get; }
    TradeType TradeType { get; }
    string SymbolName { get; }
    double Volume { get; }
    string Label { get; }
    double? StopLossPips { get; }
    double? TakeProfitPips { get; }
    string Comment { get; }
    bool HasTrailingStop { get; }
    StopTriggerMethod? StopLossTriggerMethod { get; }
}