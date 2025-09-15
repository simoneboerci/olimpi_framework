namespace OrderExecution.Core.Enums;

/// <summary>
/// Enum che rappresenta l'impatto di un'operazione di trading sulla posizione.
/// Può indicare se l'operazione apre una nuova posizione oppure ne chiude una esistente.
/// </summary>
public enum TradeOperationPositionImpact
{
    /// <summary>
    /// L'operazione apre una nuova posizione.
    /// </summary>
    Opening,

    /// <summary>
    /// L'operazione chiude una posizione esistente.
    /// </summary>
    Closing
}