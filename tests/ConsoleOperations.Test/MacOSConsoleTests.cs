using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleOperations.Data;

namespace ConsoleOperations.Tests
{
    [TestClass]
    public class MacOSConsoleTests
    {
        private MacOSConsole? _console;

        [TestInitialize]
        public void Setup()
        {
            if (!System.Runtime.InteropServices.RuntimeInformation
                  .IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
            {
                Assert.Inconclusive("Test eseguiti solo su MacOS.");
            }
            _console = new MacOSConsole();
        }

        [TestMethod]
        public void TestStartProcess()
        {
            _console!.Start();
            Process process = GetProcessFromConsole(_console);
            Assert.IsFalse(process.HasExited, "Il processo dovrebbe essere in esecuzione dopo Start.");
            // Pulizia: Termina il processo. Il file associato verrà eliminato in automatico all'uscita.
            _console.Dispose();
        }

        [TestMethod]
        public void TestWriteLine()
        {
            _console!.Start();
            _console.WriteLine("Test message");
            Process process = GetProcessFromConsole(_console);
            Assert.IsFalse(process.HasExited, "Il processo dovrebbe essere in esecuzione dopo WriteLine.");
            _console.Dispose();
        }

        // Metodo helper per ottenere il campo "Process" dalla classe base via Reflection.
        private static Process GetProcessFromConsole(MacOSConsole console)
        {
            Type? baseType = typeof(MacOSConsole).BaseType ?? throw new InvalidOperationException("BaseType is null. Unable to retrieve the field.");
            FieldInfo? processField = baseType.GetField("Process", BindingFlags.Instance | BindingFlags.NonPublic) ?? throw new InvalidOperationException("Field 'Process' not found in the base type.");
            object? processValue = processField.GetValue(console);
            if (processValue is not Process process)
            {
                throw new InvalidOperationException("Field 'Process' is null or not of type Process.");
            }
            
            return process;
        }
    }
}