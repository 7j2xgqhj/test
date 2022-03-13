using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArrayCircle : MonoBehaviour
{
    public GameObject MasicArray;
    [Header("魔法陣の数")]public float MasicArrayNum=3f;
    [Header("回転速度")]public float SpinSpeed=3f;
    [Header("半径")]public float Radius=3f;
    [Header("砲の角度係数")]public float FortAngle=0f;
    void Start()
    {
        for(float i =0;i<MasicArrayNum;i++){
            Instantiate (MasicArray, 
            transform.position+new Vector3(Radius*Mathf.Cos((2*Mathf.PI/MasicArrayNum)*i),Radius*Mathf.Sin((2*Mathf.PI/MasicArrayNum)*i),0),
            transform.rotation*Quaternion.Euler(0,0,FortAngle*i-90),
            gameObject.transform
            );
        }
    }
    void Update()
    {
        transform.rotation=transform.rotation*Quaternion.Euler(0,0,SpinSpeed);
    }
}
