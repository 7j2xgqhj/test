using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_wall : MonoBehaviour
{
    public stage stage;
private void OnTriggerStay2D(Collider2D collision){
        wall_option wall_option=collision.gameObject.GetComponent<wall_option>();
        if(wall_option!=null&&collision.gameObject.transform.position.x>transform.position.x){
            if(wall_option.roop){
                collision.gameObject.transform.position=new Vector3(
                    stage.left_wall.transform.position.x,
                    collision.gameObject.transform.position.y,
                    collision.gameObject.transform.position.z);
            }else if((wall_option.limitedreflect&&wall_option.reflect_limit>0)||wall_option.unlimitreflect){
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity=new Vector2(-rb.velocity.x,rb.velocity.y);
                if(wall_option.reflect_limit>0){
                    wall_option.reflect_limit--;
                }
            }else if(wall_option.stop)
            {
                collision.gameObject.transform.position=new Vector3(
                    transform.position.x,
                    collision.gameObject.transform.position.y,
                    collision.gameObject.transform.position.z);
            }
            else{
                collision.gameObject.SetActive(false);
            }
        }
    }
}
