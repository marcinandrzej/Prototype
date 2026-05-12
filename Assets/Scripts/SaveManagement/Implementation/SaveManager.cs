using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour, ISaveManagerGeneric<HeaderData, GameData>
{
    private const int SaveVersion = 1;

    [SerializeField] private string saveFolderName = "Saves";
    [SerializeField] private string headerDataFolderName = "HeaderData";
    [SerializeField] private string gameDataFolderName = "GameData";

    private List<HeaderData> _headerDataList = new List<HeaderData>();

    public List<HeaderData> HeaderDataList => _headerDataList;

    private string HeaderDataFolderPath => Path.Combine(Application.persistentDataPath, saveFolderName, headerDataFolderName);

    private string GameDataFolderPath => Path.Combine(Application.persistentDataPath, saveFolderName, gameDataFolderName);

    public void FillHeaderDataList()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        _headerDataList = serializer.DeserializeDataFromDirectory<HeaderData>(HeaderDataFolderPath);
    }

    public async Awaitable FillHeaderDataListAsync()
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        _headerDataList = await serializer.DeserializeDataFromDirectoryAsync<HeaderData>(HeaderDataFolderPath);
    }

    public GameData LoadGameData(HeaderData headerData)
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        GameData data = serializer.DeserializeDataFromFile<GameData>(GameDataFolderPath, headerData.saveName);
        
        return data;
    }

    public async Awaitable<GameData> LoadGameDataAsync(HeaderData headerData)
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        GameData data = await serializer.DeserializeDataFromFileAsync<GameData>(GameDataFolderPath, headerData.saveName);

        return data;
    }

    public HeaderData SaveGameData(GameData gameData, string saveName)
    {
        HeaderData header = new HeaderData();
        header.saveName = saveName;
        header.saveDate = DateTime.Now;
        header.saveVersion = SaveVersion;

        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();

        serializer.SerializeDataToFile<HeaderData>(HeaderDataFolderPath, saveName, header);
        serializer.SerializeDataToFile<GameData>(GameDataFolderPath, saveName, gameData);

        return header;
    }

    public async Awaitable<HeaderData> SaveGameDataAsync(GameData gameData, string saveName)
    {
        HeaderData header = new HeaderData();
        header.saveName = saveName;
        header.saveDate = DateTime.Now;
        header.saveVersion = SaveVersion;

        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();

        await serializer.SerializeDataToFileAsync<HeaderData>(HeaderDataFolderPath, saveName, header);

        await serializer.SerializeDataToFileAsync<GameData>(GameDataFolderPath, saveName, gameData);

        return header;
    }

    public void DeleteSave(HeaderData header)
    {
        ISerializer serializer = ServiceManager.Instance.Get<ISerializer>();
        serializer.DeleteFile(HeaderDataFolderPath, header.saveName);
        serializer.DeleteFile(GameDataFolderPath, header.saveName);
    }
}
