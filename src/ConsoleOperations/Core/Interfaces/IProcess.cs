using System.Diagnostics;

namespace ConsoleOperations.Core.Interfaces
{
    /// <summary>
    /// Interfaccia per la gestione dei processi di sistema.
    /// Fornisce un metodo per avviare un processo e ottenere l'istanza del processo avviato.
    /// In questo modo, le classi che implementano questa interfaccia possono astrarre
    /// la logica di configurazione ed esecuzione dei processi, rendendo il codice più modulare e testabile.
    /// </summary>
    public interface IProcess
    {
        /// <summary>
        /// Avvia il processo configurato e restituisce l'istanza di <see cref="Process"/> avviata.
        /// Questo metodo consente di eseguire i processi di sistema e di accedere alle loro proprietà,
        /// come ad esempio lo standard input/output, lo stato di esecuzione e altri parametri.
        /// </summary>
        /// <returns>Un'istanza del processo avviato.</returns>
        Process Start();
    }
}