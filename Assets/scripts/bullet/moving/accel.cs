using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accel : MonoBehaviour
{
    public float change_time=1f;
    [Header("加速の倍率")]public float speed_magnification=2f;
    Rigidbody2D rb =null;
    bullet bullet_=null;
    void OnEnable()
    {
        rb =GetComponent<Rigidbody2D>();
        bullet_=GetComponent<bullet>();
        rb.velocity= transform.up * bullet_.speed;
        StartCoroutine("action1");
    }
    private IEnumerator action1(){
        yield return new WaitForSeconds(change_time);
        rb.velocity= transform.up * bullet_.speed*speed_magnification;
    }
}
