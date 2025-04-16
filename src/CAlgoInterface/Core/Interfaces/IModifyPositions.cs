using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IModifyPositions
{
    #region Modify Positions

    TradeResult ModifyPosition(Position position, double volume);
    TradeResult ModifyPosition(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType);
    TradeResult ModifyPosition(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop);
    TradeResult ModifyPosition(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);

    #endregion

    #region Modify Positions Async

    TradeOperation ModifyPositionAsync(Position position, double volume, Action<TradeResult> callback = null);
    TradeOperation ModifyPositionAsync(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null);
    TradeOperation ModifyPositionAsync(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, Action<TradeResult> callback = null);
    TradeOperation ModifyPositionAsync(Position position, double? stopLoss, double? takeProfit, ProtectionType? protectionType, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null);

    #endregion
}