using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IExecuteCAlgoLimitOrders
{
    TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice);
    TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label);
    TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType);
    TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration);
    TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment);
    TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop);
    TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);

    TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, Action<TradeResult> callback = null);
    TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, Action<TradeResult> callback = null);
    TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null);
    TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, Action<TradeResult> callback = null);
    TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, Action<TradeResult> callback = null);
    TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, Action<TradeResult> callback = null);
    TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null);
}