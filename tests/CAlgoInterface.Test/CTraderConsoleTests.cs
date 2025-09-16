using CAlgoInterface.Backend.Services;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class CTraderConsoleTests
    {
        // Creiamo una classe per tracciare i messaggi loggati
        private class LogTracker
        {
            public List<object> LoggedMessages { get; } = [];
        }

        private ICTraderConsole? _cTraderConsole;
        private LogTracker? _logTracker;

        [TestInitialize]
        public void Setup()
        {
            _logTracker = new LogTracker();
            
            // Creiamo direttamente un'implementazione di ICTraderConsole che tracci i messaggi
            _cTraderConsole = new TestCTraderConsole(_logTracker);
        }

        // Implementazione di test che simula CTraderConsole
        private class TestCTraderConsole : ICTraderConsole
        {
            private readonly LogTracker _logTracker;

            public TestCTraderConsole(LogTracker logTracker)
            {
                _logTracker = logTracker;
            }

            public void Log(object value)
            {
                // Aggiunge direttamente il valore alla lista
                _logTracker.LoggedMessages.Add(value);
            }

            public void Log(params object[] parameters)
            {
                // Aggiunge direttamente i parametri alla lista
                _logTracker.LoggedMessages.Add(parameters);
            }

            public void Log(string message, params object[] parameters)
            {
                // Aggiunge un oggetto anonimo con il messaggio e i parametri
                _logTracker.LoggedMessages.Add(new { Message = message, Parameters = parameters });
            }
        }

        [TestMethod]
        public void Log_ShouldTrackSingleObject()
        {
            // Arrange
            var value = (object)"Test message"; // Cast esplicito a object per chiamare il metodo corretto

            // Act
            _cTraderConsole!.Log(value);

            // Assert
            Assert.AreEqual(1, _logTracker!.LoggedMessages.Count, "Il numero di messaggi loggati non è corretto.");
            Assert.AreEqual(value, _logTracker.LoggedMessages[0], "Il messaggio loggato non corrisponde al valore atteso.");
        }

        [TestMethod]
        public void Log_ShouldTrackMultipleObjects()
        {
            // Arrange
            var parameters = new object[] { "Test1", 123, true };

            // Act
            _cTraderConsole!.Log(parameters);  // Remove the explicit cast to object

            // Assert
            Assert.AreEqual(1, _logTracker!.LoggedMessages.Count);
            CollectionAssert.AreEqual(parameters, (object[])_logTracker.LoggedMessages[0]);
        }

        [TestMethod]
        public void Log_ShouldTrackMessageWithParameters()
        {
            // Arrange
            var message = "Test message";
            var parameters = new object[] { "Param1", 456 };

            // Act
            _cTraderConsole!.Log(message, parameters[0], parameters[1]);

            // Assert
            Assert.AreEqual(1, _logTracker!.LoggedMessages.Count);
            var loggedEntry = (dynamic)_logTracker.LoggedMessages[0];
            Assert.AreEqual(message, loggedEntry.Message);
            CollectionAssert.AreEqual(parameters, (object[])loggedEntry.Parameters);
        }
    }
}