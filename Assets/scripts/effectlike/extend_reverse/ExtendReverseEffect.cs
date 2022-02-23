using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendReverseEffect : MonoBehaviour
{

    [Header("出現時の大きさ")]public float startsize=1f;
    [Header("消滅の有無")]public bool del=true;
    [Header("消滅までの時間")]public float duration=5f;
    [Header("拡散速度")]public float extendspeed=1f;
    [Header("回転速度")]public float spinspeed=1f;
    private bool isAction=true;
    void Start()
    {
        transform.localScale=new Vector3(startsize,startsize,transform.localScale.z);
        StartCoroutine("action");
    }
    void Update()
    {
        if(isAction){
        transform.localScale=new Vector3(transform.localScale.x+extendspeed,transform.localScale.y+extendspeed,transform.localScale.z);
        }
        transform.Rotate(new Vector3(0,0,spinspeed));
    }
    private IEnumerator action(){
        yield return new WaitForSeconds(duration);
        if(del){
            Destroy(gameObject);
        }else{
            isAction=false;
        }
    }
}
