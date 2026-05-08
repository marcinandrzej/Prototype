using System.Collections;

public class UnloadSceneAsyncTransitionAction : IApplicationStateTransitionAction
{
    private string _sceneName;

    public UnloadSceneAsyncTransitionAction(string sceneName)
    {
        _sceneName = sceneName;
    }

    public IEnumerator Execute()
    {
        ISceneManager sceneManager = ServiceManager.Instance.Get<ISceneManager>();

        yield return sceneManager.UnloadSceneAsync(_sceneName);
    }
}
