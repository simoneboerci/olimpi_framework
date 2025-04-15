using CAlgoInterface.Core.Models;

namespace CAlgoInterface.Core.Routing;

public interface ISymbolCommissionInfoMapper
{
    SymbolCommissionInfo FromCAlgoSymbol(cAlgo.API.Internals.Symbol cAlgoSymbol);
}