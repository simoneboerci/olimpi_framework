using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;
using OrderCreation.Core.Models;

namespace OrderCreation.Application;

public class OrderFactory : IOrderFactory
{
    public IMarketOrder CreateMarketOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod
    )
    {
        return new MarketOrder(
            id,
            tradeType,
            symbolName,
            volume ?? 1.0,
            label ?? string.Empty,
            stopLossPips,
            takeProfitPips,
            comment ?? string.Empty,
            hasTrailingStop ?? false,
            stopLossTriggerMethod
        );
    }

    public IMarketRangeOrder CreateMarketRangeOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double marketRangePips,
        double basePrice
    )
    {
        return new MarketRangeOrder(
            id,
            tradeType,
            symbolName,
            volume ?? 1.0,
            label ?? string.Empty,
            stopLossPips,
            takeProfitPips,
            comment ?? string.Empty,
            hasTrailingStop ?? false,
            stopLossTriggerMethod,
            marketRangePips,
            basePrice
        );
    }

    public ILimitOrder CreateLimitOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType
    )
    {
        return new LimitOrder(
            id,
            tradeType,
            symbolName,
            volume ?? 1.0,
            label ?? string.Empty,
            stopLossPips,
            takeProfitPips,
            comment ?? string.Empty,
            hasTrailingStop ?? false,
            stopLossTriggerMethod,
            targetPrice,
            expirationTime,
            protectionType
        );
    }

    public IStopOrder CreateStopOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
        StopTriggerMethod? stopOrderTriggerMethod
    )
    {
        return new StopOrder(
            id,
            tradeType,
            symbolName,
            volume ?? 1.0,
            label ?? string.Empty,
            stopLossPips,
            takeProfitPips,
            comment ?? string.Empty,
            hasTrailingStop ?? false,
            stopLossTriggerMethod,
            targetPrice,
            expirationTime,
            protectionType,
            stopOrderPips,
            basePrice,
            stopOrderTriggerMethod
        );
    }

    public IStopLimitOrder CreateStopLimitOrder(
        Guid id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
        StopTriggerMethod? stopLossTriggerMethod,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
        double stopLimitRangePips,
        StopTriggerMethod? stopOrderTriggerMethod
    )
    {
        return new StopLimitOrder(
            id,
            tradeType,
            symbolName,
            volume ?? 1.0,
            label ?? string.Empty,
            stopLossPips,
            takeProfitPips,
            comment ?? string.Empty,
            hasTrailingStop ?? false,
            stopLossTriggerMethod,
            targetPrice,
            expirationTime,
            protectionType,
            stopOrderPips,
            basePrice,
            stopOrderTriggerMethod,
            stopLimitRangePips
        );
    }
}