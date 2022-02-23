using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Straight : MonoBehaviour
{
    private Rigidbody2D rb =null;
    private BulletState bulletState=null;
    void OnEnable()
    {
        rb =GetComponent<Rigidbody2D>();
        bulletState=GetComponent<BulletState>();
        rb.velocity= transform.up * bulletState.Speed;
    }
}
