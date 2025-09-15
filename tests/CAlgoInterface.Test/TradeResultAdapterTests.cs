using cAlgo.API;
using CAlgoInterface.Backend.Integrations;

namespace CAlgoInterface.Test
{
    [TestClass]
    public class TradeResultAdapterTests
    {
        [TestMethod]
        public void Position_ShouldReturnWrappedPositionAdapter()
        {
            // Arrange
            PositionAdapter fakePositionAdapter = new(null!, null!, null!);
            var adapter = new TradeResultAdapter(null!, fakePositionAdapter);

            // Act
            var result = adapter.Position;

            // Assert
            Assert.AreEqual(fakePositionAdapter, result);
        }

        [TestMethod]
        public void GetCAlgoTradeResult_ShouldReturnOriginalTradeResult()
        {
            // Arrange
            var fakeTradeResult = (TradeResult)null!; // per ora non serve un’istanza vera
            PositionAdapter fakePositionAdapter = new(null!, null!, null!);
            var adapter = new TradeResultAdapter(fakeTradeResult, fakePositionAdapter);

            // Act
            var result = adapter.GetCAlgoTradeResult(null!);

            // Assert
            Assert.AreEqual(fakeTradeResult, result);
        }
    }
}
