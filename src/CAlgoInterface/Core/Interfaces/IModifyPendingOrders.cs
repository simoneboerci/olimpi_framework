using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IModifyPendingOrders
{
    #region  Modify Pending Orders

    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod);
    TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips);

    #endregion

    #region Modify Pending Orders Async

    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, Action<TradeResult> callback = null);
    TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips, Action<TradeResult> callback = null);

    #endregion
}