using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingArrow : MonoBehaviour
{
    [Header("動作付き待機時間")]public float WaitTimeFirst=1f;
    [Header("停止付き待機時間")]public float WaitTimeSecond=0.5f;
    private Rigidbody2D rb = null;
    private BulletState bulletState=null;
    private GameObject playerObject=null;
    private Transform target=null; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletState=GetComponent<BulletState>();
        playerObject = GameObject.FindWithTag("Player");
        if(playerObject!=null) target=playerObject.transform;
        StartCoroutine("delayAction");
    }

    private IEnumerator delayAction(){
        rb.angularVelocity=1500f;
        yield return new WaitForSeconds(WaitTimeFirst);
        if(target!=null) transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position-transform.position);
        rb.angularVelocity=0;
        yield return new WaitForSeconds(WaitTimeSecond);
        rb.velocity= transform.up * bulletState.Speed;
    }

}
