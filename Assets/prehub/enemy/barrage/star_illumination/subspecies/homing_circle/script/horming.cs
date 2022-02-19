using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horming : MonoBehaviour
{
    private Rigidbody2D rb = null;
    bullet bullet_=null;
    GameObject p=null;
    Transform target=null;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet_=GetComponent<bullet>();
        p = GameObject.FindWithTag("Player");
        if(p!=null) target=p.transform;
    }
    void Update()
    {
        if(target!=null) {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position-transform.position);
        }
        rb.velocity= transform.up * bullet_.speed;
    }
}
