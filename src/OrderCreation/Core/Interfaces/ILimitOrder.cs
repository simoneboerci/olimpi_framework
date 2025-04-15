using System;

namespace OrderCreation.Core.Interfaces;

public interface ILimitOrder : IPendingOrder, IEquatable<ILimitOrder>
{
    
}