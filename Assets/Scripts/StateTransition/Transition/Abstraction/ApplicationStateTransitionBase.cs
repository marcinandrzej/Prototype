using System.Collections;
using System.Collections.Generic;

public abstract class ApplicationStateTransitionBase : IApplicationStateTransition
{
    protected List<IApplicationStateTransitionAction> _actions;

    protected ApplicationStateTransitionBase() => _actions = new List<IApplicationStateTransitionAction>();

    public IEnumerator Execute()
    {
        foreach (IApplicationStateTransitionAction action in _actions)
            yield return action.Execute();
    }
}