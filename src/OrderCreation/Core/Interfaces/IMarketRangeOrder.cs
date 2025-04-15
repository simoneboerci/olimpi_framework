using System;

namespace OrderCreation.Core.Interfaces;

public interface IMarketRangeOrder : IMarketOrder, IEquatable<IMarketRangeOrder>
{
    double MarketRangePips { get; }
    double BasePrice{ get; }
}