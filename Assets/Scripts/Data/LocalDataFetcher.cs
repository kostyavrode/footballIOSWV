using System.Collections;
using System.Collections.Generic;
using SaveSystem;
using UnityEngine;

public class LocalDataFetcher : IDataFetcher
{
    private string fileName = "GameData.json";

    public int GetMinTargetValue_moveable()
    {
        return GetStoredData().minTargetValue_moveable;
    }

    public int GetMaxTargetValue_moveable()
    {
        return GetStoredData().maxTargetValue_moveable;
    }

    public int GetTargetValue_notMoveable()
    {
        return GetStoredData().targetValue_notMoveable;
    }

    public string GetTutorial()
    {
        //Debug.Log("File Path " + GetFilePath());
        return GetStoredData().tutorialText;
    }

    private string GetFilePath()
    {
        return FileHandler.GetPersistantFilePath(fileName);
    }

    private void StoreData(GameDataModel data)
    {
        SaveDataHandler.SaveData(data, GetFilePath());
    }

    GameDataModel GetStoredData()
    {
        if (FileHandler.IsFileExist(GetFilePath()) == false)
        {
            GameDataModel data = new GameDataModel();
            StoreData(data);
            return data;
        }

        return SaveDataHandler.GetData<GameDataModel>(GetFilePath(), GetDefaultPlayerAchivedDataModel());
    }

    GameDataModel GetDefaultPlayerAchivedDataModel()
    {
        GameDataModel data = new GameDataModel();
        return data;
    }

    
}
