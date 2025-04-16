using System;

namespace OrderCreation.Core.Interfaces;

public interface IStopOrder : IPendingOrder, IEquatable<IStopOrder>
{
    double StopOrderPips { get; }
    double BasePrice { get; }
    StopTriggerMethod? StopOrderTriggerMethod { get; }
}