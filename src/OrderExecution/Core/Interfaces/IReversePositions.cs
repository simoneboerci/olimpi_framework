using System;

namespace OrderExecution.Core.Interfaces;

/// <summary>
/// Interfaccia che espone i metodi per invertire posizioni di trading.
/// Permette di invertire una posizione sia in modalità sincrona che asincrona, con possibilità di specificare il volume.
/// </summary>
public interface IReversePositions
{
    /// <summary>
    /// Inverte una posizione in modo sincrono.
    /// </summary>
    /// <param name="position">Posizione da invertire.</param>
    /// <returns>Risultato dell'operazione di inversione.</returns>
    ITradeResult ReversePosition(IPosition position);

    /// <summary>
    /// Inverte una posizione specificando il volume in modo sincrono.
    /// </summary>
    /// <param name="position">Posizione da invertire.</param>
    /// <param name="volume">Volume da invertire.</param>
    /// <returns>Risultato dell'operazione di inversione.</returns>
    ITradeResult ReversePosition(IPosition position, double volume);

    /// <summary>
    /// Inverte una posizione in modo asincrono.
    /// </summary>
    /// <param name="position">Posizione da invertire.</param>
    /// <param name="callback">Callback opzionale da invocare al termine dell'operazione.</param>
    /// <returns>Risultato asincrono dell'operazione di inversione.</returns>
    ITradeResultAsync ReversePositionAsync(IPosition position, Action<ITradeResult> callback = null);

    /// <summary>
    /// Inverte una posizione specificando il volume in modo asincrono.
    /// </summary>
    /// <param name="position">Posizione da invertire.</param>
    /// <param name="volume">Volume da invertire.</param>
    /// <param name="callback">Callback opzionale da invocare al termine dell'operazione.</param>
    /// <returns>Risultato asincrono dell'operazione di inversione.</returns>
    ITradeResultAsync ReversePositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null);
}