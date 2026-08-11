public class SplashScreenToMainMenuTransition : ApplicationStateTransitionBase
{
    public SplashScreenToMainMenuTransition(string splashScreenSceneName, string mainMenuSceneName) : base()
    {
        //Unload SplashScreen
        _actions.Add(new UnloadSceneAsyncTransitionAction(splashScreenSceneName));
        
        //Load MainMenu
        _actions.Add(new LoadSceneAsyncTransitionAction(mainMenuSceneName));
    }
}
