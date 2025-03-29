using System.Diagnostics;
using System.Reflection;
using ConsoleOperations.Data;

namespace ConsoleOperations.Tests
{
    [TestClass]
    public class WindowsConsoleTests
    {
        private WindowsConsole _console;

        [TestInitialize]
        public void Setup()
        {
            if (!System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                Assert.Inconclusive("Test eseguiti solo su piattaforma Windows.");
            }
            _console = new WindowsConsole();
        }

        [TestMethod]
        public void TestStartProcess()
        {
            _console.Start();
            Process process = GetProcessFromConsole(_console);
            Assert.IsNotNull(process, "Il processo non è stato avviato.");
            // Pulizia: termina il processo avviato.
            _console.Dispose();
        }

        [TestMethod]
        public void TestWriteLine()
        {
            _console.Start();
            // Scrive una riga
            _console.WriteLine("Test message");
            Process process = GetProcessFromConsole(_console);
            Assert.IsFalse(process.HasExited, "Il processo dovrebbe essere in esecuzione dopo WriteLine.");
            _console.Dispose();
        }

        // Metodo helper per ottenere il campo "Process" dalla classe base via reflection.
        private static Process GetProcessFromConsole(WindowsConsole console)
        {
            FieldInfo processField = typeof(WindowsConsole).BaseType.GetField("Process", BindingFlags.Instance | BindingFlags.NonPublic);
            return processField?.GetValue(console) as Process;
        }
    }
}