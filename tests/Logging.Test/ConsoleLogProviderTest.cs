using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Logging.Core.Enums;
using Logging.Data.Formatters;
using Logging.Data.Providers;

namespace Logging.Test;

[TestClass]
    public class ConsoleLogProviderTest
    {
        [TestMethod]
        public void TerminalLogProvider_ShouldOpenTerminal()
        {
            // Arrange
            var provider = new ConsoleLogProvider(new PlainTextLogFormatter());
            
            // Utilizza reflection per accedere al campo privato _terminalProcess
            var processField = typeof(ConsoleLogProvider).GetField("_terminalProcess", BindingFlags.NonPublic | BindingFlags.Instance);
            var terminalProcess = processField?.GetValue(provider) as Process;
            
            // Assert: Verifica che il processo non sia null (cioè che il terminale sia stato aperto)
            Assert.IsNotNull(terminalProcess, "Il terminale non è stato avviato.");
            
            // Verifica che il nome dell'eseguibile corrisponda alle aspettative in base al sistema operativo
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.AreEqual("cmd.exe", terminalProcess.StartInfo.FileName, "Il terminale avviato non è cmd.exe.");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Assert.AreEqual("osascript", terminalProcess.StartInfo.FileName, "Il terminale avviato non è osascript.");
            }
            else
            {
                Assert.Fail("Sistema operativo non supportato per questo test.");
            }
        }
    }