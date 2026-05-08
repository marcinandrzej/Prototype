using System.Collections;

public interface ISceneManager : IService
{
    public IEnumerator LoadSceneAsync(string sceneName);

    public IEnumerator UnloadSceneAsync(string sceneName);
    
    public IEnumerator LoadMultipleScenesAsync(string[] sceneNames);
    
    public IEnumerator UnloadMultipleScenesAsync(string[] sceneNames);
}
