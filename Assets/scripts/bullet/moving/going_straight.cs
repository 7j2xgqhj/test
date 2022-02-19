using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class going_straight : MonoBehaviour
{
    Rigidbody2D rb =null;
    bullet bullet_=null;
    void OnEnable()
    {
        rb =GetComponent<Rigidbody2D>();
        bullet_=GetComponent<bullet>();
        rb.velocity= transform.up * bullet_.speed;
    }
}
