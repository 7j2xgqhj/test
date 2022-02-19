using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_limit : MonoBehaviour
{
    
    public float collision_limit_=0; 
    float collision_count=0;
    void OnCollisionEnter2D(Collision2D collision){
        if (collision_limit_<=collision_count++){
            Destroy(this.gameObject);
        }
    }
}
