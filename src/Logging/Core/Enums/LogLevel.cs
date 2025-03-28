namespace Logging.Core.Enums
{
    /// <summary>
    /// Enum che rappresenta i possibili livelli di log.
    /// Viene utilizzato per classificare la gravità dei messaggi di log.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Livello informativo: per messaggi di routine che tracciano il normale funzionamento dell'applicazione.
        /// </summary>
        Info,
        /// <summary>
        /// Livello debug: per dettagli utili allo sviluppo e alla risoluzione di problemi.
        /// </summary>
        Debug,
        /// <summary>
        /// Livello warning: per segnalare situazioni potenzialmente problematiche che non interrompono l'esecuzione.
        /// </summary>
        Warning,
        /// <summary>
        /// Livello error: per indicare errori che richiedono attenzione.
        /// </summary>
        Error,
        /// <summary>
        /// Livello critico: per errori gravi che possono compromettere il corretto funzionamento dell'applicazione.
        /// </summary>
        Critical
    }
}