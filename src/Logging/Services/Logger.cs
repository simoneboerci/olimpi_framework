using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Services
{
    // Classe Logger che implementa l'interfaccia ILogger per gestire il logging
    public class Logger : ILogger
    {
        // Collezione dei provider che effettueranno le operazioni di scrittura del log
        private readonly IEnumerable<ILogProvider> _logProviders;

        // Costruttore che inizializza il logger con i provider specificati
        public Logger(IEnumerable<ILogProvider> logProviders)
        {
            _logProviders = logProviders;
        }

        // Metodo sincrono per il logging
        // Riceve una voce di log (LogEntry) e la manda a tutti i provider configurati
        public void Log(LogEntry entry)
        {
            // Cicla su ogni provider per invocare il metodo Write
            foreach (var provider in _logProviders)
            {
                try
                {
                    provider.Write(entry); // Scrive la voce di log tramite il provider
                }
                catch (Exception ex)
                {
                    // Gestisce eventuali errori e li segnala sulla console di errore
                    Console.Error.WriteLine($"Error logging: {ex.Message}");
                }
            }
        }

        // Metodo asincrono per il logging
        // Invia la voce di log a tutti i provider in parallelo
        public async Task LogAsync(LogEntry entry, Action callback = null)
        {
            // Lista per tenere traccia dei Task creati per ogni provider
            var tasks = new List<Task>();
            // Per ogni provider, esegue il logging in un Task separato
            foreach (var provider in _logProviders)
            {
                tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            // Richiama il metodo asincrono WriteAsync del provider
                            await provider.WriteAsync(entry, callback);
                        }
                        catch (Exception ex)
                        {
                            // Se avviene un errore, lo segnala sulla console di errore
                            Console.Error.WriteLine($"Error logging: {ex.Message}");
                        }
                    }));
            }
            // Attende che tutte le operazioni asincrone siano completate
            await Task.WhenAll(tasks);
            // Se è stato fornito un callback, lo invoca dopo il completamento di tutte le operazioni
            callback?.Invoke();
        }
    }
}