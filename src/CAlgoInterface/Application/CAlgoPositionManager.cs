using System;
using cAlgo.API;

namespace CAlgoInterface.Application;

public class CAlgoPositionManager : ICAlgoPositionManager
{
    private readonly Robot _cAlgoRobot;

    public CAlgoPositionManager(Robot cAlgoRobot) => _cAlgoRobot = cAlgoRobot;

    #region Cancel Pending Orders

    public TradeResult CancelPendingOrder(PendingOrder pendingOrder) => _cAlgoRobot.CancelPendingOrder(pendingOrder);

    #endregion

    #region  Cancel Pending Orders Async

    public TradeOperation CancelPendingOrderAsync(PendingOrder pendingOrder, Action<TradeResult> callback = null) => _cAlgoRobot.CancelPendingOrderAsync(pendingOrder, callback);

    #endregion

    #region  Close Positions

    public TradeResult ClosePosition(Position position) => _cAlgoRobot.ClosePosition(position);
    public TradeResult ClosePosition(Position position, long volume) => _cAlgoRobot.ClosePosition(position, volume);
    public TradeResult ClosePosition(Position position, double volume) => _cAlgoRobot.ClosePosition(position, volume);

    #endregion

    #region Close Positions Async

    public TradeOperation ClosePositionAsync(Position position, Action<TradeResult> callback = null) => _cAlgoRobot.ClosePositionAsync(position, callback);
    public TradeOperation ClosePositionAsync(Position position, long volume, Action<TradeResult> callback = null) => _cAlgoRobot.ClosePositionAsync(position, volume, callback);
    public TradeOperation ClosePositionAsync(Position position, double volume, Action<TradeResult> callback = null) => _cAlgoRobot.ClosePositionAsync(position, volume, callback);

    #endregion

    #region  Modify Pending Orders

    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop, stopLossTriggerMethod);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod);
    public TradeResult ModifyPendingOrder(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips) => _cAlgoRobot.ModifyPendingOrder(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod, stopLimitRangePips);

    #endregion

    #region  Modify Pending Orders Async

    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop, stopLossTriggerMethod, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod, callback);
    public TradeOperation ModifyPendingOrderAsync(PendingOrder pendingOrder, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPendingOrderAsync(pendingOrder, targetPrice, stopLoss, takeProfit, protectionType, expirationTime, volume, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod, stopLimitRangePips, callback);

    #endregion

    #region Modify Positions

    public TradeResult ModifyPosition(Position position, double volume) => _cAlgoRobot.ModifyPosition(position, volume);
    public TradeResult ModifyPosition(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType) => _cAlgoRobot.ModifyPosition(position, stopLoss, takeProfit, protectionType);
    public TradeResult ModifyPosition(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop) => _cAlgoRobot.ModifyPosition(position, stopLoss, takeProfit, protectionType, hasTrailingStop);
    public TradeResult ModifyPosition(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod) => _cAlgoRobot.ModifyPosition(position, stopLoss, takeProfit, protectionType, hasTrailingStop, stopLossTriggerMethod);

    #endregion

    #region Modify Positions Async

    public TradeOperation ModifyPositionAsync(Position position, double volume, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPositionAsync(position, volume, callback);
    public TradeOperation ModifyPositionAsync(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPositionAsync(position, stopLoss, takeProfit, protectionType, callback);
    public TradeOperation ModifyPositionAsync(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPositionAsync(position, stopLoss, takeProfit, protectionType, hasTrailingStop, callback);
    public TradeOperation ModifyPositionAsync(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null) => _cAlgoRobot.ModifyPositionAsync(position, stopLoss, takeProfit, protectionType, hasTrailingStop, stopLossTriggerMethod, callback);

    #endregion

    #region Reverse Positions

    public TradeResult ReversePosition(Position position) => _cAlgoRobot.ReversePosition(position);
    public TradeResult ReversePosition(Position position, double volume) => _cAlgoRobot.ReversePosition(position, volume);

    #endregion

    #region Reverse Positions Async

    public TradeOperation ReversePositionAsync(Position position, Action<TradeResult> callback = null) => _cAlgoRobot.ReversePositionAsync(position, callback);
    public TradeOperation ReversePositionAsync(Position position, double volume, Action<TradeResult> callback = null) => _cAlgoRobot.ReversePositionAsync(position, volume, callback);

    #endregion
}