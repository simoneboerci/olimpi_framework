using OrderExecution.Core.Interfaces;

namespace OrderExecution.Application;

/// <summary>
/// Interfaccia che aggrega le funzionalità di gestione delle posizioni di trading.
/// Estende le interfacce per cancellare, modificare, invertire e chiudere posizioni, sia pendenti che attive.
/// </summary>
public interface IPositionManager :
    ICancelPendingPositions,
    IModifyPendingPositions,
    IReversePositions,
    IModifyPositions,
    IClosePositions
{
    // Interfaccia marker: espone tutte le operazioni di gestione posizioni tramite le interfacce estese.
}