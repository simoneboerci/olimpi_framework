using Moq;
using cAlgo.API;
using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class AssetAdapterTests
    {
        private Mock<Asset>? _mockCAlgoAsset;
        private AssetAdapter? _assetAdapter;

        [TestInitialize]
        public void Setup()
        {
            _mockCAlgoAsset = new Mock<Asset>();
            _assetAdapter = new AssetAdapter(_mockCAlgoAsset.Object);
        }

        [TestMethod]
        public void CAlgoAsset_ShouldReturnOriginalAsset()
        {
            // Act
            var result = _assetAdapter!.GetCAlgoAsset();

            // Assert
            Assert.AreEqual(_mockCAlgoAsset!.Object, result);
        }

        [TestMethod]
        public void Name_ShouldReturnCorrectName()
        {
            // Arrange
            _mockCAlgoAsset!.Setup(a => a.Name).Returns("EURUSD");

            // Act
            var result = _assetAdapter!.Name;

            // Assert
            Assert.AreEqual("EURUSD", result);
        }

        [TestMethod]
        public void Digits_ShouldReturnCorrectDigits()
        {
            // Arrange
            _mockCAlgoAsset!.Setup(a => a.Digits).Returns(5);

            // Act
            var result = _assetAdapter!.Digits;

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void ToAsset_ShouldReturnNewAssetAdapter()
        {
            // Arrange
            var newCAlgoAsset = new Mock<Asset>();

            // Act
            var result = _assetAdapter!.ToAsset(newCAlgoAsset.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(AssetAdapter));
            Assert.AreEqual(newCAlgoAsset.Object, ((AssetAdapter)result).GetCAlgoAsset());
        }

        [TestMethod]
        public void ToCAlgoAsset_ShouldReturnOriginalCAlgoAsset()
        {
            // Arrange
            var mockAssetAdapter = new Mock<IAssetAdapter>();
            mockAssetAdapter.Setup(a => a.GetCAlgoAsset()).Returns(_mockCAlgoAsset!.Object);

            // Act
            var result = _assetAdapter!.ToCAlgoAsset(mockAssetAdapter.Object);

            // Assert
            Assert.AreEqual(_mockCAlgoAsset.Object, result);
            mockAssetAdapter.Verify(a => a.GetCAlgoAsset(), Times.Once);
        }

        [TestMethod]
        public void Convert_ToAssetAdapter_ShouldReturnConvertedValue()
        {
            // Arrange
            var mockTargetAsset = new Mock<IAssetAdapter>();
            var mockTargetCAlgoAsset = new Mock<Asset>();
            mockTargetAsset.Setup(a => a.GetCAlgoAsset()).Returns(mockTargetCAlgoAsset.Object);
            _mockCAlgoAsset!.Setup(a => a.Convert(mockTargetCAlgoAsset.Object, 100)).Returns(200);

            // Act
            var result = _assetAdapter!.Convert(mockTargetAsset.Object, 100);

            // Assert
            Assert.AreEqual(200, result);
            mockTargetAsset.Verify(a => a.GetCAlgoAsset(), Times.Once);
            _mockCAlgoAsset.Verify(a => a.Convert(mockTargetCAlgoAsset.Object, 100), Times.Once);
        }

        [TestMethod]
        public void Convert_ToString_ShouldReturnConvertedValue()
        {
            // Arrange
            _mockCAlgoAsset!.Setup(a => a.Convert("USD", 100)).Returns(150);

            // Act
            var result = _assetAdapter!.Convert("USD", 100);

            // Assert
            Assert.AreEqual(150, result);
            _mockCAlgoAsset.Verify(a => a.Convert("USD", 100), Times.Once);
        }
    }
}