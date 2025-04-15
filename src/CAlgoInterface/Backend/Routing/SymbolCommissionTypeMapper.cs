using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public class SymbolCommisionTypeMapper : ISymbolCommissionTypeMapper
{
    public SymbolCommissionType FromCAlgoSymbolCommissionType(cAlgo.API.SymbolCommissionType cAlgoSymbolCommissionType)
    {
        return cAlgoSymbolCommissionType switch
        {
            cAlgo.API.SymbolCommissionType.UsdPerMillionUsdVolume => SymbolCommissionType.UsdPerMillionUsdVolume,
            cAlgo.API.SymbolCommissionType.UsdPerOneLot => SymbolCommissionType.UsdPerOneLot,
            cAlgo.API.SymbolCommissionType.PercentageOfTradingVolume => SymbolCommissionType.PercentageOfTradingVolume,
            cAlgo.API.SymbolCommissionType.QuoteCurrencyPerOneLot => SymbolCommissionType.QuoteCurrencyPerOneLot,
            _ => throw new System.NotImplementedException()
        };
    }

    public cAlgo.API.SymbolCommissionType ToCAlgoSymbolCommissionType(SymbolCommissionType symbolCommissionType)
    {
        return symbolCommissionType switch
        {
            SymbolCommissionType.UsdPerMillionUsdVolume => cAlgo.API.SymbolCommissionType.UsdPerMillionUsdVolume,
            SymbolCommissionType.UsdPerOneLot => cAlgo.API.SymbolCommissionType.UsdPerOneLot,
            SymbolCommissionType.PercentageOfTradingVolume => cAlgo.API.SymbolCommissionType.PercentageOfTradingVolume,
            SymbolCommissionType.QuoteCurrencyPerOneLot => cAlgo.API.SymbolCommissionType.QuoteCurrencyPerOneLot,
            _ => throw new System.NotImplementedException()
        };
    }
}