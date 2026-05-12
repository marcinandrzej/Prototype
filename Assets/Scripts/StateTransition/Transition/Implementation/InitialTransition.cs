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

        //Load settings file or create new default one
        actions.Add(new LoadSettingsTransitionActionGeneric<SettingsData>());

        //Block input
        actions.Add(new ChangeInputContextTransitionAction(EInputContext.Inactive));
        
        //Load splash screen scene
        actions.Add(new LoadSceneAsyncTransitionAction(splashScreenSceneName));

        //Load save files headers
        actions.Add(new LoadSaveFilesHeadersTransitionActionGeneric<HeaderData, GameData>());

        //Unlock input
        actions.Add(new ChangeInputContextTransitionAction(EInputContext.SplashScreen));

        return actions;
    }
}
