using System;
using System.Collections.Generic;

namespace StateManagement.Core.Interfaces;

/// <summary>
/// Interfaccia che rappresenta una transizione tra due stati in una macchina a stati.
/// Definisce lo stato di origine, lo stato di destinazione e le condizioni che devono essere soddisfatte per effettuare la transizione.
/// </summary>
/// <typeparam name="TContext">Tipo del contesto associato alla transizione.</typeparam>
public interface ITransition<TContext> where TContext : IStateContext
{
    /// <summary>
    /// Stato di origine della transizione.
    /// </summary>
    IState<TContext> SourceState { get; }

    /// <summary>
    /// Stato di destinazione della transizione.
    /// </summary>
    IState<TContext> TargetState { get; }

    /// <summary>
    /// Collezione di condizioni che devono essere soddisfatte per permettere la transizione.
    /// La chiave rappresenta il nome della condizione, il valore è una funzione che valuta la condizione sul contesto.
    /// </summary>
    IDictionary<string, Func<TContext, bool>> Conditions { get; }

    /// <summary>
    /// Determina se la transizione può essere effettuata in base al contesto fornito.
    /// </summary>
    /// <param name="context">Contesto su cui valutare le condizioni.</param>
    /// <returns>True se tutte le condizioni sono soddisfatte, altrimenti false.</returns>
    bool ShouldTransition(TContext context);
}