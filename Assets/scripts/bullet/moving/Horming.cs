using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horming : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private BulletState bulletState=null;
    private GameObject playerObject=null;
    private Transform target=null;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletState=GetComponent<BulletState>();
        playerObject = GameObject.FindWithTag("Player");
        if(playerObject!=null) target=playerObject.transform;
    }
    void Update()
    {
        if(target!=null) {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position-transform.position);
        }
        rb.velocity= transform.up * bulletState.Speed;
    }
}
