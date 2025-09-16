using System;
using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta un ordine pendente di trading.
/// Estende <see cref="IOrder"/> e <see cref="IEquatable{IPendingOrder}"/>.
/// Espone proprietà specifiche per il prezzo target, la scadenza e il tipo di protezione.
/// Può essere implementata per ordini limite, stop e stop-limit.
/// </summary>
public interface IPendingOrder : IOrder, IEquatable<IPendingOrder>
{
    /// <summary>
    /// Prezzo target dell'ordine pendente.
    /// </summary>
    double TargetPrice { get; }

    /// <summary>
    /// Data e ora di scadenza dell'ordine, se impostata.
    /// </summary>
    DateTime? ExpirationTime { get; }

    /// <summary>
    /// Tipo di protezione applicata all'ordine, se presente.
    /// </summary>
    ProtectionType? ProtectionType { get; }
}