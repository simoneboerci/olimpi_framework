using System;
using System.Collections.Generic;
using StateManagement.Core.Interfaces;

namespace StateManagement.Core;

public class StateMachine<TContext, TState> : IStateMachine<TContext, TState>
    where TContext : IStateContext
    where TState : IState<TContext>
{
    public TContext Context { get; private set; }
    public TState CurrentState { get; private set; }
    public TState PreviousState { get; private set; }
    public ITransition<TContext> LastTransition { get; private set; }

    public ITransitionManager<TContext, TState> TransitionManager { get; }

    public StateMachine(TContext context, TState initialState, ITransitionManager<TContext, TState> transitionManager)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        TransitionManager = transitionManager ?? throw new ArgumentNullException(nameof(transitionManager));
        CurrentState = initialState ?? throw new ArgumentNullException(nameof(initialState));
        CurrentState.OnEnter();
    }

    public void AddTransition(ITransition<TContext> transition) => TransitionManager.AddTransition(transition);
    public void RemoveTransition(ITransition<TContext> transition) => TransitionManager.RemoveTransition(transition);

    public void ChangeState(TState newState, ITransition<TContext> transition = null)
    {
        if (newState == null) throw new ArgumentNullException(nameof(newState));

        CurrentState?.OnExit();

        PreviousState = CurrentState;
        LastTransition = transition;

        CurrentState = newState;
        CurrentState.OnEnter();
    }

    public void Update()
    {
        CheckTransitions();
        CurrentState?.OnUpdate();
    }
    public void FixedUpdate() => CurrentState?.OnFixedUpdate();

    private void CheckTransitions()
    {
        var validTransition = TransitionManager.GetValidTransition(CurrentState, Context);
        if (validTransition != null) ChangeState((TState)validTransition.TargetState, validTransition);
    }
}