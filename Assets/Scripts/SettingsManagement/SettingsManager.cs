using System.Collections;
using UnityEngine;

public class SettingsManager : MonoBehaviour, ISettingsManager
{
    [SerializeField] private string settingsFileName = "Settings";

    private SettingsData _settingsData;

    public void LoadSettings()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();

        if (!serializer.FileExists(Application.persistentDataPath, settingsFileName))
            _settingsData = new SettingsData();
        else
            _settingsData = serializer.DeserializeDataFromFile<SettingsData>(Application.persistentDataPath, settingsFileName);
    }

    public IEnumerator LoadSettingsAsync()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();

        if (!serializer.FileExists(Application.persistentDataPath, settingsFileName))
        {
            _settingsData = new SettingsData();
        }
        else
        {
            Awaitable<SettingsData> asyncOperation = serializer.DeserializeDataFromFileAsync<SettingsData>(Application.persistentDataPath, settingsFileName);

            yield return asyncOperation;

            _settingsData = asyncOperation.GetAwaiter().GetResult();
        }
    }

    public void SaveSettings()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        serializer.SerializeDataToFile<SettingsData>(Application.persistentDataPath, settingsFileName, _settingsData);
    }

    public IEnumerator SaveSettingsAsync()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        Awaitable asyncOperation = serializer.SerializeDataToFileAsync<SettingsData>(Application.persistentDataPath, settingsFileName, _settingsData);

        yield return asyncOperation;
    }
}
