using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IExecuteCAlgoStopOrders
{
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice);
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label);
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType);
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration);
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment);
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop);
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);
    TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod);

    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, Action<TradeResult> callback = null);
    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, Action<TradeResult> callback = null);
    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null);
    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, Action<TradeResult> callback = null);
    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, Action<TradeResult> callback = null);
    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, Action<TradeResult> callback = null);
    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null);
    TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod, Action<TradeResult> callback = null);
}