namespace CAlgoInterface.Core.Enums;

public enum SymbolCommissionType
{
    //
    // Riepilogo:
    //     Commission is in USD per millions USD volume.
    UsdPerMillionUsdVolume,
    //
    // Riepilogo:
    //     Commission is in USD per one symbol lot.
    UsdPerOneLot,
    //
    // Riepilogo:
    //     Commission is in Percentage of trading volume.
    PercentageOfTradingVolume,
    //
    // Riepilogo:
    //     Commission is in symbol quote asset / currency per one lot.
    QuoteCurrencyPerOneLot
}