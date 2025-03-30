using System;
using System.Collections.Generic;
using System.Linq;
using StateManagement.Core.Interfaces;

namespace StateManagement.Core;

public class TransitionManager<TContext, TState> : ITransitionManager<TContext, TState>
where TContext : IStateContext
where TState : IState<TContext>
{
    private readonly IList<ITransition<TContext>> _transitions = new List<ITransition<TContext>>();

    public IReadOnlyCollection<ITransition<TContext>> Transitions => _transitions.ToList().AsReadOnly();

    public void AddTransition(ITransition<TContext> transition)
    {
        if (transition == null) throw new ArgumentNullException(nameof(transition));
        _transitions.Add(transition);
    }

    public void RemoveTransition(ITransition<TContext> transition)
    {
        if (transition == null) throw new ArgumentNullException(nameof(transition));
        _transitions.Remove(transition);
    }

    public ITransition<TContext> GetValidTransition(TState currentState, TContext context)
    {
        foreach (var transition in _transitions)
        {
            if (transition.SourceState.Equals(currentState) && transition.ShouldTransition(context))
            {
                return transition;
            }
        }

        return null;
    }

}