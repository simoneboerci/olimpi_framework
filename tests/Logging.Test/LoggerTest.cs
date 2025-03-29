using Logging.Core.Enums;
using Logging.Core.Errors;
using Logging.Core.Interfaces;
using Logging.Core.Models;
using Logging.Services;
using Moq;

namespace Logging.Test
{
    [TestClass]
    public class LoggerTest
    {
        private Mock<ILogQueue>? _mockLogQueue;
        private Mock<ILogProvider>? _mockProvider1;
        private Mock<ILogProvider>? _mockProvider2;
        private Logger? _logger;

        [TestInitialize]
        public void Setup()
        {
            _mockLogQueue = new Mock<ILogQueue>();
            _mockProvider1 = new Mock<ILogProvider>();
            _mockProvider2 = new Mock<ILogProvider>();

            // Impostiamo GetLogs() per restituire per default una lista vuota.
            _mockLogQueue.Setup(q => q.GetLogs(It.IsAny<int?>())).Returns([]);
            _mockLogQueue.Setup(q => q.GetLogs(It.IsAny<int?>())).Returns([]);

            // Configuriamo i mock dei provider per il log sincrono.
            _mockProvider1.Setup(p => p.DisplayLogEntry(It.IsAny<LogEntry>()));
            _mockProvider2.Setup(p => p.DisplayLogEntry(It.IsAny<LogEntry>()));

            var providers = new List<ILogProvider> { _mockProvider1.Object, _mockProvider2.Object };

            // Crea l'istanza di Logger con la log queue mockata e la lista di provider.
            _logger = new Logger(_mockLogQueue.Object, providers);
        }

        /// <summary>
        /// Verifica che il metodo Log invii la log entry alla log queue.
        /// </summary>
        [TestMethod]
        public void Log_ShouldEnqueueLogEntry()
        {
            // Arrange
            var logEntry = new LogEntry(LogLevel.Debug, "Test log");

            // Act
            _logger!.Log(logEntry);

            // Assert: verifica che la log entry sia stata accodata.
            _mockLogQueue!.Verify(q => q.Enqueue(logEntry), Times.Once);
        }

        /// <summary>
        /// Verifica che lo swap della log queue venga gestito correttamente:
        /// dopo lo swap, le entry vengono inviate alla nuova log queue.
        /// </summary>
        [TestMethod]
        public void SwapLogQueue_ShouldUseNewQueueForLogging()
        {
            // Arrange: crea un nuovo mock per la log queue.
            var newMockLogQueue = new Mock<ILogQueue>();
            newMockLogQueue.Setup(q => q.GetLogs(It.IsAny<int?>())).Returns([]);
            newMockLogQueue.Setup(q => q.GetLogs(It.IsAny<int?>())).Returns([]);
            _logger!.SwapLogQueue(newMockLogQueue.Object);

            var logEntry = new LogEntry(LogLevel.Info, "Log after swap");

            // Act
            _logger.Log(logEntry);

            // Assert: verifica che la nuova log queue sia stata utilizzata.
            newMockLogQueue.Verify(q => q.Enqueue(logEntry), Times.Once);
            _mockLogQueue!.Verify(q => q.Enqueue(It.IsAny<LogEntry>()), Times.Never);
        }

        /// <summary>
        /// Verifica che l'attach di un provider:
        /// - Carichi le entry precedenti tramite GetLogs
        /// - Sottoscriva l'evento LogEntryAdded, in modo che il nuovo provider riceva futuri log.
        /// </summary>
        [TestMethod]
        public void AttachLogProvider_ShouldLoadPreviousEntriesAndSubscribeToEvent()
        {
            // Arrange: simula log già presenti nella log queue.
            var existingEntries = new List<LogEntry>
            {
                new(LogLevel.Info, "Existing log")
            };
            _mockLogQueue!.Setup(q => q.GetLogs(It.IsAny<int?>())).Returns(existingEntries);
            _mockLogQueue.Setup(q => q.GetLogs(It.IsAny<int?>())).Returns(existingEntries);

            // Crea un nuovo provider mock (che non sia già presente nella lista iniziale).
            var newProvider = new Mock<ILogProvider>();
            newProvider.Setup(p => p.DisplayLogEntry(It.IsAny<LogEntry>()));

            // Act: Attacca il nuovo provider.
            _logger!.AttachLogProvider(newProvider.Object, loadPreviousLogEntries: true);

            // Assert: per ogni log già presente deve essere chiamato DisplayLogEntry.
            foreach(var entry in existingEntries)
            {
                newProvider.Verify(p => p.DisplayLogEntry(entry), Times.Once);
            }

            // Simula un nuovo log che la log queue notifica tramite l'evento.
            var newLogEntry = new LogEntry(LogLevel.Warning, "New log event");
            _mockLogQueue.Raise(q => q.LogEntryAdded += null, newLogEntry);

            // Il nuovo provider deve ricevere anche il nuovo log.
            newProvider.Verify(p => p.DisplayLogEntry(newLogEntry), Times.Once);
        }

        /// <summary>
        /// Verifica che il detach di un provider lo rimuova dalla lista e lo desottoscriva dall'evento.
        /// Utilizziamo un provider creato ex novo per evitare conflitti con quelli già presenti nel costruttore.
        /// </summary>
        [TestMethod]
        public void DetachLogProvider_ShouldUnsubscribeAndRemoveProvider()
        {
            // Arrange: crea un nuovo provider e attaccalo.
            var providerToDetach = new Mock<ILogProvider>();
            providerToDetach.Setup(p => p.DisplayLogEntry(It.IsAny<LogEntry>()));
            _logger!.AttachLogProvider(providerToDetach.Object);
            
            // Act: esegui il detach.
            _logger.DetachLogProvider(providerToDetach.Object);

            // Simula un nuovo log che la log queue notifica tramite l'evento.
            var logEntry = new LogEntry(LogLevel.Error, "Log after detach");
            _mockLogQueue!.Raise(q => q.LogEntryAdded += null, logEntry);

            // Assert: il provider rimosso non deve ricevere la notifica.
            providerToDetach.Verify(p => p.DisplayLogEntry(logEntry), Times.Never);
        }

        /// <summary>
        /// Verifica che tentare di fare il detach di un provider non presente sollevi l'eccezione corretta.
        /// </summary>
        [TestMethod]
        public void DetachLogProvider_ShouldThrowException_WhenProviderNotFound()
        {
            // Arrange: crea un provider non attachato.
            var nonAttachedProvider = new Mock<ILogProvider>().Object;

            Assert.ThrowsException<LogProviderNotFoundException>(() =>
            {
                _logger!.DetachLogProvider(nonAttachedProvider);
            });
        }
    }
}