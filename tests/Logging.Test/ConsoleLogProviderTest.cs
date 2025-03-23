using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Logging.Core.Factories;
using Logging.Core.Interfaces;
using Logging.Data.Formatters;
using Logging.Data.Providers;

namespace Logging.Test
{
    [TestClass]
    public class ConsoleLogProviderTest
    {
        [TestMethod]
        [Timeout(5000)]
        public void TerminalLogProvider_ShouldOpenTerminal()
        {
            // Arrange: utilizziamo la factory per creare l'ISystemConsole corretto
            // oppure eventualmente simuliamo la DI in test
            // Qui verifichiamo che, passata una istanza reale, la console venga avviata.
            var systemConsoleFactory = new SystemConsoleFactory();
            ISystemConsole systemConsole = systemConsoleFactory.Create();
            var provider = new ConsoleLogProvider(new PlainTextLogFormatter(), systemConsole);

            // Utilizza reflection per accedere al campo privato _systemConsole nel provider
            var systemConsoleField = typeof(ConsoleLogProvider).GetField("_systemConsole", BindingFlags.NonPublic | BindingFlags.Instance);
            var injectedConsole = systemConsoleField?.GetValue(provider) as ISystemConsole;
            Assert.IsNotNull(injectedConsole, "La console iniettata non è valida.");

            // Ora, se possibile, riflettiamo sul campo privato _process all'interno della console concreta.
            var processField = injectedConsole.GetType().GetField("_process", BindingFlags.NonPublic | BindingFlags.Instance);
            var terminalProcess = processField?.GetValue(injectedConsole) as Process;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Su Windows ci aspettiamo che il processo non sia null e che esegua cmd.exe
                Assert.IsNotNull(terminalProcess, "Il terminale non è stato avviato su Windows.");
                Assert.AreEqual("cmd.exe", terminalProcess.StartInfo.FileName, "Il terminale avviato non è cmd.exe.");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // Su macOS, l'esecuzione di "open" potrebbe non restituire un handle validabile.
                if (terminalProcess == null)
                {
                    Assert.Inconclusive("Il test su macOS non è verificabile tramite process handle (Process.Start con 'open' potrebbe restituire null).");
                }
                else
                {
                    Assert.AreEqual("open", terminalProcess.StartInfo.FileName, "Il terminale avviato non è 'open'.");
                }
            }
            else
            {
                Assert.Fail("Sistema operativo non supportato per questo test.");
            }
        }
    }
}