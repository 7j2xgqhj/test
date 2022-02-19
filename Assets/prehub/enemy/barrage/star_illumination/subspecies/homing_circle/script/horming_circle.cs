using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horming_circle : MonoBehaviour
{
    public GameObject effectlike=null;
    public GameObject bulletPrefab;
    GameObject bullet;
    GameObject effect=null;
    void OnEnable()
    {
        bullet=Instantiate (bulletPrefab, transform.position, transform.rotation);
        if(effectlike!=null){
            effect = Instantiate (effectlike, bullet.transform.position, bullet.transform.rotation,bullet.transform);
        }
    }
    void OnDisable(){
        Destroy(bullet);
    }
}
