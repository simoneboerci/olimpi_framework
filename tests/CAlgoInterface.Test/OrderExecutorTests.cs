using Moq;
using CAlgoInterface.Backend.Services;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Data;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Core.Routing;
using cAlgo.API;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class OrderExecutorTests
    {
        private readonly Mock<IExecuteCAlgoOrders> _mockCAlgoOrderExecutor;
        private readonly Mock<IOrderMapper<IMarketOrder, CAlgoMarketOrderStruct>> _mockMarketOrderMapper;
        private readonly Mock<IOrderMapper<IMarketRangeOrder, CAlgoMarketRangeOrderStruct>> _mockMarketRangeOrderMapper;
        private readonly Mock<IOrderMapper<IStopOrder, CAlgoStopOrderStruct>> _mockStopOrderMapper;
        private readonly Mock<IOrderMapper<ILimitOrder, CAlgoLimitOrderStruct>> _mockLimitOrderMapper;
        private readonly Mock<IOrderMapper<IStopLimitOrder, CAlgoStopLimitOrderStruct>> _mockStopLimitOrderMapper;
        private readonly Mock<ITradeResultAdapter> _mockTradeResultAdapter;
        private readonly Mock<ITradeOperationAdapter> _mockTradeOperationAdapter;
        private readonly OrderExecutor _orderExecutor;

        public OrderExecutorTests()
        {
            _mockCAlgoOrderExecutor = new Mock<IExecuteCAlgoOrders>();
            _mockMarketOrderMapper = new Mock<IOrderMapper<IMarketOrder, CAlgoMarketOrderStruct>>();
            _mockMarketRangeOrderMapper = new Mock<IOrderMapper<IMarketRangeOrder, CAlgoMarketRangeOrderStruct>>();
            _mockStopOrderMapper = new Mock<IOrderMapper<IStopOrder, CAlgoStopOrderStruct>>();
            _mockLimitOrderMapper = new Mock<IOrderMapper<ILimitOrder, CAlgoLimitOrderStruct>>();
            _mockStopLimitOrderMapper = new Mock<IOrderMapper<IStopLimitOrder, CAlgoStopLimitOrderStruct>>();
            _mockTradeResultAdapter = new Mock<ITradeResultAdapter>();
            _mockTradeOperationAdapter = new Mock<ITradeOperationAdapter>();

            _orderExecutor = new OrderExecutor(
                _mockCAlgoOrderExecutor.Object,
                _mockMarketOrderMapper.Object,
                _mockMarketRangeOrderMapper.Object,
                _mockStopOrderMapper.Object,
                _mockLimitOrderMapper.Object,
                _mockStopLimitOrderMapper.Object,
                _mockTradeResultAdapter.Object,
                _mockTradeOperationAdapter.Object
            );
        }

        #region ExecuteMarketOrder Tests

        [TestMethod]
        public void ExecuteMarketOrder_ShouldReturnExpectedResult()
        {
            // Arrange
            var mockMarketOrder = Mock.Of<IMarketOrder>();
            var mappedDto = new CAlgoMarketOrderStruct(
                TradeType.Buy,
                "EURUSD",
                1000,
                "TestLabel",
                20,
                30,
                "TestComment",
                false,
                StopTriggerMethod.Trade
            );

            var mockCAlgoResult = (TradeResult)Activator.CreateInstance(
                typeof(TradeResult),
                nonPublic: true
            )!;

            _mockMarketOrderMapper
                .Setup(mapper => mapper.Map(mockMarketOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.ExecuteMarketOrder(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.Label,
                    mappedDto.StopLossPips,
                    mappedDto.TakeProfitPips,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopTriggerMethod
                ))
                .Returns(mockCAlgoResult);

            _mockTradeResultAdapter
                .Setup(adapter => adapter.ToMarketTradeResult(mockCAlgoResult))
                .Returns(new Mock<IMarketTradeResult>().Object);

            // Act
            var result = _orderExecutor.ExecuteMarketOrder(mockMarketOrder);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IMarketTradeResult));
            _mockMarketOrderMapper.Verify(mapper => mapper.Map(mockMarketOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.ExecuteMarketOrder(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.Label,
                mappedDto.StopLossPips,
                mappedDto.TakeProfitPips,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopTriggerMethod
            ), Times.Once);
            _mockTradeResultAdapter.Verify(adapter => adapter.ToMarketTradeResult(mockCAlgoResult), Times.Once);
        }

        [TestMethod]
        public void ExecuteMarketOrderAsync_ShouldReturnExpectedOperation()
        {
            // Arrange
            var mockMarketOrder = Mock.Of<IMarketOrder>();
            var mappedDto = new CAlgoMarketOrderStruct(
                TradeType.Buy,
                "EURUSD",
                1000,
                "TestLabel",
                20,
                30,
                "TestComment",
                false,
                StopTriggerMethod.Trade
            );

            // Non mockare TradeOperation direttamente, ma mettere null o usare TypeMock/JustMock
            // per creare un mock di una classe non mockabile
            TradeOperation? mockCAlgoOperation = null;
            var expectedOperation = new Mock<IMarketTradeOperation>().Object;

            _mockMarketOrderMapper
                .Setup(mapper => mapper.Map(mockMarketOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.ExecuteMarketOrderAsync(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.Label,
                    mappedDto.StopLossPips,
                    mappedDto.TakeProfitPips,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopTriggerMethod,
                    It.IsAny<Action<TradeResult>>()))
                .Returns(mockCAlgoOperation!);

            _mockTradeOperationAdapter
                .Setup(adapter => adapter.ToMarketTradeOperation(mockCAlgoOperation))
                .Returns(expectedOperation);

            // Act
            var result = _orderExecutor.ExecuteMarketOrderAsync(mockMarketOrder);

            // Assert
            Assert.AreEqual(expectedOperation, result);
            _mockMarketOrderMapper.Verify(mapper => mapper.Map(mockMarketOrder), Times.Once);
            _mockTradeOperationAdapter.Verify(adapter => adapter.ToMarketTradeOperation(mockCAlgoOperation), Times.Once);
        }

        [TestMethod]
        public void ExecuteMarketOrderAsync_WithCallback_ShouldInvokeCallbackWithResult()
        {
            // Arrange
            var mockMarketOrder = Mock.Of<IMarketOrder>();
            var mappedDto = new CAlgoMarketOrderStruct(
                TradeType.Buy,
                "EURUSD",
                1000,  // Nota: questo è un int, ma nel metodo è richiesto un double
                "TestLabel",
                20,
                30,
                "TestComment",
                false,
                StopTriggerMethod.Trade
            );

            TradeOperation? mockCAlgoOperation = null;
            var mockCAlgoResult = (TradeResult)Activator.CreateInstance(typeof(TradeResult), nonPublic: true)!;
            var mockMarketResult = new Mock<IMarketTradeResult>().Object;
            
            Action<TradeResult>? capturedCallback = null;

            _mockMarketOrderMapper
                .Setup(mapper => mapper.Map(mockMarketOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.ExecuteMarketOrderAsync(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    (double)mappedDto.Volume, // Converti da int a double
                    mappedDto.Label,
                    mappedDto.StopLossPips,
                    mappedDto.TakeProfitPips,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopTriggerMethod,
                    It.IsAny<Action<TradeResult>>()))
                .Callback<TradeType, string, double, string, double?, double?, string, bool, StopTriggerMethod?, Action<TradeResult>>(
                    // Nota la modifica dei tipi di parametri qui per corrispondere alla firma del metodo
                    (_, _, _, _, _, _, _, _, _, callback) => capturedCallback = callback)
                .Returns(mockCAlgoOperation!);

            _mockTradeResultAdapter
                .Setup(adapter => adapter.ToMarketTradeResult(mockCAlgoResult))
                .Returns(mockMarketResult);

            bool callbackInvoked = false;
            IMarketTradeResult? capturedResult = null;
            
            // Act
            _orderExecutor.ExecuteMarketOrderAsync(mockMarketOrder, result => {
                callbackInvoked = true;
                capturedResult = result;
            });

            // Simuliamo la chiamata della callback
            capturedCallback!(mockCAlgoResult);

            // Assert
            Assert.IsTrue(callbackInvoked);
            Assert.AreEqual(mockMarketResult, capturedResult);
            _mockMarketOrderMapper.Verify(mapper => mapper.Map(mockMarketOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.ExecuteMarketOrderAsync(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                (double)mappedDto.Volume, // Converti da int a double
                mappedDto.Label,
                mappedDto.StopLossPips,
                mappedDto.TakeProfitPips,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopTriggerMethod,
                It.IsAny<Action<TradeResult>>()), Times.Once);
            _mockTradeResultAdapter.Verify(adapter => adapter.ToMarketTradeResult(mockCAlgoResult), Times.Once);
        }

        #endregion

        #region ExecuteMarketRangeOrder Tests

        [TestMethod]
        public void ExecuteMarketRangeOrder_ShouldReturnExpectedResult()
        {
            // Arrange
            var mockMarketRangeOrder = Mock.Of<IMarketRangeOrder>();
            var mappedDto = new CAlgoMarketRangeOrderStruct(
                TradeType.Buy,
                "EURUSD",
                1000,
                10,
                1.12345,
                "TestLabel",
                20,
                30,
                "TestComment",
                false,
                StopTriggerMethod.Trade
            );

            var mockCAlgoResult = (TradeResult)Activator.CreateInstance(
                typeof(TradeResult),
                nonPublic: true
            )!;

            _mockMarketRangeOrderMapper
                .Setup(mapper => mapper.Map(mockMarketRangeOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.ExecuteMarketRangeOrder(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.MarketRangePips,
                    mappedDto.BasePrice,
                    mappedDto.Label,
                    mappedDto.StopLossPips,
                    mappedDto.TakeProfitPips,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopTriggerMethod
                ))
                .Returns(mockCAlgoResult);

            _mockTradeResultAdapter
                .Setup(adapter => adapter.ToMarketTradeResult(mockCAlgoResult))
                .Returns(new Mock<IMarketTradeResult>().Object);

            // Act
            var result = _orderExecutor.ExecuteMarketRangeOrder(mockMarketRangeOrder);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IMarketTradeResult));
            _mockMarketRangeOrderMapper.Verify(mapper => mapper.Map(mockMarketRangeOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.ExecuteMarketRangeOrder(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.MarketRangePips,
                mappedDto.BasePrice,
                mappedDto.Label,
                mappedDto.StopLossPips,
                mappedDto.TakeProfitPips,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopTriggerMethod
            ), Times.Once);
            _mockTradeResultAdapter.Verify(adapter => adapter.ToMarketTradeResult(mockCAlgoResult), Times.Once);
        }

        [TestMethod]
        public void ExecuteMarketRangeOrderAsync_ShouldReturnExpectedOperation()
        {
            // Arrange
            var mockMarketRangeOrder = Mock.Of<IMarketRangeOrder>();
            var mappedDto = new CAlgoMarketRangeOrderStruct(
                TradeType.Buy,
                "EURUSD",
                1000,
                10,
                1.12345,
                "TestLabel",
                20,
                30,
                "TestComment",
                false,
                StopTriggerMethod.Trade
            );

            TradeOperation? mockCAlgoOperation = null;
            var expectedOperation = new Mock<IMarketTradeOperation>().Object;

            _mockMarketRangeOrderMapper
                .Setup(mapper => mapper.Map(mockMarketRangeOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.ExecuteMarketRangeOrderAsync(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.MarketRangePips,
                    mappedDto.BasePrice,
                    mappedDto.Label,
                    mappedDto.StopLossPips,
                    mappedDto.TakeProfitPips,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopTriggerMethod,
                    It.IsAny<Action<TradeResult>>()))
                .Returns(mockCAlgoOperation!);

            _mockTradeOperationAdapter
                .Setup(adapter => adapter.ToMarketTradeOperation(mockCAlgoOperation))
                .Returns(expectedOperation);

            // Act
            var result = _orderExecutor.ExecuteMarketRangeOrderAsync(mockMarketRangeOrder);

            // Assert
            Assert.AreEqual(expectedOperation, result);
            _mockMarketRangeOrderMapper.Verify(mapper => mapper.Map(mockMarketRangeOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.ExecuteMarketRangeOrderAsync(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.MarketRangePips,
                mappedDto.BasePrice,
                mappedDto.Label,
                mappedDto.StopLossPips,
                mappedDto.TakeProfitPips,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopTriggerMethod,
                It.IsAny<Action<TradeResult>>()), Times.Once);
            _mockTradeOperationAdapter.Verify(adapter => adapter.ToMarketTradeOperation(mockCAlgoOperation), Times.Once);
        }

        #endregion

        #region PlaceLimitOrder Tests

        [TestMethod]
        public void PlaceLimitOrder_ShouldReturnExpectedResult()
        {
            // Arrange
            var mockLimitOrder = Mock.Of<ILimitOrder>();
            var mappedDto = new CAlgoLimitOrderStruct(
                TradeType.Sell,
                "GBPUSD",
                2000,
                1.23456,
                "TestLabel",
                15,
                25,
                ProtectionType.None,
                DateTime.UtcNow.AddHours(1),
                "TestComment",
                true,
                StopTriggerMethod.Trade
            );

            var mockCAlgoResult = (TradeResult)Activator.CreateInstance(
                typeof(TradeResult),
                nonPublic: true
            )!;

            _mockLimitOrderMapper
                .Setup(mapper => mapper.Map(mockLimitOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.PlaceLimitOrder(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.TargetPrice,
                    mappedDto.Label,
                    mappedDto.StopLoss,
                    mappedDto.TakeProfit,
                    mappedDto.ProtectionType,
                    mappedDto.Expiration,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopLossTriggerMethod
                ))
                .Returns(mockCAlgoResult);

            _mockTradeResultAdapter
                .Setup(adapter => adapter.ToPendingTradeResult(mockCAlgoResult))
                .Returns(new Mock<IPendingTradeResult>().Object);

            // Act
            var result = _orderExecutor.PlaceLimitOrder(mockLimitOrder);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IPendingTradeResult));
            _mockLimitOrderMapper.Verify(mapper => mapper.Map(mockLimitOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.PlaceLimitOrder(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.TargetPrice,
                mappedDto.Label,
                mappedDto.StopLoss,
                mappedDto.TakeProfit,
                mappedDto.ProtectionType,
                mappedDto.Expiration,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopLossTriggerMethod
            ), Times.Once);
            _mockTradeResultAdapter.Verify(adapter => adapter.ToPendingTradeResult(mockCAlgoResult), Times.Once);
        }

        [TestMethod]
        public void PlaceLimitOrderAsync_ShouldReturnExpectedOperation()
        {
            // Arrange
            var mockLimitOrder = Mock.Of<ILimitOrder>();
            var mappedDto = new CAlgoLimitOrderStruct(
                TradeType.Sell,
                "GBPUSD",
                2000,
                1.23456,
                "TestLabel",
                15,
                25,
                ProtectionType.None,
                DateTime.UtcNow.AddHours(1),
                "TestComment",
                true,
                StopTriggerMethod.Trade
            );

            TradeOperation? mockCAlgoOperation = null;
            var expectedOperation = new Mock<IPendingTradeOperation>().Object;

            _mockLimitOrderMapper
                .Setup(mapper => mapper.Map(mockLimitOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.PlaceLimitOrderAsync(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.TargetPrice,
                    mappedDto.Label,
                    mappedDto.StopLoss,
                    mappedDto.TakeProfit,
                    mappedDto.ProtectionType,
                    mappedDto.Expiration,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopLossTriggerMethod,
                    It.IsAny<Action<TradeResult>>()))
                .Returns(mockCAlgoOperation!);

            _mockTradeOperationAdapter
                .Setup(adapter => adapter.ToPendingTradeOperation(mockCAlgoOperation))
                .Returns(expectedOperation);

            // Act
            var result = _orderExecutor.PlaceLimitOrderAsync(mockLimitOrder);

            // Assert
            Assert.AreEqual(expectedOperation, result);
            _mockLimitOrderMapper.Verify(mapper => mapper.Map(mockLimitOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.PlaceLimitOrderAsync(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.TargetPrice,
                mappedDto.Label,
                mappedDto.StopLoss,
                mappedDto.TakeProfit,
                mappedDto.ProtectionType,
                mappedDto.Expiration,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopLossTriggerMethod,
                It.IsAny<Action<TradeResult>>()), Times.Once);
            _mockTradeOperationAdapter.Verify(adapter => adapter.ToPendingTradeOperation(mockCAlgoOperation), Times.Once);
        }

        #endregion

        #region PlaceStopOrder Tests

        [TestMethod]
        public void PlaceStopOrder_ShouldReturnExpectedResult()
        {
            // Arrange
            var mockStopOrder = Mock.Of<IStopOrder>();
            var mappedDto = new CAlgoStopOrderStruct(
                TradeType.Buy,
                "USDJPY",
                1500,
                1.56789,
                "TestLabel",
                12,
                18,
                ProtectionType.None,
                DateTime.UtcNow.AddHours(2),
                "TestComment",
                false,
                StopTriggerMethod.Trade,
                StopTriggerMethod.Trade
            );

            var mockCAlgoResult = (TradeResult)Activator.CreateInstance(
                typeof(TradeResult),
                nonPublic: true
            )!;

            _mockStopOrderMapper
                .Setup(mapper => mapper.Map(mockStopOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.PlaceStopOrder(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.TargetPrice,
                    mappedDto.Label,
                    mappedDto.StopLoss,
                    mappedDto.TakeProfit,
                    mappedDto.ProtectionType,
                    mappedDto.Expiration,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopLossTriggerMethod,
                    mappedDto.StopOrderTriggerMethod
                ))
                .Returns(mockCAlgoResult);

            _mockTradeResultAdapter
                .Setup(adapter => adapter.ToPendingTradeResult(mockCAlgoResult))
                .Returns(new Mock<IPendingTradeResult>().Object);

            // Act
            var result = _orderExecutor.PlaceStopOrder(mockStopOrder);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IPendingTradeResult));
            _mockStopOrderMapper.Verify(mapper => mapper.Map(mockStopOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.PlaceStopOrder(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.TargetPrice,
                mappedDto.Label,
                mappedDto.StopLoss,
                mappedDto.TakeProfit,
                mappedDto.ProtectionType,
                mappedDto.Expiration,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopLossTriggerMethod,
                mappedDto.StopOrderTriggerMethod
            ), Times.Once);
            _mockTradeResultAdapter.Verify(adapter => adapter.ToPendingTradeResult(mockCAlgoResult), Times.Once);
        }

        [TestMethod]
        public void PlaceStopOrderAsync_ShouldReturnExpectedOperation()
        {
            // Arrange
            var mockStopOrder = Mock.Of<IStopOrder>();
            var mappedDto = new CAlgoStopOrderStruct(
                TradeType.Buy,
                "USDJPY",
                1500,
                1.56789,
                "TestLabel",
                12,
                18,
                ProtectionType.None,
                DateTime.UtcNow.AddHours(2),
                "TestComment",
                false,
                StopTriggerMethod.Trade,
                StopTriggerMethod.Trade
            );

            TradeOperation? mockCAlgoOperation = null;
            var expectedOperation = new Mock<IPendingTradeOperation>().Object;

            _mockStopOrderMapper
                .Setup(mapper => mapper.Map(mockStopOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.PlaceStopOrderAsync(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.TargetPrice,
                    mappedDto.Label,
                    mappedDto.StopLoss,
                    mappedDto.TakeProfit,
                    mappedDto.ProtectionType,
                    mappedDto.Expiration,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopLossTriggerMethod,
                    mappedDto.StopOrderTriggerMethod,
                    It.IsAny<Action<TradeResult>>()))
                .Returns(mockCAlgoOperation!);

            _mockTradeOperationAdapter
                .Setup(adapter => adapter.ToPendingTradeOperation(mockCAlgoOperation))
                .Returns(expectedOperation);

            // Act
            var result = _orderExecutor.PlaceStopOrderAsync(mockStopOrder);

            // Assert
            Assert.AreEqual(expectedOperation, result);
            _mockStopOrderMapper.Verify(mapper => mapper.Map(mockStopOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.PlaceStopOrderAsync(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.TargetPrice,
                mappedDto.Label,
                mappedDto.StopLoss,
                mappedDto.TakeProfit,
                mappedDto.ProtectionType,
                mappedDto.Expiration,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopLossTriggerMethod,
                mappedDto.StopOrderTriggerMethod,
                It.IsAny<Action<TradeResult>>()), Times.Once);
            _mockTradeOperationAdapter.Verify(adapter => adapter.ToPendingTradeOperation(mockCAlgoOperation), Times.Once);
        }

        #endregion

        #region PlaceStopLimitOrder Tests

        [TestMethod]
        public void PlaceStopLimitOrder_ShouldReturnExpectedResult()
        {
            // Arrange
            var mockStopLimitOrder = Mock.Of<IStopLimitOrder>();
            var mappedDto = new CAlgoStopLimitOrderStruct(
                TradeType.Sell,
                "AUDUSD",
                1500,
                1.56789,
                5,
                "TestLabel",
                10,
                15,
                ProtectionType.None,
                DateTime.UtcNow.AddHours(3),
                "TestComment",
                true,
                StopTriggerMethod.Trade,
                StopTriggerMethod.Trade
            );

            var mockCAlgoResult = (TradeResult)Activator.CreateInstance(
                typeof(TradeResult),
                nonPublic: true
            )!;

            _mockStopLimitOrderMapper
                .Setup(mapper => mapper.Map(mockStopLimitOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.PlaceStopLimitOrder(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.TargetPrice,
                    mappedDto.StopLimitRangePips,
                    mappedDto.Label,
                    mappedDto.StopLoss,
                    mappedDto.TakeProfit,
                    mappedDto.ProtectionType,
                    mappedDto.Expiration,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopLossTriggerMethod
                ))
                .Returns(mockCAlgoResult);

            _mockTradeResultAdapter
                .Setup(adapter => adapter.ToPendingTradeResult(mockCAlgoResult))
                .Returns(new Mock<IPendingTradeResult>().Object);

            // Act
            var result = _orderExecutor.PlaceStopLimitOrder(mockStopLimitOrder);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IPendingTradeResult));
            _mockStopLimitOrderMapper.Verify(mapper => mapper.Map(mockStopLimitOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.PlaceStopLimitOrder(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.TargetPrice,
                mappedDto.StopLimitRangePips,
                mappedDto.Label,
                mappedDto.StopLoss,
                mappedDto.TakeProfit,
                mappedDto.ProtectionType,
                mappedDto.Expiration,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopLossTriggerMethod
            ), Times.Once);
            _mockTradeResultAdapter.Verify(adapter => adapter.ToPendingTradeResult(mockCAlgoResult), Times.Once);
        }

        [TestMethod]
        public void PlaceStopLimitOrderAsync_ShouldReturnExpectedOperation()
        {
            // Arrange
            var mockStopLimitOrder = Mock.Of<IStopLimitOrder>();
            var mappedDto = new CAlgoStopLimitOrderStruct(
                TradeType.Sell,
                "AUDUSD",
                1500,
                1.56789,
                5,
                "TestLabel",
                10,
                15,
                ProtectionType.None,
                DateTime.UtcNow.AddHours(3),
                "TestComment",
                true,
                StopTriggerMethod.Trade,
                StopTriggerMethod.Trade
            );

            TradeOperation? mockCAlgoOperation = null;
            var expectedOperation = new Mock<IPendingTradeOperation>().Object;

            _mockStopLimitOrderMapper
                .Setup(mapper => mapper.Map(mockStopLimitOrder))
                .Returns(mappedDto);

            _mockCAlgoOrderExecutor
                .Setup(executor => executor.PlaceStopLimitOrderAsync(
                    mappedDto.TradeType,
                    mappedDto.SymbolName,
                    mappedDto.Volume,
                    mappedDto.TargetPrice,
                    mappedDto.StopLimitRangePips,
                    mappedDto.Label,
                    mappedDto.StopLoss,
                    mappedDto.TakeProfit,
                    mappedDto.ProtectionType,
                    mappedDto.Expiration,
                    mappedDto.Comment,
                    mappedDto.HasTrailingStop,
                    mappedDto.StopLossTriggerMethod,
                    It.IsAny<Action<TradeResult>>()))
                .Returns(mockCAlgoOperation!);

            _mockTradeOperationAdapter
                .Setup(adapter => adapter.ToPendingTradeOperation(mockCAlgoOperation))
                .Returns(expectedOperation);

            // Act
            var result = _orderExecutor.PlaceStopLimitOrderAsync(mockStopLimitOrder);

            // Assert
            Assert.AreEqual(expectedOperation, result);
            _mockStopLimitOrderMapper.Verify(mapper => mapper.Map(mockStopLimitOrder), Times.Once);
            _mockCAlgoOrderExecutor.Verify(executor => executor.PlaceStopLimitOrderAsync(
                mappedDto.TradeType,
                mappedDto.SymbolName,
                mappedDto.Volume,
                mappedDto.TargetPrice,
                mappedDto.StopLimitRangePips,
                mappedDto.Label,
                mappedDto.StopLoss,
                mappedDto.TakeProfit,
                mappedDto.ProtectionType,
                mappedDto.Expiration,
                mappedDto.Comment,
                mappedDto.HasTrailingStop,
                mappedDto.StopLossTriggerMethod,
                It.IsAny<Action<TradeResult>>()), Times.Once);
            _mockTradeOperationAdapter.Verify(adapter => adapter.ToPendingTradeOperation(mockCAlgoOperation), Times.Once);
        }

        #endregion
    }
}
