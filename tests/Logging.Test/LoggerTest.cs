using Logging.Core.Enums;
using Logging.Core.Interfaces;
using Logging.Core.Models;
using Logging.Services;
using Moq;

namespace Logging.Test;

[TestClass]
public class LoggerTest
{
    private Mock<ILogProvider>? _mockProvider1;
    private Mock<ILogProvider>? _mockProvider2;
    private Logger? _logger;

    [TestInitialize]
    public void Setup()
    {
        _mockProvider1 = new Mock<ILogProvider>();
        _mockProvider2 = new Mock<ILogProvider>();
        var providers = new List<ILogProvider> { _mockProvider1.Object, _mockProvider2.Object };
        _logger = new Logger(providers);
    }

    [TestMethod]
    public void Log_ShouldCallWriteOnAllProviders()
    {
        // Arrange
        var logEntry = new LogEntry(LogLevel.Debug, "Test log");

        // Act
        _logger!.Log(logEntry);

        // Assert
        _mockProvider1!.Verify(p => p.Write(logEntry), Times.Once);
        _mockProvider2!.Verify(p => p.Write(logEntry), Times.Once);
    }

    [TestMethod]
    public void Log_ShouldHandleExceptionsFromProviders()
    {
        // Arrange
        var logEntry = new LogEntry(LogLevel.Debug, "Test log");
        _mockProvider1!.Setup(p => p.Write(It.IsAny<LogEntry>())).Throws(new Exception("Provider error"));

        // Act
        _logger!.Log(logEntry);

        // Assert
        _mockProvider1!.Verify(p => p.Write(logEntry), Times.Once);
        _mockProvider2!.Verify(p => p.Write(logEntry), Times.Once);
    }

    [TestMethod]
    public async Task LogAsync_ShouldCallWriteAsyncOnAllProviders()
    {
        // Arrange
        var logEntry = new LogEntry(LogLevel.Debug, "Test log");
        _mockProvider1!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
            .Returns(Task.CompletedTask);
        _mockProvider2!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
            .Returns(Task.CompletedTask);

        // Act
        await _logger!.LogAsync(logEntry);

        // Assert
        _mockProvider1.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
        _mockProvider2.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
    }

    [TestMethod]
    public async Task LogAsync_ShouldHandleExceptionsFromProviders()
    {
        // Arrange
        var logEntry = new LogEntry(LogLevel.Debug, "Test log");
        _mockProvider1!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
            .ThrowsAsync(new Exception("Provider error"));
        _mockProvider2!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
            .Returns(Task.CompletedTask);

        // Act
        await _logger!.LogAsync(logEntry);

        // Assert
        _mockProvider1.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
        _mockProvider2.Verify(p => p.WriteAsync(logEntry, null), Times.Once);
    }

    [TestMethod]
    public async Task LogAsync_ShouldInvokeCallbackAfterCompletion()
    {
        // Arrange
        var logEntry = new LogEntry(LogLevel.Debug, "Test log");
        var callbackInvoked = false;
        Action callback = () => callbackInvoked = true;

        _mockProvider1!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
            .Returns(Task.CompletedTask);
        _mockProvider2!.Setup(p => p.WriteAsync(It.IsAny<LogEntry>(), It.IsAny<Action>()))
            .Returns(Task.CompletedTask);

        // Act
        await _logger!.LogAsync(logEntry, callback);

        // Assert
        Assert.IsTrue(callbackInvoked);
    }
}