using System;
using CAlgoInterface.Core.Interfaces;

namespace PositionManaging.Core.Interfaces;

/// <summary>
/// Interfaccia che espone i metodi per chiudere posizioni di trading.
/// Permette la chiusura di posizioni sia in modalità sincrona che asincrona, con possibilità di specificare il volume da chiudere.
/// </summary>
public interface IClosePositions
{
    /// <summary>
    /// Chiude una posizione in modo sincrono.
    /// </summary>
    /// <param name="position">Posizione da chiudere.</param>
    /// <returns>Risultato dell'operazione di chiusura.</returns>
    ITradeResult ClosePosition(IPosition position);

    /// <summary>
    /// Chiude una posizione specificando il volume (long) in modo sincrono.
    /// </summary>
    /// <param name="position">Posizione da chiudere.</param>
    /// <param name="volume">Volume da chiudere.</param>
    /// <returns>Risultato dell'operazione di chiusura.</returns>
    ITradeResult ClosePosition(IPosition position, long volume);

    /// <summary>
    /// Chiude una posizione specificando il volume (double) in modo sincrono.
    /// </summary>
    /// <param name="position">Posizione da chiudere.</param>
    /// <param name="volume">Volume da chiudere.</param>
    /// <returns>Risultato dell'operazione di chiusura.</returns>
    ITradeResult ClosePosition(IPosition position, double volume);

    /// <summary>
    /// Chiude una posizione in modo asincrono.
    /// </summary>
    /// <param name="position">Posizione da chiudere.</param>
    /// <param name="callback">Callback opzionale da invocare al termine dell'operazione.</param>
    /// <returns>Risultato asincrono dell'operazione di chiusura.</returns>
    ITradeResultAsync ClosePositionAsync(IPosition position, Action<ITradeResult> callback = null);

    /// <summary>
    /// Chiude una posizione specificando il volume (long) in modo asincrono.
    /// </summary>
    /// <param name="position">Posizione da chiudere.</param>
    /// <param name="volume">Volume da chiudere.</param>
    /// <param name="callback">Callback opzionale da invocare al termine dell'operazione.</param>
    /// <returns>Risultato asincrono dell'operazione di chiusura.</returns>
    ITradeResultAsync ClosePositionAsync(IPosition position, long volume, Action<ITradeResult> callback = null);

    /// <summary>
    /// Chiude una posizione specificando il volume (double) in modo asincrono.
    /// </summary>
    /// <param name="position">Posizione da chiudere.</param>
    /// <param name="volume">Volume da chiudere.</param>
    /// <param name="callback">Callback opzionale da invocare al termine dell'operazione.</param>
    /// <returns>Risultato asincrono dell'operazione di chiusura.</returns>
    ITradeResultAsync ClosePositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null);
}