using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour,IScore,IReacatble
{
    [SerializeField] private int _point = 1;
   

    public int GetPoint()
    {
        return _point;
    }

    public void ReactOnCollide()
    {
        GameManager.shared.GetGameInstances().soundManager.PlayCelebrationSound();
        GameObject particleObj = Instantiate(GameManager.shared.GetGameInstances().particle_goalText);
        particleObj.transform.position = new Vector3(0, 5, 0);
        Destroy(particleObj, 3.0f);
    }

    public void SetPoint(int point)
    {
        _point = point;
    }
}

public interface IScore
{
    void SetPoint(int point);
    int GetPoint();
}

