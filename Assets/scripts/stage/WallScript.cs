using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public enum WallPosition{
        TOP,
        LEFT,
        RIGHT,
        BOTTOM
    }
    public WallObjects wallObjects;
    [Header("位置")]public WallPosition wallPosition;
    void Start(){
    }
    private void OnTriggerStay2D(Collider2D collision){
        WallOption wallOption=collision.gameObject.GetComponent<WallOption>();
        bool isDecision=false;
        switch(wallPosition){
            case WallPosition.TOP:
                if(collision.gameObject.transform.position.y>transform.position.y)
                    isDecision=true;
                break;
            case WallPosition.RIGHT:
                if(collision.gameObject.transform.position.x>transform.position.x)
                    isDecision=true;
                break;
            case WallPosition.LEFT:
                if(collision.gameObject.transform.position.x<transform.position.x)
                    isDecision=true;
                break;
            case WallPosition.BOTTOM:
                if(collision.gameObject.transform.position.y<transform.position.y)
                    isDecision=true;
                break;
        }
        if(wallOption!=null&&isDecision){
            if(wallOption.isRoop){
                switch(wallPosition){
                    case WallPosition.TOP:
                        collision.gameObject.transform.position=new Vector3(
                            collision.gameObject.transform.position.x,
                            wallObjects.BottomWallPosition.transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                    case WallPosition.RIGHT:
                        collision.gameObject.transform.position=new Vector3(
                            wallObjects.LeftWallPosition.transform.position.x,
                            collision.gameObject.transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                    case WallPosition.LEFT:
                        collision.gameObject.transform.position=new Vector3(
                            wallObjects.RightWallPosition.transform.position.x,
                            collision.gameObject.transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                    case WallPosition.BOTTOM:
                        collision.gameObject.transform.position=new Vector3(
                            collision.gameObject.transform.position.x,
                            wallObjects.TopWallPosition.transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                }
            }else if((wallOption.isLimitedReflect&&wallOption.ReflectLimit>0)||wallOption.isUnlimitReflect){
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                switch(wallPosition){
                    case WallPosition.TOP:
                        rb.velocity=new Vector2(rb.velocity.x,-rb.velocity.y);
                        break;
                    case WallPosition.BOTTOM:
                        rb.velocity=new Vector2(rb.velocity.x,-rb.velocity.y);
                        break;
                    case WallPosition.RIGHT:
                        rb.velocity=new Vector2(-rb.velocity.x,rb.velocity.y);
                        break;
                    case WallPosition.LEFT:
                        rb.velocity=new Vector2(-rb.velocity.x,rb.velocity.y);
                        break;
                }
                if(wallOption.ReflectLimit>0){
                    wallOption.ReflectLimit--;
                }
            }else if(wallOption.isStop)
            {
                switch(wallPosition){
                    case WallPosition.TOP:
                        collision.gameObject.transform.position=new Vector3(
                            collision.gameObject.transform.position.x,
                            transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                    case WallPosition.BOTTOM:
                        collision.gameObject.transform.position=new Vector3(
                            collision.gameObject.transform.position.x,
                            transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                    case WallPosition.RIGHT:
                        collision.gameObject.transform.position=new Vector3(
                            transform.position.x,
                            collision.gameObject.transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                    case WallPosition.LEFT:
                        collision.gameObject.transform.position=new Vector3(
                            transform.position.x,
                            collision.gameObject.transform.position.y,
                            collision.gameObject.transform.position.z
                        );
                        break;
                }
            }
            else{
                collision.gameObject.SetActive(false);
            }
        }
    }
}
