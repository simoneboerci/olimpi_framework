#nullable enable
using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Application;

public interface IOrderFactory
{
    IMarketOrder CreateMarketOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop
    );

    IMarketRangeOrder CreateMarketRangeOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        double marketRangePips,
        double masePrice
    );

    ILimitOrder CreateLimitOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType
    );

    IStopOrder CreateStopOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice
    );

    IStopLimitOrder CreateStopLimitOrder(
        int id,
        TradeType tradeType,
        string symbolName,
        double? volume,
        string? label,
        double? stopLossPips,
        double? takeProfitPips,
        string? comment,
        bool? hasTrailingStop,
        double targetPrice,
        DateTime? expirationTime,
        ProtectionType? protectionType,
        double stopOrderPips,
        double basePrice,
        double stopLimitRangePips
    );
}