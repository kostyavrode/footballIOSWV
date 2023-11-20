using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTargetGenerator : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        int count = 5;//Random.Range(2, 6);
        float enemyRadius = 4;//enemy.GetComponent<Collider2D>().bounds.extents.x;
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(-20.0f, 0.0f);
            float y = Random.Range(0.0f, 10.0f);
            Vector2 spawnPoint = new Vector2(x, y);
            //Assuming you are 2D
            Collider[] CollisionWithEnemy = Physics.OverlapSphere(spawnPoint, enemyRadius);
            //If the Collision is empty then, we can instantiate
            if (CollisionWithEnemy != null && CollisionWithEnemy.Length > 0)
            {

            }
            else
            {
                Instantiate(enemy, new Vector3(x, y, 25), Quaternion.identity);
            }
               
        }
    }
}
