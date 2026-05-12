using UnityEngine;
using System.Collections;

public class LoadSettingsTransitionActionGeneric<SettingsDataT> : IApplicationStateTransitionAction
{
    public IEnumerator Execute()
    {
        ISettingsManagerGeneric<SettingsDataT> settingsManager = ServiceManager.Instance.Get<ISettingsManagerGeneric<SettingsDataT>>();
        Awaitable<EFileOperationResult> loadSettingsAsync = settingsManager.LoadSettingsAsync();

        yield return loadSettingsAsync;

        EFileOperationResult result = loadSettingsAsync.GetAwaiter().GetResult();

        if (result == EFileOperationResult.FileNotExists)
        {
            settingsManager.SetDefaultSettings();

            yield return settingsManager.SaveSettingsAsync();
        }
    }
}
