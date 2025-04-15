using System;
using OrderCreation;
using OrderCreation.Core.Enums;
using OrderExecution.Core.Interfaces;

namespace OrderExecution.Application;

//TODO: IMPLEMENTARE LA CLASSE
public class PositionManager : IPositionManager
{
    public ITradeResult CancelPendingPosition(IPendingPosition pendingPosition)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync CancelPendingPositionAsync(IPendingPosition pendingPosition, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ClosePosition(IPosition position)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ClosePosition(IPosition position, long volume)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ClosePosition(IPosition position, double volume)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ClosePositionAsync(IPosition position, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ClosePositionAsync(IPosition position, long volume, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ClosePositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPendingPosition(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, long volume, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPendingPositionAsync(IPendingPosition pendingPosition, double targetPrice, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expirationTime, double volume, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod? stopOrderTriggerMethod, double? stopLimitRangePips, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPosition(IPosition position, double volume)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ReversePosition(IPosition position)
    {
        throw new NotImplementedException();
    }

    public ITradeResult ReversePosition(IPosition position, double volume)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ReversePositionAsync(IPosition position, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }

    public ITradeResultAsync ReversePositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null)
    {
        throw new NotImplementedException();
    }
}