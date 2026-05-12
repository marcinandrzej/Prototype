using UnityEngine;

public interface ISettingsManagerGeneric<SettingsDataT> : IService
{
    public SettingsDataT Settings { get; }

    public void SetDefaultSettings();

    public EFileOperationResult LoadSettings();

    public EFileOperationResult SaveSettings();

    public Awaitable<EFileOperationResult> LoadSettingsAsync();

    public Awaitable<EFileOperationResult> SaveSettingsAsync();
}
