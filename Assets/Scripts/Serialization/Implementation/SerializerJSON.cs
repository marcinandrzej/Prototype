using System;
using System.IO;
using UnityEngine;

public class SerializerJSON : MonoBehaviour, ISerializer
{
    private const string FileExtension = ".json";

    public bool FileExists(string folderPath, string fileName) 
    {
        string path = CombineFilePath(folderPath, fileName);
        bool exists = File.Exists(path);

        return exists;
    }

    public DataT DeserializeDataFromFile<DataT>(string folderPath, string fileName)
    {
        string path = CombineFilePath(folderPath, fileName);
        string json = File.ReadAllText(path);
        DataT data = JsonUtility.FromJson<DataT>(json);

        return data;
    }

    public async Awaitable<DataT> DeserializeDataFromFileAsync<DataT>(string folderPath, string fileName)
    {
        string path = CombineFilePath(folderPath, fileName);

        await Awaitable.BackgroundThreadAsync();

        string json = await File.ReadAllTextAsync(path);

        await Awaitable.MainThreadAsync();

        DataT data = JsonUtility.FromJson<DataT>(json);

        return data;
    }

    public void SerializeDataToFile<DataT>(string folderPath, string fileName, DataT data)
    {
        string path = CombineFilePath(folderPath, fileName);
        string toJson = JsonUtility.ToJson(data);
        File.WriteAllText(path, toJson);
    }

    public async Awaitable SerializeDataToFileAsync<DataT>(string folderPath, string fileName, DataT data)
    {
        string path = CombineFilePath(folderPath, fileName);
        string toJson = JsonUtility.ToJson(data);

        await Awaitable.BackgroundThreadAsync();

        await File.WriteAllTextAsync(path, toJson);

        await Awaitable.MainThreadAsync();
    }

    private string CombineFilePath(string folderPath, string fileName)
    {
        string fileNameWithExtension = String.Concat(fileName, FileExtension);
        string fullPath = Path.Combine(folderPath, fileNameWithExtension);
        
        return fullPath;
    }
}
