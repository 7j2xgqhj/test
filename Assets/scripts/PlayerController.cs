using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("高速移動時の速度")]public float HighSpeed = 1;
    [Header("低速移動時の速度")]public float LowSpeed = 0.5f;
    private Transform Target=null;
    private Rigidbody2D rb = null;
    private bool isEnemySearch=false;
    void Start()
    {
        Target=GameObject.FindGameObjectWithTag("Enemy").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        float speed;
        if(Target==null&&!isEnemySearch){
            StartCoroutine("EnemySearch");
        }
        //追従回転
        if(Target!=null)transform.rotation = Quaternion.FromToRotation(Vector3.up, Target.position-transform.position);
        #region 低速
        if (Input.GetKey (KeyCode.LeftShift)){
            speed=LowSpeed;
        } else{
            speed=HighSpeed;
        }
        #endregion
        #region 移動
        float xSpeed = 0.0f; 
        float ySpeed = 0.0f;
        float horizontalKey =Input.GetAxis("Horizontal");
        float horizontalKey2 = Input.GetAxis("Vertical");
        if (horizontalKey > 0){
            xSpeed = speed;
        }
        else if (horizontalKey < 0){
            xSpeed = -speed;
        }
        else{
            xSpeed = 0.0f;
        }
        if (horizontalKey2 > 0){
            ySpeed = speed;
        }
        else if (horizontalKey2 < 0){
            ySpeed = -speed;
        }
        else{
            ySpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
        #endregion
    }
    private IEnumerator EnemySearch(){
        isEnemySearch=true;
        Target=GameObject.FindGameObjectWithTag("Enemy").transform;
        yield return new WaitForSeconds(1f);
        isEnemySearch=false;
    }
}
