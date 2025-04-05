using System.Collections.Generic;

namespace StateManagement.Core.Interfaces;

public interface ITransitionManager<TContext, TState> where TContext : IStateContext where TState : IState<TContext>
{
    void AddTransition(ITransition<TContext> transition);
    void RemoveTransition(ITransition<TContext> transition);

    ITransition<TContext> GetValidTransition(TState currentState, TContext context);
}