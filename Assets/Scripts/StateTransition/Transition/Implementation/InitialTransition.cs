using System.Collections.Generic;
using UnityEngine;

public class InitialTransition : ApplicationStateTransitionMonoBase
{
    [Tooltip("Reference to IApplicationStateManager")]
    [SerializeField] private Object applicationStateManagerObject = null;

    //TO DO Register all global services (Scene, Settings, Save, Audio, Input managers)

    private void OnValidate()
    {
        if (applicationStateManagerObject != null && !(applicationStateManagerObject is IApplicationStateManager))
            applicationStateManagerObject = null;
    }

    protected override List<IApplicationStateTransitionAction> BuildActionList()
    {
        List<IApplicationStateTransitionAction> actions = new List<IApplicationStateTransitionAction>();

        actions.Add(new RegisterServiceTransitionActionT<IApplicationStateManager>(applicationStateManagerObject as IApplicationStateManager));

        return actions;
    }
}
