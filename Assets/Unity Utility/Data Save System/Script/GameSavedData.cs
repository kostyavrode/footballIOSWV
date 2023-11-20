
using System.IO;
using UnityEngine;

namespace SaveSystem
{
    //All Data Class need to be Serializable for store in Json Format
    //So add [System.Serializable] attribute at the top of each data class


    [System.Serializable]
    public class PlayerAchivedDataModel
    {
        public int maxLevelCompletedByPlayer = 1;
        public int collectedCoinNumber = 0;
    }

    [System.Serializable]
    public class GameAudioSavedData
    {
        public bool isGameAudioOn = true;
    }


    // Helper Classes for File and Json Operations
    #region HelperClass

    public static class JsonHandler
    {
        public static string CreateJson(object data)
        {
            string json = JsonUtility.ToJson(data);
            return json;
        }

        public static T DeserializeJson<T>(string data)
        {
            T myObject = JsonUtility.FromJson<T>(data);
            return myObject;
        }
    }

    public static class FileHandler
    {

        public static bool IsFileExist(string path)
        {
            return File.Exists(path);
        }

        public static void CreateFileInAPath(string path)
        {
            if (IsFileExist(path) == false)
                File.Create(path).Dispose();
        }

        public static string GetPersistantFilePath(string fileName)
        {
            return Application.persistentDataPath + "/" + fileName;
        }

        public static void WriteInFile(string filePath, string content)
        {
            CreateFileInAPath(filePath);
            if (IsFileExist(filePath) == true)
            {
                File.WriteAllText(filePath, content);
            }
        }
        public static string ReadText(string filePath)
        {
            string content = "";

            if (IsFileExist(filePath) == true)
                content = File.ReadAllText(filePath);
            return content;
        }

    }

    #endregion HelperClass
}
