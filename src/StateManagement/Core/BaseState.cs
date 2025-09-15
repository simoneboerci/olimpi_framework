using StateManagement.Core.Interfaces;

namespace StateManagement.Core;

/// <summary>
/// Classe astratta che rappresenta uno stato generico all'interno di un contesto.
/// Implementa l'interfaccia <see cref="IState{TContext}"/> e fornisce metodi virtuali
/// per gestire gli eventi di ciclo di vita dello stato.
/// </summary>
/// <typeparam name="TContext">Il tipo di contesto associato allo stato, che deve implementare <see cref="IStateContext"/>.</typeparam>
public abstract class BaseState<TContext> : IState<TContext> where TContext : IStateContext
{
    /// <summary>
    /// Metodo chiamato quando lo stato viene attivato.
    /// Sovrascrivilo per gestire la logica di ingresso nello stato.
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// Metodo chiamato quando lo stato viene disattivato.
    /// Sovrascrivilo per gestire la logica di uscita dallo stato.
    /// </summary>
    public virtual void OnExit(){}

    /// <summary>
    /// Metodo chiamato ad intervalli fissi (tipicamente per logica di simulazione).
    /// Sovrascrivilo per gestire aggiornamenti periodici.
    /// </summary>
    public virtual void OnFixedUpdate(){}

    /// <summary>
    /// Metodo chiamato ad ogni aggiornamento.
    /// Sovrascrivilo per gestire la logica di aggiornamento continuo.
    /// </summary>
    public virtual void OnUpdate(){}
}