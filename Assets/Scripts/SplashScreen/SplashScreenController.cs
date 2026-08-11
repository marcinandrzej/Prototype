using System.Collections;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    [SerializeField] private string splashScreenSceneName = "SplashScreenScene";
    [SerializeField] private string mainMenuSceneName = "MainMenuScene";

    private IEnumerator Start()
    {
        //Play Enter Animation
        //TO DO
        yield return new WaitForSeconds(5f);

        //Wait for State Transition to End
        IApplicationStateManager applicationStateManager = ServiceManager.Instance.Get<IApplicationStateManager>();

        while (applicationStateManager.IsInTransition)
            yield return null;

        //Wait For Player To Join
        IPlayerManager playerManager = ServiceManager.Instance.Get<IPlayerManager>();
        playerManager.EnablePlayerJoining();
        
        while (playerManager.Players.Count <= 0)
            yield return null;

        playerManager.DisablePlayerJoining();

        //Play Exit Animation
        //TO DO
        yield return new WaitForSeconds(5f);

        //Trigger Main Menu State Transition
        SplashScreenToMainMenuTransition transition = new SplashScreenToMainMenuTransition(splashScreenSceneName, mainMenuSceneName);
        applicationStateManager.ExecuteStateTransition(transition);
    }
}
