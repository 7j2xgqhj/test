using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_flag : MonoBehaviour
{
    GameObject gameoverobj=null;
    void Start()
    {
        gameoverobj =transform.Find("collision_marker").gameObject;
    }
    void Update()
    {
        if (Input.GetKey (KeyCode.LeftShift)){
            gameoverobj.SetActive(true);
        } else if(!Input.GetKey (KeyCode.LeftShift)){
            gameoverobj.SetActive(false);
        }
    }
}
