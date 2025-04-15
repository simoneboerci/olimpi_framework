using Moq;
using cAlgo.API.Internals;
using cAlgo.API;
using CAlgoInterface.Core.Interfaces;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Models;
using CAlgoInterface.Core.Routing;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class SymbolAdapterTests
    {
        private Mock<Symbol>? _mockSymbol;
        private Mock<IAssetAdapter>? _mockAssetAdapter;
        private Mock<IRoundingModeMapper>? _mockRoundingModeMapper;
        private Mock<IProportionalAmountTypeMapper>? _mockProportionalAmountTypeMapper;
        private Mock<ISymbolTradingModeMapper>? _mockSymbolTradingModeMapper;
        private Mock<ISymbolCommissionInfoMapper>? _mockSymbolCommissionInfoMapper;
        private Mock<IMarketHoursAdapter>? _mockMarketHoursAdapter;

        private SymbolAdapter? _symbolAdapter;

        [TestInitialize]
        public void Setup()
        {
            _mockSymbol = new Mock<Symbol>();
            _mockAssetAdapter = new Mock<IAssetAdapter>();
            _mockRoundingModeMapper = new Mock<IRoundingModeMapper>();
            _mockProportionalAmountTypeMapper = new Mock<IProportionalAmountTypeMapper>();
            _mockSymbolTradingModeMapper = new Mock<ISymbolTradingModeMapper>();
            _mockSymbolCommissionInfoMapper = new Mock<ISymbolCommissionInfoMapper>();
            _mockMarketHoursAdapter = new Mock<IMarketHoursAdapter>();

            _symbolAdapter = new SymbolAdapter(
                _mockSymbol.Object,
                _mockAssetAdapter.Object,
                _mockRoundingModeMapper.Object,
                _mockProportionalAmountTypeMapper.Object,
                _mockSymbolTradingModeMapper.Object,
                _mockSymbolCommissionInfoMapper.Object,
                _mockMarketHoursAdapter.Object
            );
        }

        [TestMethod]
        public void BaseAsset_ShouldReturnMappedAsset()
        {
            // Arrange
            var mockBaseAsset = new Mock<IAsset>();
            var baseAsset = new Mock<Asset>();
            baseAsset.Setup(a => a.Name).Returns("EURUSD");
            _mockSymbol!.Setup(s => s.BaseAsset).Returns(baseAsset.Object);
            _mockAssetAdapter!.Setup(a => a.ToAsset(baseAsset.Object)).Returns(mockBaseAsset.Object);

            // Act
            var result = _symbolAdapter!.BaseAsset;

            // Assert
            Assert.AreEqual(mockBaseAsset.Object, result);
            _mockAssetAdapter.Verify(a => a.ToAsset(baseAsset.Object), Times.Once);
        }

        [TestMethod]
        public void QuoteAsset_ShouldReturnMappedAsset()
        {
            // Arrange
            var mockQuoteAsset = new Mock<IAsset>();
            var quoteAsset = new Mock<Asset>();
            quoteAsset.Setup(a => a.Name).Returns("USD");
            _mockSymbol!.Setup(s => s.QuoteAsset).Returns(quoteAsset.Object);
            _mockAssetAdapter!.Setup(a => a.ToAsset(quoteAsset.Object)).Returns(mockQuoteAsset.Object);

            // Act
            var result = _symbolAdapter!.QuoteAsset;

            // Assert
            Assert.AreEqual(mockQuoteAsset.Object, result);
            _mockAssetAdapter.Verify(a => a.ToAsset(quoteAsset.Object), Times.Once);
        }

        [TestMethod]
        public void MarketHours_ShouldReturnMappedMarketHours()
        {
            // Arrange
            var mockMarketHours = new Mock<IMarketHours>();
            var marketHours = new Mock<MarketHours>().Object; // Use a mock or replace with a concrete implementation
            _mockSymbol!.Setup(s => s.MarketHours).Returns(marketHours);
            _mockMarketHoursAdapter!.Setup(m => m.ToMarketHours(marketHours)).Returns(mockMarketHours.Object);

            // Act
            var result = _symbolAdapter!.MarketHours;

            // Assert
            Assert.AreEqual(mockMarketHours.Object, result);
            _mockMarketHoursAdapter.Verify(m => m.ToMarketHours(marketHours), Times.Once);
        }

        [TestMethod]
        public void Ask_ShouldReturnSymbolAsk()
        {
            // Arrange
            _mockSymbol!.Setup(s => s.Ask).Returns(1.2345);

            // Act
            var result = _symbolAdapter!.Ask;

            // Assert
            Assert.AreEqual(1.2345, result);
        }

        [TestMethod]
        public void Bid_ShouldReturnSymbolBid()
        {
            // Arrange
            _mockSymbol!.Setup(s => s.Bid).Returns(1.2340);

            // Act
            var result = _symbolAdapter!.Bid;

            // Assert
            Assert.AreEqual(1.2340, result);
        }

        [TestMethod]
        public void Spread_ShouldReturnSymbolSpread()
        {
            // Arrange
            _mockSymbol!.Setup(s => s.Spread).Returns(0.0005);

            // Act
            var result = _symbolAdapter!.Spread;

            // Assert
            Assert.AreEqual(0.0005, result);
        }

        [TestMethod]
        public void CommissionInfo_ShouldReturnMappedCommissionInfo()
        {
            // Arrange
            var mockCommissionInfo = new SymbolCommissionInfo();
            _mockSymbolCommissionInfoMapper!.Setup(m => m.FromCAlgoSymbol(_mockSymbol!.Object)).Returns(mockCommissionInfo);

            // Act
            var result = _symbolAdapter!.CommissionInfo;

            // Assert
            Assert.AreEqual(mockCommissionInfo, result);
            _mockSymbolCommissionInfoMapper.Verify(m => m.FromCAlgoSymbol(_mockSymbol!.Object), Times.Once);
        }

        [TestMethod]
        public void Name_ShouldReturnSymbolName()
        {
            // Arrange
            _mockSymbol!.Setup(s => s.Name).Returns("EURUSD");

            // Act
            var result = _symbolAdapter!.Name;

            // Assert
            Assert.AreEqual("EURUSD", result);
        }

        [TestMethod]
        public void Description_ShouldReturnSymbolDescription()
        {
            // Arrange
            _mockSymbol!.Setup(s => s.Description).Returns("Euro vs US Dollar");

            // Act
            var result = _symbolAdapter!.Description;

            // Assert
            Assert.AreEqual("Euro vs US Dollar", result);
        }
    }
}