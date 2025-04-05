using StateManagement.Core;

namespace StateMachine.Test;

[TestClass]
public class BaseStateContextTests
{
    private TestStateContext? _stateContext;

    [TestInitialize]
    public void Setup()
    {
        _stateContext = new TestStateContext();
    }

    [TestMethod]
    public void SetProperty_StoresValueCorrectly()
    {
        // Arrange
        string key = "TestKey";
        int value = 42;

        // Act
        _stateContext!.SetProperty(key, value);

        // Assert
        Assert.AreEqual(value, _stateContext.GetProperty<int>(key));
    }

    [TestMethod]
    public void GetProperty_ThrowsKeyNotFoundException_WhenKeyDoesNotExist()
    {
        // Arrange
        string key = "NonExistentKey";

        // Act & Assert
        Assert.ThrowsException<KeyNotFoundException>(() => _stateContext!.GetProperty<int>(key));
    }

    [TestMethod]
    public void GetProperty_ThrowsInvalidCastException_WhenTypeMismatchOccurs()
    {
        // Arrange
        string key = "TestKey";
        _stateContext!.SetProperty(key, 42);

        // Act & Assert
        Assert.ThrowsException<InvalidCastException>(() => _stateContext.GetProperty<string>(key));
    }

    [TestMethod]
    public void TryGetProperty_ReturnsTrueAndValue_WhenKeyExists()
    {
        // Arrange
        string key = "TestKey";
        int value = 42;
        _stateContext!.SetProperty(key, value);

        // Act
        bool result = _stateContext.TryGetProperty<int>(key, out int retrievedValue);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(value, retrievedValue);
    }

    [TestMethod]
    public void TryGetProperty_ReturnsFalse_WhenKeyDoesNotExist()
    {
        // Arrange
        string key = "NonExistentKey";

        // Act
        bool result = _stateContext!.TryGetProperty<int>(key, out int retrievedValue);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(default(int), retrievedValue);
    }

    [TestMethod]
    public void TryGetProperty_ReturnsFalse_WhenTypeMismatchOccurs()
    {
        // Arrange
        string key = "TestKey";
        _stateContext!.SetProperty(key, 42);

        // Act
        bool result = _stateContext.TryGetProperty<string>(key, out string retrievedValue);

        // Assert
        Assert.IsFalse(result);
        Assert.IsNull(retrievedValue);
    }
}

// Classe di test concreta per BaseStateContext
public class TestStateContext : BaseStateContext
{
    // Questa classe concreta serve solo per testare BaseStateContext
}