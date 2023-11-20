using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject ballSpwanerParent;
    [SerializeField] private GameObject ballPrefab;

    [SerializeField] private List<GameObject> targetSetList = new List<GameObject>();

    private int _maxKick = 5; // Kick number of a single Level
    private int _currentKickNumber = 0; 
    private bool _isGameOver = false;


    private void OnEnable()
    {
        GameManager.shared.onKickCompleted += OnKickCompleted;
    }
  

    private void OnDestroy()
    {
        GameManager.shared.onKickCompleted -= OnKickCompleted;
    }

    public int GetCurrentKickNumber()
    {
        return _currentKickNumber;
    }

    // Setting Up A Game 
    public void PrepareGame(int kickNumber)
    {
        ResetLevel();
        _maxKick = kickNumber;
        PrepareForKick();

        SetTargets();
    }

    private void PrepareForKick()
    {
        SpawnBall();
        
    }

  
    private void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab);
        ball.transform.parent = ballSpwanerParent.transform;
    }

    private void DestroyAllBalls()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < balls.Length; i++)
        {
            if (balls[i] != null)
            {
                Destroy(balls[i]);
            }
        }
    }

    private void SetTargets()
    {
        int index = Random.Range(0, targetSetList.Count);
        targetSetList[index].SetActive(true);
      
    }

    public void ResetLevel()
    {
        DestroyAllBalls();
        _currentKickNumber = 0;
        _isGameOver = false;

        for (int i = 0; i < targetSetList.Count; i++)
        {
            targetSetList[i].SetActive(false);
        }
    }

    public void OnKickCompleted(int score, int currentKickNumber)
    {
        _currentKickNumber += 1;

        if (_currentKickNumber >= _maxKick)
        {
            _isGameOver = true;
            GameManager.shared.GameOver();
            //Debug.Log("Game Over ...");
        }
        else
        {
            PrepareForKick();
        }

    }
}
