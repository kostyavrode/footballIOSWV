using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _currenrScore = 0;

    public delegate void OnScoreUpdated(int updatedScore);
    public static event OnScoreUpdated onScoreUpdated;


    private void OnEnable()
    {
        GameManager.shared.onKickCompleted += AddScore;
    }


    private void OnDestroy()
    {
        GameManager.shared.onKickCompleted -= AddScore;
    }

    public void AddScore(int score, int kickNumber)
    {
        _currenrScore = score + _currenrScore;
        onScoreUpdated?.Invoke(_currenrScore);
       // Debug.Log("U>> Current SCore " + _currenrScore);
       // GameManager.shared.GetGameInstances().uiManager.UpdateScore(_currenrScore);
       
    }

    public int GetScore()
    {
        return _currenrScore;
    }

    public void ResetScore()
    {
        _currenrScore = 0;
    }


    public void ResetAll()
    {
        _currenrScore = 0;
    }
}
