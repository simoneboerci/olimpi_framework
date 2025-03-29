namespace ConsoleOperations.Core.Interfaces
{
    /// <summary>
    /// Interfaccia per la creazione di istanze di <see cref="ISystemConsole"/>.
    /// Fornisce un metodo per ottenere una nuova implementazione concreta di un sistema console.
    /// </summary>
    public interface ISystemConsoleFactory
    {
        /// <summary>
        /// Crea e restituisce una nuova istanza di <see cref="ISystemConsole"/>.
        /// Il metodo permette di astrarre la logica di selezione della console in base al sistema operativo,
        /// consentendo differenti implementazioni (ad esempio per Windows o MacOS) senza esporre la logica
        /// specifica al chiamante.
        /// </summary>
        /// <returns>Un'istanza che implementa l'interfaccia <see cref="ISystemConsole"/>.</returns>
        ISystemConsole CreateSystemConsoleBasedOnPlatoform();
    }
}