using System;
using CAlgoInterface.Core.Interfaces;

namespace PositionManaging.Core.Interfaces;

/// <summary>
/// Interfaccia che espone i metodi per cancellare posizioni pendenti.
/// Permette la cancellazione sia in modalità sincrona che asincrona tramite callback.
/// </summary>
public interface ICancelPendingPositions
{
    /// <summary>
    /// Cancella una posizione pendente in modo sincrono.
    /// </summary>
    /// <param name="pendingPosition">Posizione pendente da cancellare.</param>
    /// <returns>Risultato dell'operazione di cancellazione.</returns>
    ITradeResult CancelPendingPosition(IPendingPosition pendingPosition);

    /// <summary>
    /// Cancella una posizione pendente in modo asincrono.
    /// </summary>
    /// <param name="pendingPosition">Posizione pendente da cancellare.</param>
    /// <param name="callback">Callback opzionale da invocare al termine dell'operazione.</param>
    /// <returns>Risultato asincrono dell'operazione di cancellazione.</returns>
    ITradeResultAsync CancelPendingPositionAsync(IPendingPosition pendingPosition, Action<ITradeResult> callback = null);
}