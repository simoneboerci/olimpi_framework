using System;
using OrderCreation;
using OrderCreation.Core.Enums;

namespace OrderExecution.Core.Interfaces;

public interface IModifyPositions
{
    ITradeResult ModifyPosition(IPosition position, double volume);
    ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType);
    ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop);
    ITradeResult ModifyPosition(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);

    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, Action<ITradeResult> callback = null);
    ITradeResultAsync ModifyPositionAsync(IPosition position, double volume, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<ITradeResult> callback = null);
}