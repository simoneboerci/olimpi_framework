using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Routing;

public interface ISymbolCommissionTypeMapper
{
    cAlgo.API.SymbolCommissionType ToCAlgoSymbolCommissionType(SymbolCommissionType symbolCommissionType);
    SymbolCommissionType FromCAlgoSymbolCommissionType(cAlgo.API.SymbolCommissionType cAlgoSymbolCommissionType);
}