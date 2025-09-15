#nullable enable
using System;
using OrderCreation.Core.Enums;
using OrderCreation.Core.Interfaces;

namespace OrderCreation.Application;

/// <summary>
/// Interfaccia che espone i metodi per la creazione di ordini di trading.
/// Permette di generare ordini di mercato, range, limite, stop e stop-limit, specificando tutti i parametri necessari.
/// Ogni metodo restituisce un'istanza dell'ordine corrispondente.
/// </summary>
public interface IOrderFactory
{
    /// <summary>
    /// Crea un ordine di mercato.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine di mercato con range.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine limite.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine stop.
    /// </summary>
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

    /// <summary>
    /// Crea un ordine stop-limit.
    /// </summary>
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