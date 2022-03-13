using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCircle : MonoBehaviour
{
    public GameObject ArrowCircleCenterObject;
    private GameObject arrowCircleCenterObject;
    void OnEnable()
    {
        arrowCircleCenterObject=Instantiate(ArrowCircleCenterObject,new Vector3(0,0,0),Quaternion.Euler(0,0,0));
    }
    void OnDisable(){
        Destroy(arrowCircleCenterObject);
    }
}
