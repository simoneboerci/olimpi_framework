using CAlgoInterface.Core.Enums;

namespace CAlgoInterface.Core.Routing;

public interface ISymbolTradingModeMapper
{
    cAlgo.API.SymbolTradingMode ToCAlgoSymbolTradingMode(SymbolTradingMode symbolTradingMode);
    SymbolTradingMode ToSymbolTradingMode(cAlgo.API.SymbolTradingMode cAlgoSymbolTradingMode);
}