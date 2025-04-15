using CAlgoInterface.Core.Enums;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Backend.Integrations;

public class SymbolTradingModeMapper : ISymbolTradingModeMapper
{
    public cAlgo.API.SymbolTradingMode ToCAlgoSymbolTradingMode(SymbolTradingMode symbolTradingMode)
    {
        return symbolTradingMode switch
        {
            SymbolTradingMode.FullAccess => cAlgo.API.SymbolTradingMode.FullAccess,
            SymbolTradingMode.CloseOnly => cAlgo.API.SymbolTradingMode.CloseOnly,
            SymbolTradingMode.DisabledWithPendingOrderExecution => cAlgo.API.SymbolTradingMode.DisabledWithPendingOrderExecution,
            SymbolTradingMode.FullyDisabled => cAlgo.API.SymbolTradingMode.FullyDisabled,
            _ => throw new System.ArgumentOutOfRangeException(nameof(symbolTradingMode), symbolTradingMode, null)
        };
    }

    public SymbolTradingMode ToSymbolTradingMode(cAlgo.API.SymbolTradingMode cAlgoSymbolTradingMode)
    {
        return cAlgoSymbolTradingMode switch
        {
            cAlgo.API.SymbolTradingMode.FullAccess => SymbolTradingMode.FullAccess,
            cAlgo.API.SymbolTradingMode.CloseOnly => SymbolTradingMode.CloseOnly,
            cAlgo.API.SymbolTradingMode.DisabledWithPendingOrderExecution => SymbolTradingMode.DisabledWithPendingOrderExecution,
            cAlgo.API.SymbolTradingMode.FullyDisabled => SymbolTradingMode.FullyDisabled,
            _ => throw new System.ArgumentOutOfRangeException(nameof(cAlgoSymbolTradingMode), cAlgoSymbolTradingMode, null)
        };
    }
}