using Moq;
using System;
using System.Collections.Generic;
using cAlgo.API.Internals;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Routing;
using cAlgo.API;
using cAlgo.API.Collections;

// Create a stub implementation of IndexedCollection for testing
namespace cAlgo.API.Collections
{
    // Use the existing IReadonlyList from cAlgo.API
    public class IndexedCollection<T> : List<T>, IReadonlyList<T> { }
}

namespace CAlgoInterface.Test
{
    [TestClass]
    public class MarketHoursAdapterTests
    {
        private Mock<MarketHours>? _mockMarketHours;
        private Mock<ITradingSessionAdapter>? _mockTradingSessionAdapter;
        private Mock<ITradingHolidayAdapter>? _mockTradingHolidayAdapter;

        private MarketHoursAdapter? _marketHoursAdapter;

        [TestInitialize]
        public void Setup()
        {
            _mockMarketHours = new Mock<MarketHours>();
            _mockTradingSessionAdapter = new Mock<ITradingSessionAdapter>();
            _mockTradingHolidayAdapter = new Mock<ITradingHolidayAdapter>();

            _marketHoursAdapter = new MarketHoursAdapter(
                _mockMarketHours.Object,
                _mockTradingSessionAdapter.Object,
                _mockTradingHolidayAdapter.Object
            );
        }

        [TestMethod]
        public void CAlgoMarketHours_ShouldReturnOriginalMarketHours()
        {
            // Act
            var result = _marketHoursAdapter!.CAlgoMarketHours();

            // Assert
            Assert.AreEqual(_mockMarketHours!.Object, result);
        }

        [TestMethod]
        public void TradingSessions_ShouldReturnMappedTradingSessions()
        {
            // Arrange
            var mockTradingSession = new Mock<TradingSession>();
            var mockITradingSession = new Mock<ITradingSession>();
            var sessionCollection = new IndexedCollection<TradingSession>
            {
                mockTradingSession.Object
            };
            _ = _mockMarketHours!
                .Setup(m => m.Sessions)
                .Returns(sessionCollection);
            _mockTradingSessionAdapter!
                .Setup(a => a.ToTradingSession(mockTradingSession.Object))
                .Returns(mockITradingSession.Object);

            // Act
            var sessions = _marketHoursAdapter!.TradingSessions;

            // Assert
            Assert.AreEqual(1, sessions.Count);
            Assert.AreEqual(mockITradingSession.Object, sessions[0]);
            _mockTradingSessionAdapter.Verify(a => a.ToTradingSession(mockTradingSession.Object), Times.Once);
        }

        [TestMethod]
        public void TradingHolidays_ShouldReturnMappedTradingHolidays()
        {
            // Arrange
            var mockTradingHoliday = new Mock<TradingHoliday>();
            var mockITradingHoliday = new Mock<ITradingHoliday>();
            var holidayCollection = new IndexedCollection<TradingHoliday>
            {
                mockTradingHoliday.Object
            };
            _ = _mockMarketHours!
                .Setup(m => m.Holidays)
                .Returns(holidayCollection);
            _mockTradingHolidayAdapter!
                .Setup(a => a.ToTradingHoliday(mockTradingHoliday.Object))
                .Returns(mockITradingHoliday.Object);

            // Act
            var holidays = _marketHoursAdapter!.TradingHolidays;

            // Assert
            Assert.AreEqual(1, holidays.Count);
            Assert.AreEqual(mockITradingHoliday.Object, holidays[0]);
            _mockTradingHolidayAdapter.Verify(a => a.ToTradingHoliday(mockTradingHoliday.Object), Times.Once);
        }

        [TestMethod]
        public void IsOpened_ShouldReturnCorrectValue()
        {
            // Arrange
            _mockMarketHours!.Setup(m => m.IsOpened()).Returns(true);

            // Act
            var result = _marketHoursAdapter!.IsOpened();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOpened_WithDateTime_ShouldReturnCorrectValue()
        {
            // Arrange
            var dateTime = DateTime.Now;
            _mockMarketHours!.Setup(m => m.IsOpened(dateTime)).Returns(true);

            // Act
            var result = _marketHoursAdapter!.IsOpened(dateTime);

            // Assert
            Assert.IsTrue(result);
            _mockMarketHours.Verify(m => m.IsOpened(dateTime), Times.Once);
        }

        [TestMethod]
        public void TimeTillClose_ShouldReturnCorrectValue()
        {
            // Arrange
            var timeSpan = TimeSpan.FromHours(1);
            _mockMarketHours!.Setup(m => m.TimeTillClose()).Returns(timeSpan);

            // Act
            var result = _marketHoursAdapter!.TimeTillClose();

            // Assert
            Assert.AreEqual(timeSpan, result);
        }

        [TestMethod]
        public void TimeTillOpen_ShouldReturnCorrectValue()
        {
            // Arrange
            var timeSpan = TimeSpan.FromHours(2);
            _mockMarketHours!.Setup(m => m.TimeTillOpen()).Returns(timeSpan);

            // Act
            var result = _marketHoursAdapter!.TimeTillOpen();

            // Assert
            Assert.AreEqual(timeSpan, result);
        }

        [TestMethod]
        public void ToCAlgoMarketHours_ShouldReturnOriginalMarketHours()
        {
            // Act
            var result = _marketHoursAdapter!.ToCAlgoMarketHours(_marketHoursAdapter);

            // Assert
            Assert.AreEqual(_mockMarketHours!.Object, result);
        }

        [TestMethod]
        public void ToMarketHours_ShouldReturnNewMarketHoursAdapter()
        {
            // Arrange
            var newMarketHours = new Mock<MarketHours>();

            // Act
            var result = _marketHoursAdapter!.ToMarketHours(newMarketHours.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(MarketHoursAdapter));
        }
    }
}