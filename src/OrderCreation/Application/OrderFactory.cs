using System;
using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Interfaces;
using OrderCreation.Core.Models;

namespace OrderCreation.Application;

/// <summary>
/// Implementazione dell'interfaccia <see cref="IOrderFactory"/>.
/// Fornisce metodi per la creazione di ordini di trading di diversi tipi (mercato, range, limite, stop, stop-limit).
/// Ogni metodo inizializza e restituisce un'istanza dell'ordine corrispondente, impostando tutti i parametri necessari.
/// </summary>
public class OrderFactory : IOrderFactory
{
    /// <summary>
    /// Crea un ordine di mercato.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine di mercato con range.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine limite.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine stop.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine stop-limit.
    /// </summary>
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