using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IExecuteCAlgoMarketRangeOrders
{
    TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice);
    TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label);
    TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips);
    TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment);
    TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop);
    TradeResult ExecuteMarketRangeOrder(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);

    TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketRangeOrderAsync(TradeType tradeType, string symbolName, double volume, double marketRangePips, double basePrice, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null);
}