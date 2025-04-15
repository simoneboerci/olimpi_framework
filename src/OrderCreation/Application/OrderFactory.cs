using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;
using OrderCreation.Core.Models;

namespace OrderCreation.Application;

public class OrderFactory : IOrderFactory
{
    public IMarketOrder CreateMarketOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop
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
            hasTrailingStop ?? false
        );
    }

    public IMarketRangeOrder CreateMarketRangeOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
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
            marketRangePips,
            basePrice
        );
    }

    public ILimitOrder CreateLimitOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
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
            targetPrice,
            expirationTime,
            protectionType
        );
    }

    public IStopOrder CreateStopOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice
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
            targetPrice,
            expirationTime,
            protectionType,
            stopOrderPips,
            basePrice
        );
    }

    public IStopLimitOrder CreateStopLimitOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string label,
        double? stopLossPips,
        double? takeProfitPips,
        string comment,
        bool? hasTrailingStop,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
        double stopLimitRangePips
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
            targetPrice,
            expirationTime,
            protectionType,
            stopOrderPips,
            basePrice,
            stopLimitRangePips
        );
    }
}