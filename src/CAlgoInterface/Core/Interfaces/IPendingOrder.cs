using System;

namespace CAlgoInterface.Core.Interfaces;

public interface IPendingOrder : IOrder
{
    double TargetPrice { get; }
    DateTime? ExpirationTime { get; }
    double? StopLimitRangePips { get; }
    double DistancePips { get; }
    DateTime SubmittedTime { get; }
    DateTime? LastUpdateTime{ get; }
}