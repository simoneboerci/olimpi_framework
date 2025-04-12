using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IExecuteCAlgoStopLimitOrders
{
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips);
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label);
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType);
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration);
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment);
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop);
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);
    TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod);

    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, Action<TradeResult> callback = null);
    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, Action<TradeResult> callback = null);
    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null);
    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, Action<TradeResult> callback = null);
    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, Action<TradeResult> callback = null);
    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, Action<TradeResult> callback = null);
    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null);
    TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod, Action<TradeResult> callback = null);

}