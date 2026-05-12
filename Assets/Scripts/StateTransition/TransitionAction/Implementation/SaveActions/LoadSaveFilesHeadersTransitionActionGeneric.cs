using System.Collections;
using UnityEngine;

public class LoadSaveFilesHeadersTransitionActionGeneric<HeaderDataT, GameDataT> : IApplicationStateTransitionAction where GameDataT : new()
{
    public IEnumerator Execute()
    {
        ISaveManagerGeneric<HeaderDataT,GameDataT> saveManager = ServiceManager.Instance.Get<ISaveManagerGeneric<HeaderDataT, GameDataT>>();
        Awaitable asyncOperation = saveManager.FillHeaderDataListAsync();

        yield return asyncOperation;
    }
}
