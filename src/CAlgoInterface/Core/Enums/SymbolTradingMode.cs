namespace CAlgoInterface.Core.Enums;

public enum SymbolTradingMode
{
    //
    // Riepilogo:
    //     Full access mode.
    FullAccess,
    //
    // Riepilogo:
    //     Close only mode.
    CloseOnly,
    //
    // Riepilogo:
    //     Trading is disabled but pending order execution is allowed mode.
    DisabledWithPendingOrderExecution,
    //
    // Riepilogo:
    //     Trading is fully disabled mode.
    FullyDisabled
}