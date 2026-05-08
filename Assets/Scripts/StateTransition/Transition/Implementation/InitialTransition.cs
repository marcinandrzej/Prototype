using System.Collections.Generic;
using UnityEngine;

public class InitialTransition : ApplicationStateTransitionMonoBase
{
    [Tooltip("Global services to be registered on application start.\n" +
        "Order of registration is determined by order in the array.")]
    [SerializeField] private ServiceControllerBase[] globalServicesArray;

    [SerializeField] private string splashScreenSceneName = "SplashScreenScene";

    protected override List<IApplicationStateTransitionAction> BuildActionList()
    {
        List<IApplicationStateTransitionAction> actions = new List<IApplicationStateTransitionAction>();

        foreach (ServiceControllerBase serviceController in globalServicesArray)
            actions.Add(new ServiceControllerRegisterTransitionAction(serviceController));

        actions.Add(new LoadSceneAsyncTransitionAction(splashScreenSceneName));

        return actions;
    }
}
