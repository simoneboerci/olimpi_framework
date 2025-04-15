using Moq;
using cAlgo.API.Internals;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class TradingSessionAdapterTests
    {
        private Mock<TradingSession>? _mockTradingSession;
        private TradingSessionAdapter? _tradingSessionAdapter;

        [TestInitialize]
        public void Setup()
        {
            _mockTradingSession = new Mock<TradingSession>();
            _tradingSessionAdapter = new TradingSessionAdapter(_mockTradingSession.Object);
        }

        [TestMethod]
        public void StartDay_ShouldReturnCorrectStartDay()
        {
            // Arrange
            _mockTradingSession!.Setup(ts => ts.StartDay).Returns(DayOfWeek.Monday);

            // Act
            var result = _tradingSessionAdapter!.StartDay;

            // Assert
            Assert.AreEqual(DayOfWeek.Monday, result);
        }

        [TestMethod]
        public void EndDay_ShouldReturnCorrectEndDay()
        {
            // Arrange
            _mockTradingSession!.Setup(ts => ts.EndDay).Returns(DayOfWeek.Friday);

            // Act
            var result = _tradingSessionAdapter!.EndDay;

            // Assert
            Assert.AreEqual(DayOfWeek.Friday, result);
        }

        [TestMethod]
        public void StartTime_ShouldReturnCorrectStartTime()
        {
            // Arrange
            var startTime = new TimeSpan(9, 0, 0);
            _mockTradingSession!.Setup(ts => ts.StartTime).Returns(startTime);

            // Act
            var result = _tradingSessionAdapter!.StartTime;

            // Assert
            Assert.AreEqual(startTime, result);
        }

        [TestMethod]
        public void EndTime_ShouldReturnCorrectEndTime()
        {
            // Arrange
            var endTime = new TimeSpan(17, 0, 0);
            _mockTradingSession!.Setup(ts => ts.EndTime).Returns(endTime);

            // Act
            var result = _tradingSessionAdapter!.EndTime;

            // Assert
            Assert.AreEqual(endTime, result);
        }

        [TestMethod]
        public void GetCAlgoTradingSession_ShouldReturnOriginalTradingSession()
        {
            // Act
            var result = _tradingSessionAdapter!.GetCAlgoTradingSession();

            // Assert
            Assert.AreEqual(_mockTradingSession!.Object, result);
        }

        [TestMethod]
        public void ToCAlgoTradingSession_ShouldReturnCorrectTradingSession()
        {
            // Arrange
            var mockAdapter = new Mock<ITradingSessionAdapter>();
            mockAdapter.Setup(a => a.GetCAlgoTradingSession()).Returns(_mockTradingSession!.Object);

            // Act
            var result = _tradingSessionAdapter!.ToCAlgoTradingSession(mockAdapter.Object);

            // Assert
            Assert.AreEqual(_mockTradingSession.Object, result);
            mockAdapter.Verify(a => a.GetCAlgoTradingSession(), Times.Once);
        }

        [TestMethod]
        public void ToTradingSession_ShouldReturnNewTradingSessionAdapter()
        {
            // Arrange
            var newTradingSession = new Mock<TradingSession>();

            // Act
            var result = _tradingSessionAdapter!.ToTradingSession(newTradingSession.Object);

            // Assert
            Assert.IsInstanceOfType<TradingSessionAdapter>(result);
            Assert.AreEqual(newTradingSession.Object, ((TradingSessionAdapter)result).GetCAlgoTradingSession());
        }
    }
}