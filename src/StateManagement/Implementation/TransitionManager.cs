using System;
using System.Collections.Generic;
using System.Linq;
using StateManagement.Core.Interfaces;

namespace StateManagement.Implementation;

/// <summary>
/// Gestore delle transizioni tra stati.
/// Mantiene una lista di transizioni e fornisce metodi per aggiungere, rimuovere e verificare transizioni valide.
/// </summary>
/// <typeparam name="TContext">Tipo del contesto, deve implementare <see cref="IStateContext"/>.</typeparam>
/// <typeparam name="TState">Tipo dello stato, deve implementare <see cref="IState{TContext}"/>.</typeparam>
public class TransitionManager<TContext, TState> : ITransitionManager<TContext, TState>
    where TContext : IStateContext
    where TState : IState<TContext>
{
    // Lista interna delle transizioni registrate.
    private readonly IList<ITransition<TContext>> _transitions = new List<ITransition<TContext>>();

    /// <summary>
    /// Collezione in sola lettura delle transizioni registrate.
    /// </summary>
    public IReadOnlyCollection<ITransition<TContext>> Transitions => _transitions.ToList().AsReadOnly();

    /// <summary>
    /// Aggiunge una transizione alla lista.
    /// </summary>
    /// <param name="transition">Transizione da aggiungere.</param>
    /// <exception cref="ArgumentNullException">Se la transizione è nulla.</exception>
    public void AddTransition(ITransition<TContext> transition)
    {
        if (transition == null) throw new ArgumentNullException(nameof(transition));
        _transitions.Add(transition);
    }

    /// <summary>
    /// Rimuove una transizione dalla lista.
    /// </summary>
    /// <param name="transition">Transizione da rimuovere.</param>
    /// <exception cref="ArgumentNullException">Se la transizione è nulla.</exception>
    public void RemoveTransition(ITransition<TContext> transition)
    {
        if (transition == null) throw new ArgumentNullException(nameof(transition));
        _transitions.Remove(transition);
    }

    /// <summary>
    /// Restituisce la prima transizione valida per lo stato corrente e il contesto.
    /// </summary>
    /// <param name="currentState">Stato corrente.</param>
    /// <param name="context">Contesto associato.</param>
    /// <returns>Transizione valida, oppure null se nessuna è valida.</returns>
    public ITransition<TContext> GetValidTransition(TState currentState, TContext context)
    {
        foreach (var transition in _transitions)
        {
            // Verifica se la transizione parte dallo stato corrente e se la condizione è soddisfatta
            if (transition.SourceState.Equals(currentState) && transition.ShouldTransition(context))
            {
                return transition;
            }
        }

        return null;
    }
}