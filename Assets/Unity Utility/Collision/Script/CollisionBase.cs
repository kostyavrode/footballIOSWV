using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    [Header("Layers want to collided with")]
    public LayerMask layerMask = new LayerMask();

    public bool IsThisLayerCollidable(GameObject collidedObj)
    {
        if ((layerMask.value & 1 << collidedObj.layer) != 0)
            return true;
        return false;
    }
}
