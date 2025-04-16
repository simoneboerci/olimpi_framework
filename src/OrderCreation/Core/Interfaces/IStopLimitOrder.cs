using System;

namespace OrderCreation.Core.Interfaces;

public interface IStopLimitOrder : IStopOrder, IEquatable<IStopLimitOrder>
{
    double StopLimitRangePips { get; }
}