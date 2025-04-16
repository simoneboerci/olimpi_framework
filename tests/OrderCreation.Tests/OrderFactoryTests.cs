using OrderCreation.Application;
using OrderCreation.Core.Enums;

namespace OrderCreation.Tests
{
    [TestClass]
    public class OrderFactoryTests
    {
        private OrderFactory? _orderFactory;

        [TestInitialize]
        public void Setup()
        {
            _orderFactory = new OrderFactory();
        }

        [TestMethod]
        public void CreateMarketOrder_ShouldReturnValidMarketOrder()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            TradeType tradeType = TradeType.Buy;
            string symbolName = "EURUSD";
            double volume = 1000;
            string label = "TestOrder";
            double? stopLossPips = 10;
            double? takeProfitPips = 20;
            string comment = "Test comment";
            bool hasTrailingStop = true;
            StopTriggerMethod stopLossTriggerMethod = StopTriggerMethod.Trade;

            // Act
            var marketOrder = _orderFactory!.CreateMarketOrder(
                id, tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod);

            // Assert
            Assert.IsNotNull(marketOrder);
            Assert.AreEqual(id, marketOrder.Id);
            Assert.AreEqual(tradeType, marketOrder.TradeType);
            Assert.AreEqual(symbolName, marketOrder.SymbolName);
            Assert.AreEqual(volume, marketOrder.Volume);
            Assert.AreEqual(label, marketOrder.Label);
            Assert.AreEqual(stopLossPips, marketOrder.StopLossPips);
            Assert.AreEqual(takeProfitPips, marketOrder.TakeProfitPips);
            Assert.AreEqual(comment, marketOrder.Comment);
            Assert.AreEqual(hasTrailingStop, marketOrder.HasTrailingStop);
            Assert.AreEqual(stopLossTriggerMethod, marketOrder.StopLossTriggerMethod);
        }

        [TestMethod]
        public void CreateMarketRangeOrder_ShouldReturnValidMarketRangeOrder()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            TradeType tradeType = TradeType.Buy;
            string symbolName = "NZDUSD";
            double volume = 1200;
            string label = "MarketRangeOrder";
            double? stopLossPips = 20;
            double? takeProfitPips = 30;
            string comment = "Market range order test";
            bool hasTrailingStop = true;
            StopTriggerMethod stopLossTriggerMethod = StopTriggerMethod.Trade;

            double marketRangePips = 15;
            double basePrice = 0.6200;

            // Act
            var marketRangeOrder = _orderFactory!.CreateMarketRangeOrder(
                id, tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod, marketRangePips, basePrice);

