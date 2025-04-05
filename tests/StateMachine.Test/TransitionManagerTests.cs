using Moq;
using StateManagement.Core;
using StateManagement.Core.Interfaces;

namespace StateMachine.Test;

[TestClass]
public sealed class TransitionManagerTests
{
    private Mock<IState<IStateContext>>? _mockState1;
    private Mock<IState<IStateContext>>? _mockState2;
    private Mock<IStateContext>? _mockContext;

    [TestInitialize]
    public void Setup()
    {
        _mockState1 = new Mock<IState<IStateContext>>();
        _mockState2 = new Mock<IState<IStateContext>>();
        _mockContext = new Mock<IStateContext>();
    }

    [TestMethod]
    public void TransitionManager_AddsAndRemovesTransitions()
    {
        // Arrange
        var transitionManager = new TransitionManager<IStateContext, IState<IStateContext>>();
        var mockTransition = new Mock<ITransition<IStateContext>>();

        // Act
        transitionManager.AddTransition(mockTransition.Object);
        Assert.AreEqual(1, transitionManager.Transitions.Count);

        transitionManager.RemoveTransition(mockTransition.Object);
        Assert.AreEqual(0, transitionManager.Transitions.Count);
    }

    [TestMethod]
    public void TransitionManager_ReturnsValidTransition()
    {
        // Arrange
        var transitionManager = new TransitionManager<IStateContext, IState<IStateContext>>();
        var mockTransition = new Mock<ITransition<IStateContext>>();
        mockTransition.Setup(t => t.SourceState).Returns(_mockState1!.Object);
        mockTransition.Setup(t => t.TargetState).Returns(_mockState2!.Object);
        mockTransition.Setup(t => t.ShouldTransition(It.IsAny<IStateContext>())).Returns(true);

        transitionManager.AddTransition(mockTransition.Object);

        // Act
        var validTransition = transitionManager.GetValidTransition(_mockState1.Object, _mockContext!.Object);

        // Assert
        Assert.IsNotNull(validTransition);
        Assert.AreEqual(mockTransition.Object, validTransition);
    }

    [TestMethod]
    public void TransitionManager_ReturnsNullIfNoValidTransition()
    {
        // Arrange
        var transitionManager = new TransitionManager<IStateContext, IState<IStateContext>>();
        var mockTransition = new Mock<ITransition<IStateContext>>();
        mockTransition.Setup(t => t.SourceState).Returns(_mockState1!.Object);
        mockTransition.Setup(t => t.ShouldTransition(It.IsAny<IStateContext>())).Returns(false);

        transitionManager.AddTransition(mockTransition.Object);

        // Act
        var validTransition = transitionManager.GetValidTransition(_mockState1.Object, _mockContext!.Object);

        // Assert
        Assert.IsNull(validTransition);
    }
}