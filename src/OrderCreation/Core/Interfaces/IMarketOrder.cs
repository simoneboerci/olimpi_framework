using System;

namespace OrderCreation.Core.Interfaces;

public interface IMarketOrder : IOrder, IEquatable<IMarketOrder>
{
    
}