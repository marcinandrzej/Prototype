using System.Collections;

public interface ISettingsManager : IService
{
    public void LoadSettings();

    public void SaveSettings();

    public IEnumerator LoadSettingsAsync();

    public IEnumerator SaveSettingsAsync();
}
