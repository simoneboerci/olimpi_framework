using System;
using System.Threading.Tasks;
using Logging.Core.Interfaces;
using Logging.Core.Models;

namespace Logging.Data.Providers
{
    // La classe ConsoleLogProvider gestisce il logging in console.
    // Estende BaseLogProvider per utilizzare un formatter comune e implementa i metodi sincrono e asincrono per la scrittura dei log.
    public class ConsoleLogProvider : BaseLogProvider
    {
        // Costruttore che inizializza il provider con il formatter specificato.
        public ConsoleLogProvider(ILogFormatter formatter) : base(formatter)
        {
        }

        // Metodo sincrono che scrive una voce di log sulla console.
        // Utilizza il formatter ereditato per formattare l'entry prima di stamparla.
        public override void Write(LogEntry entry)
        {
            Console.WriteLine(FormatLogEntry(entry)); // Scrive il log formattato sulla console
        }

        // Metodo asincrono per scrivere una voce di log sulla console.
        // Esegue il metodo Write in un Task separato in modo asincrono.
        // Se viene passato un callback, lo invoca al termine dell'operazione.
        public override Task WriteAsync(LogEntry entry, Action callback = null)
        {
            return Task.Run(() =>
            {
                Write(entry);          // Chiama il metodo sincrono per scrivere il log
                callback?.Invoke();    // Invoca il callback se presente
            });
        }
    }
}