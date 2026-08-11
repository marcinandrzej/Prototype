using System.Collections;
using UnityEngine;
using LoadSceneMode = UnityEngine.SceneManagement.LoadSceneMode;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour, ISceneManager
{
    public IEnumerator LoadSceneAsync(string sceneName) 
    {
        AsyncOperation loadingOperation = UnitySceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        yield return new WaitUntil(() => loadingOperation == null || loadingOperation.progress >= 1);
    }

    public IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation loadingOperation = UnitySceneManager.UnloadSceneAsync(sceneName);

        yield return new WaitUntil(() => loadingOperation == null || loadingOperation.progress >= 1);
    }

    public IEnumerator LoadMultipleScenesAsync(string[] sceneNames) 
    {
        foreach (string sceneName in sceneNames)
            yield return LoadSceneAsync(sceneName);
    }

    public IEnumerator UnloadMultipleScenesAsync(string[] sceneNames)
    {
        foreach (string sceneName in sceneNames)
            yield return UnloadSceneAsync(sceneName);
    }
}