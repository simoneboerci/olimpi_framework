using System;
using cAlgo.API;

namespace CAlgoInterface.Core.Interfaces;

public interface IExecuteCAlgoMarketOrders
{
    TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume);
    TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label);
    TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips);
    TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment);
    TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop);
    TradeResult ExecuteMarketOrder(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod);

    TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, Action<TradeResult> callback = null);
    TradeOperation ExecuteMarketOrderAsync(TradeType tradeType, string symbolName, double volume, string label, double? stopLossPips, double? takeProfitPips, string comment, bool hasTrailingStop, StopTriggerMethod? stopLossTriggerMethod, Action<TradeResult> callback = null);
}