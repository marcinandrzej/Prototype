using System.Collections.Generic;
using UnityEngine;

public interface ISaveManagerGeneric<HeaderDataT, GameDataT> : IService
{
    public List<HeaderDataT> HeaderDataList { get; }

    public void FillHeaderDataList();

    public Awaitable FillHeaderDataListAsync();

    public GameDataT LoadGameData(HeaderDataT headerData);

    public Awaitable<GameDataT> LoadGameDataAsync(HeaderDataT headerData);

    public HeaderDataT SaveGameData(GameDataT gameData, string saveName);

    public Awaitable<HeaderDataT> SaveGameDataAsync(GameDataT gameData, string saveName);

    public void DeleteSave(HeaderDataT header);
}
