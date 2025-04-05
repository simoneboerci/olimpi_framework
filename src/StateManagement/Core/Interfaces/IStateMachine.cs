using System.Collections.Generic;

namespace StateManagement.Core.Interfaces
{
    public interface IStateMachine<TContext, TState>
        where TContext : IStateContext
        where TState : IState<TContext>
    {
        TContext Context { get; }
        TState CurrentState { get; }
        TState PreviousState { get; }
        ITransition<TContext> LastTransition { get; }

        ITransitionManager<TContext, TState> TransitionManager { get; }

        void AddTransition(ITransition<TContext> transition);
        void RemoveTransition(ITransition<TContext> transition);
        void ChangeState(TState newState, ITransition<TContext> transition = null);
        void Update();
        void FixedUpdate();
    }
}