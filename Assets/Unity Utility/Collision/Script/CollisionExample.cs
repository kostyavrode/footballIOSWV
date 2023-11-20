using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour, ICollisionEnter
{
    public void onCollisionEnter(GameObject collidedObj2D)
    {
        Debug.Log("Collision Enter - " + collidedObj2D.name);
    }
}
