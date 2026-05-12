using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SerializerJSON : MonoBehaviour, ISerializer
{
    private const string FileExtension = ".json";
    private const string FilePattern = "*.json";

    public bool FileExists(string folderPath, string fileName) 
    {
        string path = CombineFilePath(folderPath, fileName);
        bool exists = File.Exists(path);

        return exists;
    }

    public void DeleteFile(string folderPath, string fileName) 
    {
        string path = CombineFilePath(folderPath, fileName);

        if (File.Exists(path))
            File.Delete(path);
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
        string json = await File.ReadAllTextAsync(path);

        await Awaitable.MainThreadAsync();

        DataT data = JsonUtility.FromJson<DataT>(json);

        return data;
    }

    public void SerializeDataToFile<DataT>(string folderPath, string fileName, DataT data)
    {
        string path = CombineFilePath(folderPath, fileName);
        string toJson = JsonUtility.ToJson(data);
        
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        File.WriteAllText(path, toJson);
    }

    public async Awaitable SerializeDataToFileAsync<DataT>(string folderPath, string fileName, DataT data)
    {
        string path = CombineFilePath(folderPath, fileName);
        string toJson = JsonUtility.ToJson(data);
        
        if(!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        await File.WriteAllTextAsync(path, toJson);

        await Awaitable.MainThreadAsync();
    }

    public List<DataT> DeserializeDataFromDirectory<DataT>(string folderPath)
    {
        List<DataT> dataList = new List<DataT>();

        if (Directory.Exists(folderPath))
        {
            IEnumerable<string> files = Directory.EnumerateFiles(folderPath, FilePattern);

            foreach (string file in files)
            {
                string json = File.ReadAllText(file);
                DataT data = JsonUtility.FromJson<DataT>(json);

                dataList.Add(data);
            }
        }

        return dataList;
    }

    public async Awaitable<List<DataT>> DeserializeDataFromDirectoryAsync<DataT>(string folderPath)
    {
        List<DataT> dataList = new List<DataT>();

        if (Directory.Exists(folderPath))
        {
            IEnumerable<string> files = Directory.GetFiles(folderPath, FilePattern);

            foreach (string file in files)
            {
                string json = await File.ReadAllTextAsync(file);

                await Awaitable.MainThreadAsync();

                DataT data = JsonUtility.FromJson<DataT>(json);
                dataList.Add(data);
            }
        }

        return dataList;
    }

    private string CombineFilePath(string folderPath, string fileName)
    {
        string fileNameWithExtension = String.Concat(fileName, FileExtension);
        string fullPath = Path.Combine(folderPath, fileNameWithExtension);
        
        return fullPath;
    }
}
