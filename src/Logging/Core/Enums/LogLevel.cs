namespace Logging.Core.Enums
{
    // Enum che rappresenta i possibili livelli di log.
    // Viene utilizzato per classificare la gravità dei messaggi di log.
    public enum LogLevel
    {
        // Livello informativo: per messaggi di routine che tracciano il normale funzionamento dell'applicazione.
        Info,
        // Livello debug: per dettagli utili allo sviluppo e alla risoluzione di problemi.
        Debug,
        // Livello warning: per segnalare situazioni potenzialmente problematiche che non interrompono l'esecuzione.
        Warning,
        // Livello error: per indicare errori che richiedono attenzione.
        Error,
        // Livello critico: per errori gravi che possono compromettere il corretto funzionamento dell'applicazione.
        Critical
    }
}