using System;
using OrderCreation.Core.Enums;

namespace OrderCreation.Core.Interfaces;

public interface IPendingOrder : IOrder, IEquatable<IPendingOrder>
{
    double TargetPrice { get; }
    DateTime? ExpirationTime { get; }
    ProtectionType? ProtectionType { get; }
}