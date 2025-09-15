using System;

namespace OrderCreation.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta un ordine limite di trading.
/// Estende <see cref="IPendingOrder"/> e <see cref="IEquatable{ILimitOrder}"/>.
/// Può essere implementata per aggiungere proprietà o metodi specifici degli ordini limite.
/// </summary>
public interface ILimitOrder : IPendingOrder, IEquatable<ILimitOrder>
{
    
}