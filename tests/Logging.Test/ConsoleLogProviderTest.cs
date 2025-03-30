using Logging.Core.Enums;
using Logging.Core.Models;
using Logging.Core.Interfaces;
using Logging.Data.Providers;
using Moq;
using ConsoleOperations.Core.Interfaces;

namespace Logging.Test
{
    [TestClass]
    public class ConsoleLogProviderTest
    {
        private Mock<ISystemConsole>? _mockSystemConsole;
        private Mock<ILogFormatter>? _mockFormatter;
        private ConsoleLogProvider? _consoleLogProvider;
    
        [TestInitialize]
        public void Setup()
        {
            // Simuliamo la ISystemConsole per verificare che Start venga chiamato.
            _mockSystemConsole = new Mock<ISystemConsole>();
            _mockFormatter = new Mock<ILogFormatter>();
    
            // Configuriamo il formatter per restituire una stringa formattata in base al messaggio della log entry.
            _mockFormatter.Setup(f => f.Format(It.IsAny<LogEntry>()))
                          .Returns<LogEntry>(entry => $"Formatted: {entry.Message}");
    
            // Creiamo l'istanza del provider.
            _consoleLogProvider = new ConsoleLogProvider(_mockSystemConsole.Object, _mockFormatter.Object);
        }
    
        /// <summary>
        /// Verifica che, al costruttore, venga chiamato Start sulla system console.
        /// </summary>
        [TestMethod]
        public void Constructor_ShouldStartSystemConsole()
        {
            // Verifica che il metodo Start sia stato chiamato esattamente una volta.
            _mockSystemConsole!.Verify(console => console.Start(), Times.Once);
        }
    
        /// <summary>
        /// Verifica che, chiamando DisplayLogEntry, il log venga formattato e inviato alla system console.
        /// </summary>
        [TestMethod]
        public void DisplayLogEntry_ShouldCallSystemConsoleWriteLineWithFormattedText()
        {
            // Arrange: creiamo una LogEntry fittizia.
            var logEntry = new LogEntry(LogLevel.Info, "Test message", DateTime.Now.ToString("o"));
    
            // Act: invoca DisplayLogEntry (definito da BaseLogProvider e utilizzato da questo provider).
            _consoleLogProvider!.DisplayLogEntry(logEntry);
    
            // Il formatter restituisce il testo atteso.
            string expectedFormattedText = $"Formatted: {logEntry.Message}";
    
            // Assert: verifica che la system console abbia ricevuto la chiamata a WriteLine con il testo formattato.
            _mockSystemConsole!.Verify(console => console.WriteLine(expectedFormattedText), Times.Once);
        }
    
        /// <summary>
        /// Verifica che la chiamata a Dispose chiami il Dispose sulla system console.
        /// </summary>
        [TestMethod]
        public void Dispose_ShouldCallSystemConsoleDispose()
        {
            // Act
            _consoleLogProvider!.Dispose();
    
            // Assert: verifica che venga invocato il metodo Dispose sulla system console.
            _mockSystemConsole!.Verify(console => console.Dispose(), Times.Once);
        }
    }
}