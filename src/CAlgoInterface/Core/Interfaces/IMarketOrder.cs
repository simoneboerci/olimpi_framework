using System;

namespace CAlgoInterface.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta un ordine di mercato di trading.
/// Estende <see cref="IOrder"/> e <see cref="IEquatable{IMarketOrder}"/>.
/// Può essere implementata per aggiungere proprietà o metodi specifici degli ordini di mercato.
/// </summary>
public interface IMarketOrder : IOrder, IEquatable<IMarketOrder>
{
    
}