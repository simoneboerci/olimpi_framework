namespace CAlgoInterface.Core.Enums;

/// <summary>
/// Enum che rappresenta il metodo di trigger utilizzato per attivare ordini Stop e Stop Loss.
/// Ogni valore definisce la logica di prezzo e conferma necessaria per attivare l'ordine.
/// </summary>
public enum StopTriggerMethod
{
    /// <summary>
    /// Usa il comportamento di trigger predefinito per gli ordini Stop.
    /// Buy e Stop Loss per Sell vengono attivati quando Ask >= prezzo ordine.
    /// Sell e Stop Loss per Buy vengono attivati quando Bid <= prezzo ordine.
    /// </summary>
    Trade,

    /// <summary>
    /// Usa il prezzo opposto per il trigger dell'ordine.
    /// Buy e Stop Loss per Sell vengono attivati quando Bid >= prezzo ordine.
    /// Sell e Stop Loss per Buy vengono attivati quando Ask <= prezzo ordine.
    /// </summary>
    Opposite,

    /// <summary>
    /// Usa i prezzi predefiniti, ma richiede conferma: due Ask consecutivi >= prezzo ordine per Buy/Stop Loss Sell,
    /// due Bid consecutivi <= prezzo ordine per Sell/Stop Loss Buy.
    /// </summary>
    DoubleTrade,

    /// <summary>
    /// Usa prezzi opposti e richiede conferma: due Bid consecutivi >= prezzo ordine per Buy/Stop Loss Sell,
    /// due Ask consecutivi <= prezzo ordine per Sell/Stop Loss Buy.
    /// </summary>
    DoubleOpposite
}