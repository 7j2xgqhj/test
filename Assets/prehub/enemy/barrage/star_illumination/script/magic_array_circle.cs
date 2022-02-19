using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_array_circle : MonoBehaviour
{
    public GameObject masic_array;
    public float masic_array_num=3f;
    public float spin_speed=3f;
    public float radius=3f;
    public float fort_angle=0f;
    void Start()
    {
        for(float i =0;i<masic_array_num;i++){
            Instantiate (masic_array, 
            transform.position+new Vector3(radius*Mathf.Cos((2*Mathf.PI/masic_array_num)*i),radius*Mathf.Sin((2*Mathf.PI/masic_array_num)*i),0),
            transform.rotation*Quaternion.Euler(0,0,fort_angle*i+180),
            gameObject.transform
            );
        }
    }
    void Update()
    {
        transform.rotation=transform.rotation*Quaternion.Euler(0,0,spin_speed);
    }
}
