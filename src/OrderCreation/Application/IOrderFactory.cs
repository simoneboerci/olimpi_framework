#nullable enable
using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Application;

public interface IOrderFactory
{
    IMarketOrder CreateMarketOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod
    );

    IMarketRangeOrder CreateMarketRangeOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double marketRangePips,
        double masePrice
    );

    ILimitOrder CreateLimitOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType
    );

    IStopOrder CreateStopOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
        StopTriggerMethod? stopOrderTriggerMethod
    );

    IStopLimitOrder CreateStopLimitOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
        double stopLimitRangePips,
        StopTriggerMethod? stopOrderTriggerMethod
    );
}