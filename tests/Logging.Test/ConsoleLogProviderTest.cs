using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using ConsoleOperations.Core;
using ConsoleOperations.Core.Interfaces;
using Logging.Data.Formatters;
using Logging.Data.Providers;

namespace Logging.Test
{
    /// <summary>
    /// Classe di test per il <see cref="ConsoleLogProvider"/>.
    /// Verifica il corretto avvio del terminale (console) in base al sistema operativo in uso.
    /// Utilizza reflection per ispezionare i campi privati e controllare l'istanza del processo avviato.
    /// </summary>
    [TestClass]
    public class ConsoleLogProviderTest
    {
        /// <summary>
        /// Test che controlla se il provider per il log in console apre correttamente il terminale.
        /// Utilizza la factory per creare l'istanza di <see cref="ISystemConsole"/> adeguata al sistema operativo,
        /// poi verifica, tramite reflection, che il processo lanciato sia quello atteso.
        /// </summary>
        [TestMethod]
        [Timeout(5000)]
        public void TerminalLogProvider_ShouldOpenTerminal()
        {
            // Arrange:
            // Crea l'istanza di ISystemConsole usando la factory (rispettando il sistema operativo corrente).
            var systemConsoleFactory = new SystemConsoleFactory();
            ISystemConsole systemConsole = systemConsoleFactory.CreateSystemConsoleBasedOnPlatoform();

            // Istanzia il ConsoleLogProvider, iniettando il PlainTextLogFormatter e l'istanza di ISystemConsole.
            var provider = new ConsoleLogProvider(new PlainTextLogFormatter(), systemConsole);

            // Utilizza reflection per recuperare il campo privato _systemConsole nel provider.
            var systemConsoleField = typeof(ConsoleLogProvider)
                .GetField("_systemConsole", BindingFlags.NonPublic | BindingFlags.Instance);
            var injectedConsole = systemConsoleField?.GetValue(provider) as ISystemConsole;

            // Verifica che la console iniettata non sia null.
            Assert.IsNotNull(injectedConsole, "La console iniettata non è valida.");

            // Utilizza reflection per accedere al campo privato _process nella console concreta.
            var processField = injectedConsole.GetType()
                .GetField("_process", BindingFlags.NonPublic | BindingFlags.Instance);
            var terminalProcess = processField?.GetValue(injectedConsole) as Process;

            // Act & Assert:
            // Verifica le condizioni specifiche in base al sistema operativo in uso.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Su Windows deve essere avviato un processo e il nome del file deve essere "cmd.exe".
                Assert.IsNotNull(terminalProcess, "Il terminale non è stato avviato su Windows.");
                Assert.AreEqual("cmd.exe", terminalProcess.StartInfo.FileName, "Il terminale avviato non è cmd.exe.");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Su macOS, l'utilizzo di "open" potrebbe non restituire un handle valido, quindi il test è inconcludente.
                if (terminalProcess == null)
                {
                    Assert.Inconclusive("Il test su macOS non è verificabile tramite process handle (Process.Start con 'open' potrebbe restituire null).");
                }
                else
                {
                    // Se il process handle è valido, controlla che il comando usato sia "open".
                    Assert.AreEqual("open", terminalProcess.StartInfo.FileName, "Il terminale avviato non è 'open'.");
                }
            }
            else
            {
                // Se il sistema operativo non è supportato, il test fallisce.
                Assert.Fail("Sistema operativo non supportato per questo test.");
            }
        }
    }
}