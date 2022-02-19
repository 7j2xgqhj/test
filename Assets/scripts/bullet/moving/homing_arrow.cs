using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_arrow : MonoBehaviour
{
    private Rigidbody2D rb = null;
    bullet bullet_=null;
    GameObject p=null;
    Transform target=null; 
    public float wait_time1=1f;
    public float wait_time2=0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet_=GetComponent<bullet>();
        p = GameObject.FindWithTag("Player");
        if(p!=null) target=p.transform;
        StartCoroutine("action1");
    }

    private IEnumerator action1(){
        rb.angularVelocity=1500f;
        yield return new WaitForSeconds(wait_time1);
        if(target!=null) transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position-transform.position);
        rb.angularVelocity=0;
        yield return new WaitForSeconds(wait_time2);
        rb.velocity= transform.up * bullet_.speed;
    }

}
