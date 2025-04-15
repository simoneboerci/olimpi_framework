using cAlgo.API.Internals;
using CAlgoInterface.Core.Models;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Routing;

public class SymbolCommissionInfoMapper : ISymbolCommissionInfoMapper
{
    private readonly ISymbolCommissionTypeMapper _symbolCommissionTypeMapper;

    public SymbolCommissionInfoMapper(
        ISymbolCommissionTypeMapper symbolCommissionTypeMapper
    )
    {
        _symbolCommissionTypeMapper = symbolCommissionTypeMapper;
    } 

    public SymbolCommissionInfo FromCAlgoSymbol(Symbol cAlgoSymbol)
    {
        return new SymbolCommissionInfo(
            cAlgoSymbol.Commission,
            _symbolCommissionTypeMapper.FromCAlgoSymbolCommissionType(cAlgoSymbol.CommissionType),
            cAlgoSymbol.MinCommission,
            cAlgoSymbol.AdministrativeCharge3DaysRollover,
            cAlgoSymbol.AdministrativeCharge
        );
    }
}