namespace OrderExecution.Core.Enums;

/// <summary>
/// Enum che rappresenta lo stato di un'operazione di trading.
/// Indica se l'operazione è stata eseguita, parzialmente eseguita, rifiutata, ha generato errore, è stata persa o rifiutata internamente.
/// </summary>
public enum TradeOperationStatus
{
    /// <summary>
    /// L'operazione è stata completamente eseguita.
    /// </summary>
    Filled,

    /// <summary>
    /// L'operazione è stata eseguita solo parzialmente.
    /// </summary>
    PartiallyFilled,

    /// <summary>
    /// L'operazione è stata rifiutata dal broker o dal sistema.
    /// </summary>
    Rejected,

    /// <summary>
    /// Si è verificato un errore durante l'esecuzione dell'operazione.
    /// </summary>
    Error,

    /// <summary>
    /// L'operazione non è stata eseguita (missed).
    /// </summary>
    Missed,

    /// <summary>
    /// L'operazione è stata rifiutata internamente dal sistema.
    /// </summary>
    InternallyRejected,
}