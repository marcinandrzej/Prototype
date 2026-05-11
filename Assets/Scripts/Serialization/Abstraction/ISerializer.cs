using UnityEngine;

public interface ISerializer : IService
{
    public bool FileExists(string folderPath, string fileName);

    public void SerializeDataToFile<DataT>(string folderPath, string fileName, DataT data);

    public DataT DeserializeDataFromFile<DataT>(string folderPath, string fileName);

    public Awaitable SerializeDataToFileAsync<DataT>(string folderPath, string fileName, DataT data);

    public Awaitable<DataT> DeserializeDataFromFileAsync<DataT>(string folderPath, string fileName);
}
