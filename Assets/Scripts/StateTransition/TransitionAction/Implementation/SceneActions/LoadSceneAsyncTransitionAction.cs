using System.Collections;

public class LoadSceneAsyncTransitionAction : IApplicationStateTransitionAction
{
    private string _sceneName;

    public LoadSceneAsyncTransitionAction(string sceneName)
    {
        _sceneName = sceneName;
    }

    public IEnumerator Execute()
    {
        ISceneManager sceneManager = ServiceManager.Instance.Get<ISceneManager>();

        yield return sceneManager.LoadSceneAsync(_sceneName);
    }
}