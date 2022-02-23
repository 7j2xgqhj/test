using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    [Header("HP")]public float Hp=100;
    public bool isAlive{get;set;}=true;
    public GameObject ExitEffectObject=null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletState bulletState=collision.gameObject.GetComponent<BulletState>();
        if(bulletState!=null){
            Hp-=bulletState.Damage;
            collision.gameObject.SetActive(false);
        }
        if(Hp<0&&isAlive){
            isAlive=false;
            if(ExitEffectObject!=null){
                Instantiate(ExitEffectObject,transform.position, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }
}