            // Assert
            Assert.IsNotNull(marketRangeOrder);
            Assert.AreEqual(id, marketRangeOrder.Id);
            Assert.AreEqual(tradeType, marketRangeOrder.TradeType);
            Assert.AreEqual(symbolName, marketRangeOrder.SymbolName);
            Assert.AreEqual(volume, marketRangeOrder.Volume);
            Assert.AreEqual(label, marketRangeOrder.Label);
            Assert.AreEqual(stopLossPips, marketRangeOrder.StopLossPips);
            Assert.AreEqual(takeProfitPips, marketRangeOrder.TakeProfitPips);
            Assert.AreEqual(comment, marketRangeOrder.Comment);
            Assert.AreEqual(hasTrailingStop, marketRangeOrder.HasTrailingStop);
            Assert.AreEqual(stopLossTriggerMethod, marketRangeOrder.StopLossTriggerMethod);
            Assert.AreEqual(marketRangePips, marketRangeOrder.MarketRangePips);
            Assert.AreEqual(basePrice, marketRangeOrder.BasePrice);
        }

        [TestMethod]
        public void CreateLimitOrder_ShouldReturnValidLimitOrder()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            TradeType tradeType = TradeType.Sell;
            string symbolName = "GBPUSD";
            double volume = 500;
            string label = "LimitOrder";
            double? stopLossPips = 15;
            double? takeProfitPips = 25;
            string comment = "Limit order test";
            bool hasTrailingStop = false;
            StopTriggerMethod stopLossTriggerMethod = StopTriggerMethod.Trade;
            double targetPrice = 1.2345;
            DateTime? expirationTime = DateTime.UtcNow.AddHours(1);
            ProtectionType? protectionType = ProtectionType.None;

            // Act
            var limitOrder = _orderFactory!.CreateLimitOrder(
                id, tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod, targetPrice, expirationTime, protectionType);

            // Assert
            Assert.IsNotNull(limitOrder);
            Assert.AreEqual(id, limitOrder.Id);
            Assert.AreEqual(tradeType, limitOrder.TradeType);
            Assert.AreEqual(symbolName, limitOrder.SymbolName);
            Assert.AreEqual(volume, limitOrder.Volume);
            Assert.AreEqual(label, limitOrder.Label);
            Assert.AreEqual(stopLossPips, limitOrder.StopLossPips);
            Assert.AreEqual(takeProfitPips, limitOrder.TakeProfitPips);
            Assert.AreEqual(comment, limitOrder.Comment);
            Assert.AreEqual(hasTrailingStop, limitOrder.HasTrailingStop);
            Assert.AreEqual(stopLossTriggerMethod, limitOrder.StopLossTriggerMethod);
            Assert.AreEqual(targetPrice, limitOrder.TargetPrice);
            Assert.AreEqual(expirationTime, limitOrder.ExpirationTime);
            Assert.AreEqual(protectionType, limitOrder.ProtectionType);
        }

        [TestMethod]
        public void CreateStopOrder_ShouldReturnValidStopOrder()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            TradeType tradeType = TradeType.Buy;
            string symbolName = "USDJPY";
            double volume = 2000;
            string label = "StopOrder";
            double? stopLossPips = 5;
            double? takeProfitPips = 15;
            string comment = "Stop order test";
            bool hasTrailingStop = true;
            StopTriggerMethod stopLossTriggerMethod = StopTriggerMethod.Trade;
            double targetPrice = 110.5;
            DateTime? expirationTime = DateTime.UtcNow.AddDays(1);
            ProtectionType? protectionType = ProtectionType.Absolute;
            double stopOrderPips = 10;
            double basePrice = 110.0;

            // Act
            var stopOrder = _orderFactory!.CreateStopOrder(
                id, tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod, targetPrice, expirationTime, protectionType, stopOrderPips, basePrice);

            // Assert
            Assert.IsNotNull(stopOrder);
            Assert.AreEqual(id, stopOrder.Id);
            Assert.AreEqual(tradeType, stopOrder.TradeType);
            Assert.AreEqual(symbolName, stopOrder.SymbolName);
            Assert.AreEqual(volume, stopOrder.Volume);
            Assert.AreEqual(label, stopOrder.Label);
            Assert.AreEqual(stopLossPips, stopOrder.StopLossPips);
            Assert.AreEqual(takeProfitPips, stopOrder.TakeProfitPips);
            Assert.AreEqual(comment, stopOrder.Comment);
            Assert.AreEqual(hasTrailingStop, stopOrder.HasTrailingStop);
            Assert.AreEqual(stopLossTriggerMethod, stopOrder.StopLossTriggerMethod);
            Assert.AreEqual(targetPrice, stopOrder.TargetPrice);
            Assert.AreEqual(expirationTime, stopOrder.ExpirationTime);
            Assert.AreEqual(protectionType, stopOrder.ProtectionType);
            Assert.AreEqual(stopOrderPips, stopOrder.StopOrderPips);
            Assert.AreEqual(basePrice, stopOrder.BasePrice);
        }

        [TestMethod]
        public void CreateLimitStopOrder_ShouldReturnValidLimitStopOrder()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            TradeType tradeType = TradeType.Sell;
            string symbolName = "AUDUSD";
            double volume = 1500;
            string label = "LimitStopOrder";
            double? stopLossPips = 12;
            double? takeProfitPips = 18;
            string comment = "Limit stop order test";
            bool hasTrailingStop = false;
            StopTriggerMethod stopLossTriggerMethod = StopTriggerMethod.Trade;
            double targetPrice = 0.6789;
            DateTime? expirationTime = DateTime.UtcNow.AddDays(2);
            ProtectionType? protectionType = ProtectionType.Absolute;
            double stopOrderPips = 8;
            double basePrice = 0.6750;
            double stopLimitRangePips = 5;
            StopTriggerMethod stopOrderTriggerMethod = StopTriggerMethod.Trade;

            // Act
            var limitStopOrder = _orderFactory!.CreateStopLimitOrder(
                id, tradeType, symbolName, volume, label, stopLossPips, takeProfitPips, comment, hasTrailingStop, stopLossTriggerMethod, targetPrice, expirationTime, protectionType, stopOrderPips, basePrice, stopLimitRangePips, stopOrderTriggerMethod);

            // Assert
            Assert.IsNotNull(limitStopOrder);
            Assert.AreEqual(id, limitStopOrder.Id);
            Assert.AreEqual(tradeType, limitStopOrder.TradeType);
            Assert.AreEqual(symbolName, limitStopOrder.SymbolName);
            Assert.AreEqual(volume, limitStopOrder.Volume);
            Assert.AreEqual(label, limitStopOrder.Label);
            Assert.AreEqual(stopLossPips, limitStopOrder.StopLossPips);
            Assert.AreEqual(takeProfitPips, limitStopOrder.TakeProfitPips);
            Assert.AreEqual(comment, limitStopOrder.Comment);
            Assert.AreEqual(hasTrailingStop, limitStopOrder.HasTrailingStop);
            Assert.AreEqual(stopLossTriggerMethod, limitStopOrder.StopLossTriggerMethod);
            Assert.AreEqual(targetPrice, limitStopOrder.TargetPrice);
            Assert.AreEqual(expirationTime, limitStopOrder.ExpirationTime);
            Assert.AreEqual(protectionType, limitStopOrder.ProtectionType);
            Assert.AreEqual(stopOrderPips, limitStopOrder.StopOrderPips);
            Assert.AreEqual(basePrice, limitStopOrder.BasePrice);
            Assert.AreEqual(stopLimitRangePips, limitStopOrder.StopLimitRangePips);
            Assert.AreEqual(stopOrderTriggerMethod, limitStopOrder.StopOrderTriggerMethod);
        }
    }
}