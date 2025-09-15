using System;
using StateManagement.Core.Interfaces;

namespace StateManagement.Core;

/// <summary>
/// Macchina a stati generica che gestisce il ciclo di vita degli stati e le transizioni.
/// Permette di aggiornare lo stato corrente, gestire transizioni e mantenere il contesto.
/// </summary>
/// <typeparam name="TContext">Tipo del contesto associato, deve implementare <see cref="IStateContext"/>.</typeparam>
/// <typeparam name="TState">Tipo dello stato, deve implementare <see cref="IState{TContext}"/>.</typeparam>
public class StateMachine<TContext, TState> : IStateMachine<TContext, TState>
    where TContext : IStateContext
    where TState : IState<TContext>
{
    /// <summary>
    /// Contesto associato alla macchina a stati.
    /// </summary>
    public TContext Context { get; private set; }

    /// <summary>
    /// Stato attualmente attivo.
    /// </summary>
    public TState CurrentState { get; private set; }

    /// <summary>
    /// Stato precedente.
    /// </summary>
    public TState PreviousState { get; private set; }

    /// <summary>
    /// Ultima transizione effettuata.
    /// </summary>
    public ITransition<TContext> LastTransition { get; private set; }

    /// <summary>
    /// Gestore delle transizioni tra stati.
    /// </summary>
    public ITransitionManager<TContext, TState> TransitionManager { get; }

    /// <summary>
    /// Costruttore della macchina a stati.
    /// </summary>
    /// <param name="context">Contesto da associare.</param>
    /// <param name="initialState">Stato iniziale.</param>
    /// <param name="transitionManager">Gestore delle transizioni.</param>
    /// <exception cref="ArgumentNullException">Se uno degli argomenti è nullo.</exception>
    public StateMachine(TContext context, TState initialState, ITransitionManager<TContext, TState> transitionManager)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        TransitionManager = transitionManager ?? throw new ArgumentNullException(nameof(transitionManager));
        CurrentState = initialState ?? throw new ArgumentNullException(nameof(initialState));
        CurrentState.OnEnter();
    }

    /// <summary>
    /// Aggiunge una transizione al gestore.
    /// </summary>
    public void AddTransition(ITransition<TContext> transition) => TransitionManager.AddTransition(transition);

    /// <summary>
    /// Rimuove una transizione dal gestore.
    /// </summary>
    public void RemoveTransition(ITransition<TContext> transition) => TransitionManager.RemoveTransition(transition);

    /// <summary>
    /// Cambia lo stato corrente, eseguendo OnExit sullo stato precedente e OnEnter sul nuovo stato.
    /// </summary>
    /// <param name="newState">Nuovo stato da attivare.</param>
    /// <param name="transition">Transizione che ha causato il cambio (opzionale).</param>
    /// <exception cref="ArgumentNullException">Se il nuovo stato è nullo.</exception>
    public void ChangeState(TState newState, ITransition<TContext> transition = null)
    {
        if (newState == null) throw new ArgumentNullException(nameof(newState));

        CurrentState?.OnExit();

        PreviousState = CurrentState;
        LastTransition = transition;

        CurrentState = newState;
        CurrentState.OnEnter();
    }

    /// <summary>
    /// Aggiorna la macchina a stati: verifica le transizioni e aggiorna lo stato corrente.
    /// </summary>
    public void Update()
    {
        CheckTransitions();
        CurrentState?.OnUpdate();
    }

    /// <summary>
    /// Aggiornamento a intervalli fissi dello stato corrente.
    /// </summary>
    public void FixedUpdate() => CurrentState?.OnFixedUpdate();

    /// <summary>
    /// Verifica se esistono transizioni valide dallo stato corrente e le esegue.
    /// </summary>
    private void CheckTransitions()
    {
        var validTransition = TransitionManager.GetValidTransition(CurrentState, Context);
        if (validTransition != null) ChangeState((TState)validTransition.TargetState, validTransition);
    }
}