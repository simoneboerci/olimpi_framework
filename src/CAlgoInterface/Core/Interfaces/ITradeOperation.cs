using System;
using System.Collections.Generic;
using CAlgoInterface.Core.Enums;

/// <summary>
/// Interfaccia che rappresenta un'operazione di trading.
/// Espone proprietà per identificatori, impatto sulla posizione, stato, tipo di trade, prezzo di esecuzione, volume, etichette, commenti, canale, tempi e relazioni con altre operazioni.
/// Può essere implementata per rappresentare sia operazioni di apertura che di chiusura.
/// </summary>
namespace CAlgoInterface.Core.Interfaces
{
    public interface ITradeOperation
    {
        /// <summary>
        /// Identificatore univoco dell'operazione di trading.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Identificatore della posizione associata.
        /// </summary>
        Guid PositionId { get; }

        /// <summary>
        /// Identificatore dell'ordine che ha generato l'operazione.
        /// </summary>
        Guid OrderId { get; }

        /// <summary>
        /// Identificatore del simbolo/strumento finanziario.
        /// </summary>
        Guid SymbolId { get; }

        /// <summary>
        /// Impatto dell'operazione sulla posizione (apertura/chiusura).
        /// </summary>
        TradeOperationPositionImpact PositionImpact { get; }

        /// <summary>
        /// Stato dell'operazione di trading.
        /// </summary>
        TradeOperationStatus Status { get; }

        /// <summary>
        /// Tipo di trade (Buy/Sell).
        /// </summary>
        TradeType TradeType { get; }

        /// <summary>
        /// Prezzo di esecuzione dell'operazione, se disponibile.
        /// </summary>
        double? ExecutionPrice { get; }

        /// <summary>
        /// Volume dell'operazione in unità.
        /// </summary>
        double VolumeInUnits { get; }

        /// <summary>
        /// Quantità dell'operazione in lotti.
        /// </summary>
        double QuantityInLots { get; }

        /// <summary>
        /// Etichetta associata all'operazione.
        /// </summary>
        string Label { get; }

        /// <summary>
        /// Commento associato all'operazione.
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// Canale di esecuzione dell'operazione.
        /// </summary>
        string Channel { get; }

        /// <summary>
        /// Data e ora di esecuzione dell'operazione.
        /// </summary>
        DateTime ExecutionTime { get; }

        /// <summary>
        /// Lista delle operazioni che hanno chiuso questa operazione.
        /// </summary>
        IReadOnlyList<ITradeOperation> ClosedBy { get; }

        /// <summary>
        /// Lista delle operazioni chiuse da questa operazione.
        /// </summary>
        IReadOnlyList<ITradeOperation> Closing { get; }
    }
}