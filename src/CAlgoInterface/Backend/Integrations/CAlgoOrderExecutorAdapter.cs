using System;
using cAlgo.API;

namespace CAlgoInterface.Backend.Integrations;

public class CAlgoOrderExecutorAdapter : ICAlgoOrderExecutorAdapter
{
    private readonly Robot _cAlgoRobot;

    public CAlgoOrderExecutorAdapter(Robot cAlgoRobot) => _cAlgoRobot = cAlgoRobot;

    public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume) => _cAlgoRobot.ExecuteMarketOrder(tradeType, symbolName, volume);
    public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label) => _cAlgoRobot.ExecuteMarketOrder(tradeType, symbolName, volume, label);
    public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips) => 
        _cAlgoRobot.ExecuteMarketOrder(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips);
    public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment) => 
        _cAlgoRobot.ExecuteMarketOrder(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment);
    public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop) => 
        _cAlgoRobot.ExecuteMarketOrder(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop);
    public TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod) => 
        _cAlgoRobot.ExecuteMarketOrder(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod);

    public TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketOrderAsync(tradeType, symbolName, volume, callback);
    public TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketOrderAsync(tradeType, symbolName, volume, label, callback);
    public TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketOrderAsync(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, callback);
    public TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketOrderAsync(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, callback);
    public TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketOrderAsync(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, callback);
    public TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketOrderAsync(tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod, callback);

    public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice) => _cAlgoRobot.ExecuteMarketRangeOrder(tradeType, symbolName, volume, marketRangePips, basePrice);
    public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label) => 
        _cAlgoRobot.ExecuteMarketRangeOrder(tradeType, symbolName, volume, marketRangePips, basePrice, label);
    public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips) => 
        _cAlgoRobot.ExecuteMarketRangeOrder(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips);
    public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment) => 
        _cAlgoRobot.ExecuteMarketRangeOrder(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, comment);
    public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop) => 
        _cAlgoRobot.ExecuteMarketRangeOrder(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, comment, hasTrailingStop);
    public TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod) => 
        _cAlgoRobot.ExecuteMarketRangeOrder(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod);

    public TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketRangeOrderAsync(tradeType, symbolName, volume, marketRangePips, basePrice, callback);
    public TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketRangeOrderAsync(tradeType, symbolName, volume, marketRangePips, basePrice, label, callback);
    public TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketRangeOrderAsync(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, callback);
    public TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, Action<TradeResult> callback = null) =>     
        _cAlgoRobot.ExecuteMarketRangeOrderAsync(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, comment, callback);
    public TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketRangeOrderAsync(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, callback);
    public TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null) => 
        _cAlgoRobot.ExecuteMarketRangeOrderAsync(tradeType, symbolName, volume, marketRangePips, basePrice, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod, callback);

    public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice) => _cAlgoRobot.PlaceLimitOrder(tradeType, symbolName, volume, targetPrice);
    public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label) => 
        _cAlgoRobot.PlaceLimitOrder(tradeType, symbolName, volume, targetPrice, label);
    public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType) => 
        _cAlgoRobot.PlaceLimitOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType);
    public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration) => 
        _cAlgoRobot.PlaceLimitOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration);
    public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment) => 
        _cAlgoRobot.PlaceLimitOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment);
    public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop) => 
        _cAlgoRobot.PlaceLimitOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop);
    public TradeResult PlaceLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod) => 
        _cAlgoRobot.PlaceLimitOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod);

    public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, Action<TradeResult> callback = null) =>
        _cAlgoRobot.PlaceLimitOrderAsync(tradeType, symbolName, volume, targetPrice, callback);
    public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceLimitOrderAsync(tradeType, symbolName, volume, targetPrice, label, callback);
    public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceLimitOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, callback);
    public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceLimitOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, callback);
    public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceLimitOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, callback);
    public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceLimitOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, callback);
    public TradeOperation PlaceLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceLimitOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod, callback);

    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips) => _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips);
    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label) => 
        _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label);
    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType) => 
        _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType);
    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration) => 
        _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration);
    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment) => 
        _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment);
    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop) => 
        _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop);
    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod) => 
        _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod);
    public TradeResult PlaceStopLimitOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod) => 
        _cAlgoRobot.PlaceStopLimitOrder(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod);

    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, callback);
    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, callback);
    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null) => _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, callback);
    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, callback);
    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, Action<TradeResult> callback = null) =>  _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment, callback);
    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, callback);
    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod, callback);
    public TradeOperation PlaceStopLimitOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, double stopLimitRangePips, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopLimitOrderAsync(tradeType, symbolName, volume, targetPrice, stopLimitRangePips, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod, callback);

    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice) => _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice);
    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label) => 
        _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice, label);
    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType) => 
        _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType);
    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration) => 
        _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration);
    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment) => 
        _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment);
    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop) => 
        _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop);
    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod) => 
        _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod);
    public TradeResult PlaceStopOrder(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod) => 
        _cAlgoRobot.PlaceStopOrder(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod);

    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, callback);
    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, label, callback);
    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, callback);
    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, callback);
    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, callback);
    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, callback);
    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod, callback);
    public TradeOperation PlaceStopOrderAsync(TradeType tradeType, string symbolName, double volume, double targetPrice, string label, double? stopLoss, double? takeProfit, ProtectionType? protectionType, DateTime? expiration, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, StopTriggerMethod stopOrderTriggerMethod, Action<TradeResult> callback = null) => 
        _cAlgoRobot.PlaceStopOrderAsync(tradeType, symbolName, volume, targetPrice, label, stopLoss, takeProfit, protectionType, expiration, comment, hasTrailingStop, stopLossTriggerMethod, stopOrderTriggerMethod, callback);
}