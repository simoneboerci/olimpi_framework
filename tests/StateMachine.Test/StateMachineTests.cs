using Moq;
using StateManagement.Core;
using StateManagement.Core.Interfaces;

namespace StateMachine.Test;

[TestClass]
public sealed class StateMachineTests
{
    private Mock<IStateContext>? _mockContext;
    private Mock<IState<IStateContext>>? _mockInitialState;
    private Mock<IState<IStateContext>>? _mockNextState;
    private Mock<ITransitionManager<IStateContext, IState<IStateContext>>>? _mockTransitionManager;

    [TestInitialize]
    public void Setup()
    {
        _mockContext = new Mock<IStateContext>();
        _mockInitialState = new Mock<IState<IStateContext>>();
        _mockNextState = new Mock<IState<IStateContext>>();
        _mockTransitionManager = new Mock<ITransitionManager<IStateContext, IState<IStateContext>>>();
    }

    [TestMethod]
    public void StateMachine_InitializesWithCorrectState()
    {
        // Arrange
        var stateMachine = new StateMachine<IStateContext, IState<IStateContext>>(
            _mockContext!.Object,
            _mockInitialState!.Object,
            _mockTransitionManager!.Object);

        // Assert
        Assert.AreEqual(_mockInitialState.Object, stateMachine.CurrentState);
    }

    [TestMethod]
    public void StateMachine_ChangesStateCorrectly()
    {
        // Arrange
        var stateMachine = new StateMachine<IStateContext, IState<IStateContext>>(
            _mockContext!.Object,
            _mockInitialState!.Object,
            _mockTransitionManager!.Object);

        // Act
        stateMachine.ChangeState(_mockNextState!.Object);

        // Assert
        Assert.AreEqual(_mockNextState.Object, stateMachine.CurrentState);
        Assert.AreEqual(_mockInitialState.Object, stateMachine.PreviousState);
    }

    [TestMethod]
    public void StateMachine_ChecksTransitionsAndChangesState()
    {
        // Arrange
        var mockTransition = new Mock<ITransition<IStateContext>>();
        mockTransition.Setup(t => t.SourceState).Returns(_mockInitialState!.Object);
        mockTransition.Setup(t => t.TargetState).Returns(_mockNextState!.Object);
        mockTransition.Setup(t => t.ShouldTransition(It.IsAny<IStateContext>())).Returns(true);

        _mockTransitionManager!
            .Setup(tm => tm.GetValidTransition(_mockInitialState.Object, _mockContext!.Object))
            .Returns(mockTransition.Object);

        var stateMachine = new StateMachine<IStateContext, IState<IStateContext>>(
            _mockContext!.Object,
            _mockInitialState.Object,
            _mockTransitionManager.Object);

        // Act
        stateMachine.Update();

        // Assert
        Assert.AreEqual(_mockNextState.Object, stateMachine.CurrentState);
        Assert.AreEqual(mockTransition.Object, stateMachine.LastTransition);
    }
}