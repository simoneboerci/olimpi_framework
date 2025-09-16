namespace CAlgoInterface.Core.Enums;

/// <summary>
/// Enum che rappresenta il tipo di protezione applicata a un ordine di trading.
/// Può essere nessuna, relativa (basata sulla distanza) o assoluta (basata sul prezzo).
/// </summary>
public enum ProtectionType
{
    /// <summary>
    /// Nessuna protezione.
    /// </summary>
    None,

    /// <summary>
    /// Protezione relativa, basata sulla distanza dal prezzo corrente.
    /// </summary>
    Relative,

    /// <summary>
    /// Protezione assoluta, basata su un prezzo specifico.
    /// </summary>
    Absolute
}