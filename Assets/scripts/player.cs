using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    #region public
    [Header("高速移動時の速度")]public float speed_high = 1;
    [Header("低速移動時の速度")]public float speed_low = 0.5f;
    public Transform target;

    #endregion
    private Rigidbody2D rb = null;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        float xSpeed = 0.0f; 
        float ySpeed = 0.0f;
        float speed;
        //追従回転
        if(target!=null)transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position-transform.position);
        #region 低速
        if (Input.GetKey (KeyCode.LeftShift)){
            speed=speed_low;
        } else{
            speed=speed_high;
        }
        #endregion
        #region 移動
        float horizontalKey =Input.GetAxis("Horizontal");
        float horizontalKey2 = Input.GetAxis("Vertical");
        if (horizontalKey > 0)
        {
//            transform.localScale = new Vector3(1, 1, 1);
//            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
//            transform.localScale = new Vector3(-1, 1, 1);
//            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
//            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        if (horizontalKey2 > 0)
        {
//            transform.localScale = new Vector3(1, 1, 1);
//            anim.SetBool("run", true);
            ySpeed = speed;
        }
        else if (horizontalKey2 < 0)
        {
//            transform.localScale = new Vector3(-1, 1, 1);
//            anim.SetBool("run", true);
            ySpeed = -speed;
        }
        else
        {
//            anim.SetBool("run", false);
            ySpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
        #endregion
    }
}
