using System;

namespace OrderCreation.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta un ordine di mercato con range di trading.
/// Estende <see cref="IMarketOrder"/> e <see cref="IEquatable{IMarketRangeOrder}"/>.
/// Espone proprietà specifiche per il range di prezzo e il prezzo base.
/// </summary>
public interface IMarketRangeOrder : IMarketOrder, IEquatable<IMarketRangeOrder>
{
    /// <summary>
    /// Range di prezzo in pips entro cui l'ordine può essere eseguito.
    /// </summary>
    double MarketRangePips { get; }

    /// <summary>
    /// Prezzo base di riferimento per l'esecuzione dell'ordine.
    /// </summary>
    double BasePrice { get; }
}