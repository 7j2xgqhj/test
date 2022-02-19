using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_judgment : MonoBehaviour
{
    public float hp=100;
    public bool alive{get;set;}=true;
    public GameObject effect=null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet b=collision.gameObject.GetComponent<bullet>();
        if(b!=null){
            hp-=b.damage;
        }
        if(hp<0&&alive==true){
            alive=false;
            if(effect!=null){
                Instantiate(effect,transform.position, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("player_bullet")||collision.gameObject.CompareTag("enemy_bullet")){
            collision.gameObject.SetActive(false);
        }
    }
}
