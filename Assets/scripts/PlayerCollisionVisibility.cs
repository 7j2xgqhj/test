using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionVisibility : MonoBehaviour
{
    public GameObject CollisionMarker=null;
    void Update()
    {
        if (Input.GetKey (KeyCode.LeftShift)){
            CollisionMarker.SetActive(true);
        } else if(!Input.GetKey (KeyCode.LeftShift)){
            CollisionMarker.SetActive(false);
        }
    }
}
