using StateManagement.Core.Interfaces;

namespace StateManagement.Core;

public abstract class BaseState<TContext> : IState<TContext> where TContext : IStateContext
{
    public virtual void OnEnter() { }

    public virtual void OnExit(){}

    public virtual void OnFixedUpdate(){}

    public virtual void OnUpdate(){}
}