namespace OrderExecution.Core.Enums;

public enum TradeOperationStatus
{
    Filled,
    PartiallyFilled,
    Rejected,
    Error,
    Missed,
    InternallyRejected,
}