using System;
using System.Diagnostics;
using ConsoleOperations.Core.Interfaces;

namespace ConsoleOperations.Data
{
    /// <summary>
    /// Classe astratta che implementa l'interfaccia ISystemConsole e contiene la logica di gestione di base delle console,
    /// tra cui l'avvio e la gestione del processo associato alla console.
    /// Le classi derivate (come WindowsConsole o altre implementazioni per differenti sistemi) devono implementare i metodi
    /// Start() e WriteLine(string text) per fornire il comportamento specifico.
    /// </summary>
    public abstract class SystemConsoleBase : ISystemConsole
    {
        /// <summary>
        /// Riferimento al processo della console avviato.
        /// Questo campo protegge l'istanza di Process utilizzata per interagire con la console eseguita.
        /// </summary>
        protected Process Process;

        /// <summary>
        /// Metodo virtuale per liberare le risorse legate al processo della console.
        /// Se il processo esiste ed è ancora attivo, viene terminato e successivamente smaltito.
        /// Infine, viene chiamato GC.SuppressFinalize(this) per evitare la chiamata del finalizzatore.
        /// </summary>
        public virtual void Dispose()
        {
            // Se il processo esiste e non è già terminato...
            if (Process != null && !Process.HasExited)
            {
                try
                {
                    // ...tenta di terminare il processo in esecuzione.
                    Process.Kill();
                }
                catch 
                {
                    // Ignora eventuali eccezioni: ad esempio il processo potrebbe terminarsi durante la chiamata.
                }
                finally
                {
                    // Smaltisce il processo per rilasciare le risorse associate.
                    Process.Dispose();
                }
            }
            // Indica al garbage collector di non invocare il finalizzatore per quest'istanza, migliorando le performance.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Avvia il processo della console.
        /// Le implementazioni concrete devono configurare correttamente e avviare il processo (es. cmd.exe su Windows).
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Scrive una riga di testo sulla console implementata.
        /// Le classi derivate devono definire il comportamento esatto, ad esempio utilizzando il comando "echo" su cmd.exe.
        /// </summary>
        /// <param name="text">Il testo da scrivere sulla console.</param>
        public abstract void WriteLine(string text);
    }
}