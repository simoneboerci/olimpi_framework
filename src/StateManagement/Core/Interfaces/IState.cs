namespace StateManagement.Core.Interfaces
{
    /// <summary>
    /// Interfaccia che definisce il comportamento di uno stato in una macchina a stati.
    /// Ogni stato può gestire le transizioni tramite i metodi di ciclo di vita:
    /// OnEnter, OnFixedUpdate, OnUpdate e OnExit.
    /// </summary>
    /// <typeparam name="TContext">
    /// Tipo del contesto associato allo stato, utile per accedere a dati condivisi.
    /// </typeparam>
    public interface IState<TContext>
    {
        /// <summary>
        /// Metodo chiamato quando lo stato viene attivato.
        /// </summary>
        void OnEnter();

        /// <summary>
        /// Metodo chiamato ad ogni aggiornamento fisso (tipicamente per logica temporizzata).
        /// </summary>
        void OnFixedUpdate();

        /// <summary>
        /// Metodo chiamato ad ogni aggiornamento normale (tipicamente per logica di gioco).
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// Metodo chiamato quando lo stato viene disattivato.
        /// </summary>
        void OnExit();
    }
}
