using Logging.Core.Enums;
using Logging.Core.Interfaces;
using Logging.Core.Models;
using Logging.Services;
using Moq;

namespace Logging.Test
{
    /// <summary>
    /// Classe di test per la classe <see cref="Logger"/>.
    /// Utilizza Moq per simulare i provider di log e verificare il corretto comportamento 
    /// della registrazione dei log sia in modalità sincrona che asincrona.
    /// </summary>
    [TestClass]
    public class LoggerTest
    {
        // Mock per simulare il primo provider di log.
        private Mock<ILogProvider>? _mockProvider1;
        // Mock per simulare il secondo provider di log.
        private Mock<ILogProvider>? _mockProvider2;
        // Istanza della classe Logger da testare.
        private Logger? _logger;

        /// <summary>
        /// Metodo di setup eseguito prima di ogni test.
        /// Inizializza i mock dei provider e crea l'istanza di Logger utilizzando la lista di provider.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _mockProvider1 = new Mock<ILogProvider>();
            _mockProvider2 = new Mock<ILogProvider>();
            var providers = new List<ILogProvider> { _mockProvider1.Object, _mockProvider2.Object };
            _logger = new Logger(providers);
        }

        /// <summary>
        /// Verifica che il metodo sincrono <see cref="Logger.Log(LogEntry)"/> invochi il metodo Write()
        /// su tutti i provider configurati.
        /// </summary>
        [TestMethod]
        public void Log_ShouldCallWriteOnAllProviders()
        {
            // Arrange: crea una entry di log di livello Debug.
            var logEntry = new LogEntry(LogLevel.Debug, "Test log");

            // Act: esegue il logging con l'entry creata.
            _logger!.Log(logEntry);

            // Assert: verifica che il metodo Write sia stato chiamato una volta su ciascun provider.
            _mockProvider1!.Verify(p => p.Write(logEntry), Times.Once);
            _mockProvider2!.Verify(p => p.Write(logEntry), Times.Once);
        }

        /// <summary>
        /// Verifica che, in caso di eccezione sollevata da un provider durante il logging sincrono,
        /// il metodo Log continui ad eseguire la chiamata degli altri provider.
        /// </summary>
        [TestMethod]
        public void Log_ShouldHandleExceptionsFromProviders()
        {
            // Arrange: crea una entry di log e configura il primo mock per lanciare un'eccezione.
            var logEntry = new LogEntry(LogLevel.Debug, "Test log");
            _mockProvider1!.Setup(p => p.Write(It.IsAny<LogEntry>())).Throws(new Exception("Provider error"));

            // Act: esegue il logging, l'eccezione dovrà essere gestita internamente.
            _logger!.Log(logEntry);

            // Assert: verifica che, nonostante l'eccezione del primo provider, entrambi i provider abbiano ricevuto la chiamata.
            _mockProvider1!.Verify(p => p.Write(logEntry), Times.Once);
            _mockProvider2!.Verify(p => p.Write(logEntry), Times.Once);
        }

        /// <summary>
        /// Verifica che il metodo asincrono <see cref="Logger.LogAsync(LogEntry, Action)"/> invochi il metodo WriteAsync()
        /// su tutti i provider configurati.
        /// </summary>
        [TestMethod]
        public async Task LogAsync_ShouldCallWriteAsyncOnAllProviders()
        {
            // Arrange: crea una entry di log e configura i mock per il metodo asincrono.
            var logEntry = new LogEntry(LogLevel.Debug, "Test log");
            _mockProvider1!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
                .Returns(Task.CompletedTask);
            _mockProvider2!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
                .Returns(Task.CompletedTask);

            // Act: esegue il logging asincrono.
            await _logger!.LogAsync(logEntry);

            // Assert: verifica che WriteAsync sia stato chiamato esattamente una volta per ciascun provider.
            _mockProvider1.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
            _mockProvider2.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
        }

        /// <summary>
        /// Verifica che, in caso di eccezione sollevata da un provider nel logging asincrono, 
        /// il metodo LogAsync continui ad eseguire la chiamata degli altri provider.
        /// </summary>
        [TestMethod]
        public async Task LogAsync_ShouldHandleExceptionsFromProviders()
        {
            // Arrange: crea una entry di log e configura il primo mock per lanciare un'eccezione asincrona.
            var logEntry = new LogEntry(LogLevel.Debug, "Test log");
            _mockProvider1!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
                .ThrowsAsync(new Exception("Provider error"));
            _mockProvider2!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
                .Returns(Task.CompletedTask);

            // Act: esegue il logging asincrono.
            await _logger!.LogAsync(logEntry);

            // Assert: verifica che entrambi i provider abbiano ricevuto la chiamata nonostante l'eccezione.
            _mockProvider1.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
            _mockProvider2.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
        }

        /// <summary>
        /// Verifica che, al termine dell'operazione asincrona, venga invocato il callback passato al metodo LogAsync.
        /// </summary>
        [TestMethod]
        public async Task LogAsync_ShouldInvokeCallbackAfterCompletion()
        {
            // Arrange: crea una entry di log e definisce un callback che imposta una variabile di controllo.
            var logEntry = new LogEntry(LogLevel.Debug, "Test log");
            var callbackInvoked = false;
            Action callback = () => callbackInvoked = true;

            _mockProvider1!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
                .Returns(Task.CompletedTask);
            _mockProvider2!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
                .Returns(Task.CompletedTask);

            // Act: esegue il logging asincrono, passando il callback.
            await _logger!.LogAsync(logEntry, callback);

            // Assert: controlla che il callback sia stato invocato.
            Assert.IsTrue(callbackInvoked);
        }
    }
}