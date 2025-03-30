namespace StateManagement.Core.Interfaces;

public interface IState<TContext>
{
    void OnEnter();
    void OnFixedUpdate();
    void OnUpdate();
    void OnExit();
}
