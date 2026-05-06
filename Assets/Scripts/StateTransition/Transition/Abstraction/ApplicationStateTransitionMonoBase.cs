using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ApplicationStateTransitionMonoBase : MonoBehaviour, IApplicationStateTransition
{
    private List<IApplicationStateTransitionAction> _actions;

    private void Awake() => _actions = BuildActionList();

    public IEnumerator Execute()
    {
        foreach (IApplicationStateTransitionAction action in _actions)
            yield return action.Execute();
    }

    protected abstract List<IApplicationStateTransitionAction> BuildActionList();
}
