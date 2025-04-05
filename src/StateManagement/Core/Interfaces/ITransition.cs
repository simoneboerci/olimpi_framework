using System;
using System.Collections;
using System.Collections.Generic;

namespace StateManagement.Core.Interfaces;

public interface ITransition<TContext> where TContext : IStateContext
{
    IState<TContext> SourceState { get; }
    IState<TContext> TargetState { get; }

    IDictionary<string, Func<TContext, bool>> Conditions {get; }

    bool ShouldTransition(TContext context);
}