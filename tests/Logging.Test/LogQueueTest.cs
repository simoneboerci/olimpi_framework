using Logging.Core.Enums;
using Logging.Core.Models;

namespace Logging.Test
{
    [TestClass]
    public class LogQueueTest
    {
        private LogQueue? _logQueue;

        [TestInitialize]
        public void Setup()
        {
            _logQueue = new LogQueue();
        }

        /// <summary>
        /// Verifica che, chiamando Enqueue, l'evento LogEntryAdded venga sollevato con la log entry corretta.
        /// </summary>
        [TestMethod]
        public void Enqueue_ShouldFireLogEntryAdded()
        {
            // Arrange
            var logEntry = new LogEntry(LogLevel.Info, "Test log");
            LogEntry? eventFiredEntry = null;
            _logQueue!.LogEntryAdded += entry => eventFiredEntry = entry;

            // Act
            _logQueue.Enqueue(logEntry);

            // Assert
            Assert.IsNotNull(eventFiredEntry, "L'evento LogEntryAdded non è stato sollevato.");
            Assert.AreEqual(logEntry, eventFiredEntry, "La log entry sollevata non corrisponde a quella accodata.");
        }

        /// <summary>
        /// Verifica che le log entry vengano accodate e restituite in ordine crescente di Timestamp.
        /// </summary>
        [TestMethod]
        public void Enqueue_And_GetLogs_ShouldReturnLogsInOrder()
        {
            // Arrange: creiamo tre log entry con timestamp differenti.
            var log1 = new LogEntry(LogLevel.Error, "Log 1", new DateTime(2025, 1, 1, 10, 0, 0).ToString());
            var log2 = new LogEntry(LogLevel.Error, "Log 2", new DateTime(2025, 1, 1, 11, 0, 0).ToString());
            var log3 = new LogEntry(LogLevel.Error, "Log 3", new DateTime(2025, 1, 1, 12, 0, 0).ToString());

            // Act
            _logQueue!.Enqueue(log2);
            _logQueue.Enqueue(log1);
            _logQueue.Enqueue(log3);
            List<LogEntry> logs = _logQueue.GetLogs();

            // Assert: i log devono essere ordinati in ordine crescente di Timestamp.
            Assert.AreEqual(3, logs.Count);
            Assert.AreEqual(log1, logs[0]);
            Assert.AreEqual(log2, logs[1]);
            Assert.AreEqual(log3, logs[2]);
        }

        /// <summary>
        /// Verifica che GetLogs restituisca solo gli ultimi N log in base al parametro maxLogs.
        /// </summary>
        [TestMethod]
        public void GetLogs_WithMaxLogs_ShouldReturnOnlyLastNEntries()
        {
            // Arrange: creiamo cinque log entry.
            for (int i = 1; i <= 5; i++)
            {
                _logQueue!.Enqueue(new LogEntry(LogLevel.Info, $"Log {i}", DateTime.Now.AddMinutes(i).ToString()));
                Thread.Sleep(10); // piccolo ritardo per assicurare timestamp differenti
            }

            // Act: richiede gli ultimi 3 log.
            List<LogEntry> logs = _logQueue!.GetLogs(maxLogs: 3);

            // Assert
            Assert.AreEqual(3, logs.Count, "Non sono stati restituiti gli ultimi tre log.");
            // Si attende che i tre log estratti siano i più recenti (cioè Log 3, Log 4 e Log 5)
            StringAssert.Contains(logs[0].Message, "Log 3");
            StringAssert.Contains(logs[1].Message, "Log 4");
            StringAssert.Contains(logs[2].Message, "Log 5");
        }
    }
}