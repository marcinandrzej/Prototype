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

        //Register global services
        foreach (ServiceControllerBase serviceController in globalServicesArray)
            actions.Add(new ServiceControllerRegisterTransitionAction(serviceController));

        //TO DO Load and apply settings

        //Block input
        actions.Add(new ChangeInputContextTransitionAction(EInputContext.Inactive));
        
        //Load splash screen scene
        actions.Add(new LoadSceneAsyncTransitionAction(splashScreenSceneName));

        //TO DO Load save files headers (save split between metadata - "header" (light data to be used in load menu like ID, SaveTime, ScreenShot itp.) and gamedata - "save") async while splash screen is visible

        //Unlock input
        actions.Add(new ChangeInputContextTransitionAction(EInputContext.SplashScreen));

        return actions;
    }
}
