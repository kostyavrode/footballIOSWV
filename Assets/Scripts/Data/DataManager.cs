using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    IDataFetcher _dataFetcher;

    public DataManager(IDataFetcher dataFetcher)
    {
        this._dataFetcher = dataFetcher;
    }

    public int GetMinTargetValue_moveable()
    {
        return _dataFetcher.GetMinTargetValue_moveable();
    }

    public int GetMaxTargetValue_moveable()
    {
        return _dataFetcher.GetMaxTargetValue_moveable();
    }

    public int GetTargetValue_notMoveable()
    {
        return _dataFetcher.GetTargetValue_notMoveable();
    }

    public string GetTutorial()
    {
        return _dataFetcher.GetTutorial();
    }

}
