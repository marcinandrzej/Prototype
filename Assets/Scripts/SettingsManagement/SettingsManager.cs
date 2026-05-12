using UnityEngine;

public class SettingsManager : MonoBehaviour, ISettingsManagerGeneric<SettingsData>
{
    [SerializeField] private string settingsFileName = "Settings";

    private SettingsData _settingsData;

    public SettingsData Settings => _settingsData;

    public void SetDefaultSettings() => _settingsData = new SettingsData();

    public EFileOperationResult LoadSettings()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();

        if (!serializer.FileExists(Application.persistentDataPath, settingsFileName))
        {
            return EFileOperationResult.FileNotExists;
        }
        else
        {
            _settingsData = serializer.DeserializeDataFromFile<SettingsData>(Application.persistentDataPath, settingsFileName);

            return EFileOperationResult.Success;
        }
    }

    public async Awaitable<EFileOperationResult> LoadSettingsAsync()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();

        if (!serializer.FileExists(Application.persistentDataPath, settingsFileName))
        {
            return EFileOperationResult.FileNotExists;
        }
        else
        {
            _settingsData =  await serializer.DeserializeDataFromFileAsync<SettingsData>(Application.persistentDataPath, settingsFileName);

            return EFileOperationResult.Success;
        }
    }

    public EFileOperationResult SaveSettings()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        serializer.SerializeDataToFile<SettingsData>(Application.persistentDataPath, settingsFileName, _settingsData);

        return EFileOperationResult.Success;
    }

    public async Awaitable<EFileOperationResult> SaveSettingsAsync()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        Awaitable asyncOperation = serializer.SerializeDataToFileAsync<SettingsData>(Application.persistentDataPath, settingsFileName, _settingsData);

        await asyncOperation;

        return EFileOperationResult.Success;
    }
}
