namespace OrderExecution.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta una posizione attiva di trading.
/// Espone proprietà per profitti, swap, commissioni, prezzo corrente e margine utilizzato.
/// Estende <see cref="IPosition"/>.
/// </summary>
public interface IActivePosition : IPosition
{
    /// <summary>
    /// Profitto lordo della posizione.
    /// </summary>
    double GrossProfit { get; }

    /// <summary>
    /// Profitto netto della posizione.
    /// </summary>
    double NetProfit { get; }

    /// <summary>
    /// Swap maturato dalla posizione.
    /// </summary>
    double Swap { get; }

    /// <summary>
    /// Commissioni associate alla posizione.
    /// </summary>
    double Commissions { get; }

    /// <summary>
    /// Prezzo corrente dell'asset relativo alla posizione.
    /// </summary>
    double CurrentPrice { get; }

    /// <summary>
    /// Margine utilizzato dalla posizione.
    /// </summary>
    double MarginUsed { get; }
}