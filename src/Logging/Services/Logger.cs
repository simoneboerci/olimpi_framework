using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Services
{
    /// <summary>
    /// Implementazione dell'interfaccia <see cref="ILogger"/> per la gestione del logging.
    /// Utilizza una collezione di provider per scrivere le voci di log.
    /// </summary>
    public sealed class Logger : ILogger
    {
        /// <summary>
        /// Collezione dei provider che gestiscono le operazioni di scrittura del log.
        /// </summary>
        private readonly IEnumerable<ILogProvider> _logProviders;

        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="Logger"/>.
        /// </summary>
        /// <param name="logProviders">I provider utilizzati per scrivere le voci di log.</param>
        public Logger(IEnumerable<ILogProvider> logProviders)
        {
            _logProviders = logProviders;
        }

        /// <summary>
        /// Registra sincronicamente una voce di log inviandola a tutti i provider configurati.
        /// </summary>
        /// <param name="entry">La voce di log da registrare.</param>
        public void Log(LogEntry entry)
        {
            foreach (var provider in _logProviders)
            {
                try
                {
                    // Scrive la voce di log tramite il provider corrente.
                    provider.Write(entry);
                }
                catch (Exception ex)
                {
                    // Gestisce eventuali errori durante il logging e li segnala sulla console di errore.
                    Console.Error.WriteLine($"Error logging: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Registra asincronicamente una voce di log inviandola a tutti i provider in parallelo.
        /// </summary>
        /// <param name="entry">La voce di log da registrare.</param>
        /// <param name="callback">Azione opzionale da eseguire dopo il completamento del logging.</param>
        /// <returns>Un task che rappresenta l'operazione asincrona di logging.</returns>
        public async Task LogAsync(LogEntry entry, Action callback = null)
        {
            // Lista per tenere traccia delle operazioni asincrone di logging per ciascun provider
            var tasks = new List<Task>();
            foreach (var provider in _logProviders)
            {
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        // Invoca il metodo asincrono del provider per la scrittura della voce di log.
                        await provider.WriteAsync(entry, callback);
                    }
                    catch (Exception ex)
                    {
                        // Gestisce eventuali errori e li segnala sulla console di errore.
                        Console.Error.WriteLine($"Error logging: {ex.Message}");
                    }
                }));
            }
            // Attende il completamento di tutte le operazioni asincrone.
            await Task.WhenAll(tasks);
            // Se è stato fornito un callback, lo invoca dopo il completamento di tutte le operazioni.
            callback?.Invoke();
        }
    }
}