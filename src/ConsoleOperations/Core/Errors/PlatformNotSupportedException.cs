using System;

namespace ConsoleOperations.Core.Errors
{
    /// <summary>
    /// Eccezione personalizzata utilizzata per segnalare che la piattaforma corrente non è supportata.
    /// Estende <see cref="ConsoleOperationsException"/> per fornire una gestione coerente degli errori
    /// specifici dell'applicazione.
    /// </summary>
    public class PlatformNotSupportedException : ConsoleOperationsException
    {
        /// <summary>
        /// Costruttore predefinito che inizializza la eccezione con un messaggio di errore standard.
        /// </summary>
        public PlatformNotSupportedException()
            : base("The current platform is not supported.")
        {
        }

        /// <summary>
        /// Costruttore che consente di specificare un messaggio di errore personalizzato.
        /// </summary>
        /// <param name="message">Il messaggio di errore personalizzato.</param>
        public PlatformNotSupportedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Costruttore che consente di specificare un messaggio di errore personalizzato e un'eccezione interna.
        /// Questo aiuta a mantenere la traccia della causa originale dell'errore.
        /// </summary>
        /// <param name="message">Il messaggio di errore personalizzato.</param>
        /// <param name="innerException">L'eccezione interna che ha causato questo errore.</param>
        public PlatformNotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}