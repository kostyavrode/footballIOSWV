using SaveSystem;

public static class SaveDataHandler
{

    public static void SaveData(object data, string filePath)
    {
        string jsonString = JsonHandler.CreateJson(data);
        FileHandler.WriteInFile(filePath, jsonString);
    }

    // Get stored data, if not found stored data then return default Data 
    public static T GetData<T>(string filePath,T defaultData)
    {
        T data = defaultData;
        if (FileHandler.IsFileExist(filePath) == true)
        {
            string content = FileHandler.ReadText(filePath);
            data = JsonHandler.DeserializeJson<T>(content);
            if (data == null) // No data Stored 
                return defaultData;
        }
        return data;
    }
}
