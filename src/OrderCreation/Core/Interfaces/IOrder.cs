using System;

namespace OrderCreation.Core.Interfaces;

public interface IOrder : IEquatable<IOrder>
{
    int Id { get; }
    TradeType TradeType { get; }
    string SymbolName { get; }
    double Volume { get; }
    string Label { get; }
    double? StopLossPips { get; }
    double? TakeProfitPips { get; }
    string Comment { get; }
    bool HasTrailingStop { get; }
}