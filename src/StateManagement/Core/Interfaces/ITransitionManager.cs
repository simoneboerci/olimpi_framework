namespace StateManagement.Core.Interfaces;

/// <summary>
/// Interfaccia che gestisce le transizioni tra stati in una macchina a stati.
/// Permette di aggiungere, rimuovere e trovare transizioni valide in base allo stato corrente e al contesto.
/// </summary>
/// <typeparam name="TContext">Tipo del contesto associato alle transizioni.</typeparam>
/// <typeparam name="TState">Tipo dello stato gestito dalla macchina a stati.</typeparam>
public interface ITransitionManager<TContext, TState> 
    where TContext : IStateContext 
    where TState : IState<TContext>
{
    /// <summary>
    /// Aggiunge una transizione al gestore.
    /// </summary>
    void AddTransition(ITransition<TContext> transition);

    /// <summary>
    /// Rimuove una transizione dal gestore.
    /// </summary>
    void RemoveTransition(ITransition<TContext> transition);

    /// <summary>
    /// Restituisce una transizione valida per lo stato corrente e il contesto, se esiste.
    /// </summary>
    /// <param name="currentState">Stato attuale della macchina a stati.</param>
    /// <param name="context">Contesto su cui valutare le condizioni di transizione.</param>
    /// <returns>Transizione valida se trovata, altrimenti null.</returns>
    ITransition<TContext> GetValidTransition(TState currentState, TContext context);
}