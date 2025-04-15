using System.Reflection;
using cAlgo.API;
using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class CandlestickAdapterTests
    {
        private Bar _bar;
        private CandlestickAdapter? _candlestickAdapter;

        [TestInitialize]
        public void Setup()
        {
            // Utilizzo del costruttore interno di Bar
            _bar = BarHelper.CreateBar(
                openTime: DateTime.Now,
                open: 1.2345,
                high: 1.5678,
                low: 1.1234,
                close: 1.3456,
                tickVolume: 1000
            );

            _candlestickAdapter = new CandlestickAdapter(_bar);
        }

        [TestMethod]
        public void GetCAlgoBar_ShouldReturnOriginalBar()
        {
            // Act
            var result = _candlestickAdapter!.GetCAlgoBar();

            // Assert
            Assert.AreEqual(_bar, result);
        }

        [TestMethod]
        public void OpenTime_ShouldReturnCorrectOpenTime()
        {
            // Act
            var result = _candlestickAdapter!.OpenTime;

            // Assert
            Assert.AreEqual(_bar.OpenTime, result);
        }

        [TestMethod]
        public void Open_ShouldReturnCorrectOpenValue()
        {
            // Act
            var result = _candlestickAdapter!.Open;

            // Assert
            Assert.AreEqual(_bar.Open, result);
        }

        [TestMethod]
        public void High_ShouldReturnCorrectHighValue()
        {
            // Act
            var result = _candlestickAdapter!.High;

            // Assert
            Assert.AreEqual(_bar.High, result);
        }

        [TestMethod]
        public void Low_ShouldReturnCorrectLowValue()
        {
            // Act
            var result = _candlestickAdapter!.Low;

            // Assert
            Assert.AreEqual(_bar.Low, result);
        }

        [TestMethod]
        public void Close_ShouldReturnCorrectCloseValue()
        {
            // Act
            var result = _candlestickAdapter!.Close;

            // Assert
            Assert.AreEqual(_bar.Close, result);
        }

        [TestMethod]
        public void TickVolume_ShouldReturnCorrectTickVolume()
        {
            // Act
            var result = _candlestickAdapter!.TickVolume;

            // Assert
            Assert.AreEqual(_bar.TickVolume, result);
        }

        [TestMethod]
        public void Equals_ShouldReturnTrueForSameInstance()
        {
            // Act
            var result = _candlestickAdapter!.Equals(_candlestickAdapter);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_ShouldReturnFalseForDifferentInstance()
        {
            // Arrange
            var anotherBar = BarHelper.CreateBar(
                openTime: DateTime.Now.AddMinutes(-1),
                open: 1.1111,
                high: 1.2222,
                low: 1.0000,
                close: 1.3333,
                tickVolume: 500
            );
            var anotherAdapter = new CandlestickAdapter(anotherBar);

            // Act
            var result = _candlestickAdapter!.Equals(anotherAdapter);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToCandlestick_ShouldReturnNewCandlestickAdapter()
        {
            // Arrange
            var newBar = BarHelper.CreateBar(
                openTime: DateTime.Now.AddMinutes(-1),
                open: 1.1111,
                high: 1.2222,
                low: 1.0000,
                close: 1.3333,
                tickVolume: 500
            );

            // Act
            var result = _candlestickAdapter!.ToCandlestick(newBar);

            // Assert
            Assert.IsInstanceOfType<CandlestickAdapter>(result);
            Assert.AreEqual(newBar, ((CandlestickAdapter)result).GetCAlgoBar());
        }

        [TestMethod]
        public void ToCAlgoBar_ShouldReturnOriginalBar()
        {
            // Arrange
            var mockCandlestickAdapter = new CandlestickAdapter(_bar);

            // Act
            var result = _candlestickAdapter!.ToCAlgoBar(mockCandlestickAdapter);

            // Assert
            Assert.AreEqual(_bar, result);
        }
    }

    public static class BarHelper
    {
        public static Bar CreateBar(DateTime openTime, double open, double high, double low, double close, long tickVolume)
        {
            // Usa riflessione per accedere al costruttore interno
            var constructor = typeof(Bar).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                [typeof(DateTime), typeof(double), typeof(double), typeof(double), typeof(double), typeof(long)],
                null
            ) ?? throw new InvalidOperationException("Il costruttore di Bar non è accessibile.");
            return (Bar)constructor.Invoke([openTime, open, high, low, close, tickVolume]);
        }
    }
}