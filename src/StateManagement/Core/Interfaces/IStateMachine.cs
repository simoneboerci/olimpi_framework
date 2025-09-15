namespace StateManagement.Core.Interfaces
{
    /// <summary>
    /// Interfaccia che definisce una macchina a stati generica.
    /// Gestisce il contesto, lo stato corrente e le transizioni tra stati.
    /// </summary>
    /// <typeparam name="TContext">Tipo del contesto associato alla macchina a stati.</typeparam>
    /// <typeparam name="TState">Tipo dello stato gestito dalla macchina a stati.</typeparam>
    public interface IStateMachine<TContext, TState>
        where TContext : IStateContext
        where TState : IState<TContext>
    {
        /// <summary>
        /// Contesto condiviso tra gli stati.
        /// </summary>
        TContext Context { get; }

        /// <summary>
        /// Stato attualmente attivo nella macchina a stati.
        /// </summary>
        TState CurrentState { get; }

        /// <summary>
        /// Stato precedente prima dell'ultima transizione.
        /// </summary>
        TState PreviousState { get; }

        /// <summary>
        /// Ultima transizione eseguita.
        /// </summary>
        ITransition<TContext> LastTransition { get; }

        /// <summary>
        /// Gestore delle transizioni tra stati.
        /// </summary>
        ITransitionManager<TContext, TState> TransitionManager { get; }

        /// <summary>
        /// Aggiunge una transizione alla macchina a stati.
        /// </summary>
        void AddTransition(ITransition<TContext> transition);

        /// <summary>
        /// Rimuove una transizione dalla macchina a stati.
        /// </summary>
        void RemoveTransition(ITransition<TContext> transition);

        /// <summary>
        /// Cambia lo stato corrente, opzionalmente specificando una transizione.
        /// </summary>
        void ChangeState(TState newState, ITransition<TContext> transition = null);

        /// <summary>
        /// Aggiornamento normale della macchina a stati.
        /// </summary>
        void Update();

        /// <summary>
        /// Aggiornamento fisso della macchina a stati.
        /// </summary>
        void FixedUpdate();
    }
}