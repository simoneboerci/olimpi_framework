using Moq;
using cAlgo.API;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Routing;
using CAlgoInterface.Backend.Services;
using cAlgo.API.Internals;

namespace CAlgoInterface.Tests
{
    [TestClass]
    public class PositionAdapterTests
    {
        [TestMethod]
        public void Id_And_OrderId_ShouldReturnGuidFromIntId()
        {
            // Arrange
            var fakePosition = new Mock<Position>();
            fakePosition.Setup(p => p.Id).Returns(123);

            var tradeTypeMapper = new Mock<ITradeTypeMapper>();
            var stopTriggerMethodMapper = new Mock<IStopTriggerMethodMapper>();

            var adapter = new PositionAdapter(fakePosition.Object, tradeTypeMapper.Object, stopTriggerMethodMapper.Object);

            // Act
            var id = adapter.Id;
            var orderId = adapter.OrderId;

            // Assert
            Assert.AreEqual(GuidHelper.IntToGuid(123), id);
            Assert.AreEqual(GuidHelper.IntToGuid(123), orderId);
        }

        [TestMethod]
        public void SymbolId_ShouldReturnGuidFromSymbolId()
        {
            // Arrange
            var fakeSymbol = new Mock<Symbol>();
            fakeSymbol.Setup(s => s.Id).Returns(987L);

            var fakePosition = new Mock<Position>();
            fakePosition.Setup(p => p.Symbol).Returns(fakeSymbol.Object);

            var tradeTypeMapper = new Mock<ITradeTypeMapper>();
            var stopTriggerMethodMapper = new Mock<IStopTriggerMethodMapper>();

            var adapter = new PositionAdapter(fakePosition.Object, tradeTypeMapper.Object, stopTriggerMethodMapper.Object);

            // Act
            var result = adapter.SymbolId;

            // Assert
            Assert.AreEqual(GuidHelper.LongToGuid(987L), result);
        }

        [TestMethod]
        public void TradeType_ShouldUseMapper()
        {
            // Arrange
            var fakePosition = new Mock<Position>();
            fakePosition.Setup(p => p.TradeType).Returns(cAlgo.API.TradeType.Sell);

            var tradeTypeMapper = new Mock<ITradeTypeMapper>();
            tradeTypeMapper
                .Setup(m => m.ToTradeType(cAlgo.API.TradeType.Sell))
                .Returns(OrderCreation.Core.Enums.TradeType.Sell);

            var stopTriggerMethodMapper = new Mock<IStopTriggerMethodMapper>();

            var adapter = new PositionAdapter(fakePosition.Object, tradeTypeMapper.Object, stopTriggerMethodMapper.Object);

            // Act
            var result = adapter.TradeType;

            // Assert
            Assert.AreEqual(OrderCreation.Core.Enums.TradeType.Sell, result);
            tradeTypeMapper.Verify(m => m.ToTradeType(cAlgo.API.TradeType.Sell), Times.Once);
        }

        [TestMethod]
        public void StopTriggerMethod_ShouldUseMapper()
        {
            // Arrange
            var fakePosition = new Mock<Position>();
            fakePosition.Setup(p => p.StopLossTriggerMethod).Returns(cAlgo.API.StopTriggerMethod.DoubleOpposite);

            var tradeTypeMapper = new Mock<ITradeTypeMapper>();
            var stopTriggerMethodMapper = new Mock<IStopTriggerMethodMapper>();
            stopTriggerMethodMapper
                .Setup(m => m.ToCustomStopTriggerMethod(cAlgo.API.StopTriggerMethod.DoubleOpposite))
                .Returns(OrderCreation.Core.Enums.StopTriggerMethod.DoubleOpposite);

            var adapter = new PositionAdapter(fakePosition.Object, tradeTypeMapper.Object, stopTriggerMethodMapper.Object);

            // Act
            var result = adapter.StopTriggerMethod;

            // Assert
            Assert.AreEqual(OrderCreation.Core.Enums.StopTriggerMethod.DoubleOpposite, result);
            stopTriggerMethodMapper.Verify(m => m.ToCustomStopTriggerMethod(cAlgo.API.StopTriggerMethod.DoubleOpposite), Times.Once);
        }

        [TestMethod]
        public void BasicProperties_ShouldReturnValuesFromUnderlying()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var lastUpdate = now.AddMinutes(5);

            var fakePosition = new Mock<Position>();
            fakePosition.Setup(p => p.VolumeInUnits).Returns(1000);
            fakePosition.Setup(p => p.Quantity).Returns(0.1);
            fakePosition.Setup(p => p.EntryPrice).Returns(1.2345);
            fakePosition.Setup(p => p.StopLoss).Returns(1.2000);
            fakePosition.Setup(p => p.TakeProfit).Returns(1.3000);
            fakePosition.Setup(p => p.HasTrailingStop).Returns(true);
            fakePosition.Setup(p => p.EntryTime).Returns(now);
            fakePosition.Setup(p => p.LastUpdateTime).Returns(lastUpdate);

            var tradeTypeMapper = new Mock<ITradeTypeMapper>();
            var stopTriggerMethodMapper = new Mock<IStopTriggerMethodMapper>();

            var adapter = new PositionAdapter(fakePosition.Object, tradeTypeMapper.Object, stopTriggerMethodMapper.Object);

            // Act & Assert
            Assert.AreEqual(1000, adapter.VolumeInUnits);
            Assert.AreEqual(0.1, adapter.QuantityInLots);
            Assert.AreEqual(1.2345, adapter.EntryPrice);
            Assert.AreEqual(1.2000, adapter.StopLoss);
            Assert.AreEqual(1.3000, adapter.TakeProfit);
            Assert.IsTrue(adapter.HasTrailingStop);
            Assert.AreEqual(now, adapter.EntryTime);
            Assert.AreEqual(lastUpdate, adapter.LastUpdateTime);
        }
    }
}
