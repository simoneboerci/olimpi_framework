using System;
using CAlgoInterface.Core.Interfaces;
using OrderCreation.Core.Enums;

namespace OrderExecution.Core.Interfaces;

/// <summary>
/// Interfaccia che espone i metodi per modificare posizioni di trading attive.
/// Permette la modifica di volume, stop loss, take profit, tipo di protezione, trailing stop e metodi di trigger.
/// Supporta sia operazioni sincrone che asincrone tramite callback, con vari overload per gestire scenari avanzati.
/// </summary>
public interface IModifyPositions
{
    /// <summary>
    /// Modifica una posizione specificando solo il volume.
    /// </summary>
    ITradeResult ModifyPosition(IPosition position, double volume);

    /// <summary>
    /// Modifica una posizione specificando volume, stop loss, take profit e tipo di protezione.
    /// </summary>
    ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType);

    /// <summary>
    /// Modifica una posizione specificando volume, stop loss, take profit, tipo di protezione e trailing stop.
    /// </summary>
    ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop);

    /// <summary>
    /// Modifica una posizione specificando volume, stop loss, take profit, tipo di protezione, trailing stop e metodo di trigger per lo stop loss.
    /// </summary>
    ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);

    /// <summary>
    /// Modifica una posizione in modo asincrono specificando solo il volume.
    /// </summary>
    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null);

    /// <summary>
    /// Modifica una posizione in modo asincrono specificando volume, stop loss, take profit e tipo di protezione.
    /// </summary>
    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<ITradeResult> callback = null);

    /// <summary>
    /// Modifica una posizione in modo asincrono specificando volume, stop loss, take profit, tipo di protezione e trailing stop.
    /// </summary>
    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, Action<ITradeResult> callback = null);

    /// <summary>
    /// Modifica una posizione in modo asincrono specificando volume, stop loss, take profit, tipo di protezione, trailing stop e metodo di trigger per lo stop loss.
    /// </summary>
    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<ITradeResult> callback = null);
}