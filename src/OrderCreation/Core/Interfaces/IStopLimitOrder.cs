using System;

namespace OrderCreation.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta un ordine stop-limit di trading.
/// Estende <see cref="IStopOrder"/> e <see cref="IEquatable{IStopLimitOrder}"/>.
/// Espone la proprietà per il range di prezzo stop-limit.
/// Può essere implementata per aggiungere proprietà o metodi specifici degli ordini stop-limit.
/// </summary>
public interface IStopLimitOrder : IStopOrder, IEquatable<IStopLimitOrder>
{
    /// <summary>
    /// Range di prezzo in pips per l'esecuzione dell'ordine stop-limit.
    /// </summary>
    double StopLimitRangePips { get; }
}