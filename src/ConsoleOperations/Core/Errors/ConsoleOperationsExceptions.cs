using System;

namespace ConsoleOperations.Core.Errors
{
    /// <summary>
    /// Eccezione base per gli errori specifici dell'applicazione Console Operations.
    /// Estende la classe Exception per fornire messaggi di errore standardizzati e una gestione coerente degli errori.
    /// </summary>
    public class ConsoleOperationsException : Exception
    {
        /// <summary>
        /// Costruttore predefinito che inizializza l'eccezione con un messaggio standard.
        /// </summary>
        public ConsoleOperationsException() 
            : base("Console Operations: An error occurred.") 
        { 
        }

        /// <summary>
        /// Costruttore che accetta un messaggio personalizzato.
        /// Il messaggio fornito viene preceduto dalla dicitura "Console Operations:" per mantenere un formato uniforme.
        /// </summary>
        /// <param name="message">Il messaggio di errore personalizzato.</param>
        public ConsoleOperationsException(string message) 
            : base($"Console Operations: {message}") 
        { 
        }

        /// <summary>
        /// Costruttore che accetta un messaggio personalizzato e un'eccezione interna.
        /// Questo permette di mantenere la traccia della causa originale dell'errore.
        /// </summary>
        /// <param name="message">Il messaggio di errore personalizzato.</param>
        /// <param name="innerException">L'eccezione interna che ha causato questo errore.</param>
        public ConsoleOperationsException(string message, Exception innerException) 
            : base($"Console Operations: {message}", innerException) 
        { 
        }
    }
}