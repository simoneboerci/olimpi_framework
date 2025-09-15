using Moq;
using CAlgoInterface.Backend.Integrations;
using CAlgoInterface.Core.Routing;
using CAlgoInterface.Core.Interfaces;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class AccountAdapterTests
    {
        private Mock<cAlgo.API.Internals.IAccount>? _mockCAlgoAccount;
        private AccountAdapter? _accountAdapter;

        [TestInitialize]
        public void Setup()
        {
            _mockCAlgoAccount = new Mock<cAlgo.API.Internals.IAccount>();
            _accountAdapter = new AccountAdapter(
                _mockCAlgoAccount.Object,
                new Mock<IAssetAdapter>().Object,
                new Mock<IAccountMarginMapper>().Object,
                new Mock<IAccountProfitsMapper>().Object
            );
        }

        [TestMethod]
        public void CAlgoAccount_ShouldReturnOriginalAccount()
        {
            // Act
            var result = _accountAdapter!.GetCAlgoAccount();

            // Assert
            Assert.AreEqual(_mockCAlgoAccount!.Object, result);
        }

        [TestMethod]
        public void Balance_ShouldReturnCorrectBalance()
        {
            // Arrange
            _mockCAlgoAccount!.Setup(a => a.Balance).Returns(1000.50);

            // Act
            var result = _accountAdapter!.Balance;

            // Assert
            Assert.AreEqual(1000.50, result);
        }

        [TestMethod]
        public void Equity_ShouldReturnCorrectEquity()
        {
            // Arrange
            _mockCAlgoAccount!.Setup(a => a.Equity).Returns(1200.75);

            // Act
            var result = _accountAdapter!.Equity;

            // Assert
            Assert.AreEqual(1200.75, result);
        }

        [TestMethod]
        public void AccountMargin_ShouldReturnCorrectAccountMargin()
        {
            // Arrange
            var mockAssetAdapter = new Mock<IAssetAdapter>();
            var mockAccountMarginMapper = new Mock<IAccountMarginMapper>();
            var mockAccountProfitsMapper = new Mock<IAccountProfitsMapper>();

            var expectedMargin = new Mock<IAccountMargin>().Object;

            mockAccountMarginMapper
                .Setup(m => m.FromCAlgoAccount(_mockCAlgoAccount!.Object))
                .Returns(expectedMargin);

            var adapter = new AccountAdapter(
                _mockCAlgoAccount!.Object,
                mockAssetAdapter.Object,
                mockAccountMarginMapper.Object,
                mockAccountProfitsMapper.Object
            );

            // Act
            var actualMargin = adapter.Margin;

            // Assert
            Assert.AreEqual(expectedMargin, actualMargin);
            mockAccountMarginMapper.Verify(m => m.FromCAlgoAccount(_mockCAlgoAccount.Object), Times.Once);
        }

        [TestMethod]
        public void IsLive_ShouldReturnCorrectIsLive()
        {
            // Arrange
            _mockCAlgoAccount!.Setup(a => a.IsLive).Returns(true);

            // Act
            var result = _accountAdapter!.IsLive;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AccountProfits_ShouldReturnCorrectAccountProfits()
        {
            // Arrange
            var mockAssetAdapter = new Mock<IAssetAdapter>();
            var mockAccountMarginMapper = new Mock<IAccountMarginMapper>();
            var mockAccountProfitsMapper = new Mock<IAccountProfitsMapper>();

            var expectedProfits = new Mock<IAccountProfits>().Object;

            mockAccountProfitsMapper
                .Setup(m => m.FromCAlgoAccount(_mockCAlgoAccount!.Object))
                .Returns(expectedProfits);

            var adapter = new AccountAdapter(
                _mockCAlgoAccount!.Object,
                mockAssetAdapter.Object,
                mockAccountMarginMapper.Object,
                mockAccountProfitsMapper.Object
            );

            // Act
            var actualProfits = adapter.Profits;

            // Assert
            Assert.AreEqual(expectedProfits, actualProfits);
            mockAccountProfitsMapper.Verify(m => m.FromCAlgoAccount(_mockCAlgoAccount.Object), Times.Once);
        }

        [TestMethod]
        public void Leverage_ShouldReturnCorrectLeverage()
        {
            // Arrange
            _mockCAlgoAccount!.Setup(a => a.PreciseLeverage).Returns(100.0);

            // Act
            var result = _accountAdapter!.Leverage;

            // Assert
            Assert.AreEqual(100.0, result);
        }

        [TestMethod]
        public void StopOutLevel_ShouldReturnCorrectStopOutLevel()
        {
            // Arrange
            _mockCAlgoAccount!.Setup(a => a.StopOutLevel).Returns(150.0);

            // Act
            var result = _accountAdapter!.StopOutLevel;

            // Assert
            Assert.AreEqual(150.0, result);
        }


        [TestMethod]
        public void CreationTime_ShouldReturnCorrectCreationTime()
        {
            // Arrange
            _mockCAlgoAccount!.Setup(a => a.CreationTime).Returns(DateTime.MinValue);

            // Act
            var result = _accountAdapter!.CreationTime;

            // Assert
            Assert.AreEqual(DateTime.MinValue, result);
        }
    }
}