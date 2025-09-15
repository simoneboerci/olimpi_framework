using System;
using OrderCreation;
using OrderCreation.Core.Enums;

namespace OrderExecution.Core.Interfaces;

/// <summary>
/// Interfaccia che espone i metodi per modificare posizioni pendenti di trading.
/// Permette la modifica di vari parametri come prezzo, stop loss, take profit, tipo di protezione, volume, trailing stop e metodi di trigger.
/// Supporta sia operazioni sincrone che asincrone tramite callback, con vari overload per gestire scenari avanzati.
/// </summary>
public interface IModifyPendingPositions
{
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod);
    ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips);

    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips, Action<ITradeResult> callback = null);
}