using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataModel 
{
    public int minTargetValue_moveable = 3;
    public int maxTargetValue_moveable = 10;

    public int targetValue_notMoveable = 2;

    public string tutorialText = "Swipe the ball towards the goalpost and targets";
}


public interface IDataFetcher
{
    int GetMinTargetValue_moveable();
    int GetMaxTargetValue_moveable();
    int GetTargetValue_notMoveable();

    string GetTutorial();
}
