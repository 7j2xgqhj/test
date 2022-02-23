using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingGears : MonoBehaviour
{
    [Header("変速までの時間")]public float ChangeTime=1f;
    [Header("変速倍率")]public float SpeedMagnification=2f;
    private Rigidbody2D rb =null;
    private BulletState bulletState=null;
    void OnEnable()
    {
        rb =GetComponent<Rigidbody2D>();
        bulletState=GetComponent<BulletState>();
        rb.velocity= transform.up * bulletState.Speed;
        StartCoroutine("delayAction");
    }
    private IEnumerator delayAction(){
        yield return new WaitForSeconds(ChangeTime);
        rb.velocity= transform.up * bulletState.Speed*SpeedMagnification;
    }
}
