using System;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    /// <summary>
    /// La classe ConsoleLogProvider gestisce il logging in console.
    /// Estende BaseLogProvider per utilizzare un formatter comune e implementa i metodi sincrono e asincrono per la scrittura dei log.
    /// Implementa inoltre IDisposable per la gestione delle risorse del sistema console.
    /// </summary>
    public class ConsoleLogProvider : BaseLogProvider, IDisposable
    {
        // Istanza di ISystemConsole per interagire con la console.
        private readonly ISystemConsole _systemConsole;

        /// <summary>
        /// Inizializza una nuova istanza di ConsoleLogProvider.
        /// Avvia il servizio di system console.
        /// </summary>
        /// <param name="formatter">Il formatter usato per formattare le entry di log.</param>
        /// <param name="systemConsole">L'interfaccia per la gestione della console.</param>
        public ConsoleLogProvider(ILogFormatter formatter, ISystemConsole systemConsole) : base(formatter)
        {
            _systemConsole = systemConsole;
            // Avvia eventuali operazioni di configurazione della console (es. apertura stream, configurazione del colore, ecc.).
            _systemConsole.Start();
        }

        /// <summary>
        /// Scrive sincronicamente una voce di log sulla console.
        /// Utilizza il formatter ereditato per formattare l'entry prima di inviarla alla console.
        /// </summary>
        /// <param name="entry">L'entry di log da scrivere.</param>
        public override void Write(LogEntry entry)
        {
            // Format dell'entry utilizzando il formatter definito in BaseLogProvider.
            string formatted = FormatLogEntry(entry);
            // Scrive il log formattato sulla console.
            _systemConsole.WriteLine(formatted);
        }

        /// <summary>
        /// Scrive asincronicamente una voce di log sulla console.
        /// Avvolge la chiamata sincrona in un Task per eseguire l'operazione in maniera non bloccante.
        /// Se viene fornito un callback, lo invoca al termine della scrittura.
        /// </summary>
        /// <param name="entry">L'entry di log da scrivere.</param>
        /// <param name="callback">Azione opzionale da eseguire al termine della scrittura.</param>
        /// <returns>Un task che rappresenta l'operazione asincrona.</returns>
        public override Task WriteAsync(LogEntry entry, Action callback = null)
        {
            // Esegue la scrittura in maniera asincrona.
            return Task.Run(() =>
            {
                // Richiama il metodo sincrono Write per scrivere il log.
                Write(entry);
                // Invoca il callback, se definito.
                callback?.Invoke();
            });
        }

        /// <summary>
        /// Libera le risorse gestite dalla classe, in particolare quelle della system console.
        /// </summary>
        public void Dispose()
        {
            _systemConsole.Dispose();
        }
    }
}