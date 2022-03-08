using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLine : MonoBehaviour
{
    [Header("出現時の大きさ")]public Vector2 Startsize=new Vector2(1f,1f);
    [Header("消滅の有無")]public bool isDelete=true;
    [Header("消滅までの時間")]public float Duration=5f;
    [Header("フェードアウト")]public bool isFade=true;
    [Header("フェードアウトまでの時間")]public float FadeTime=0.5f;
    [Header("フェードアウト処理の間隔")]public float FadeActionTime=0.1f;
    [Header("変化後のスケール")]public List<Vector2> SizeList=new List<Vector2>();
    [Header("変化にかける時間")]public List<float> TimeList=new List<float>();
    private SpriteRenderer spriteRenderer=null;
    private float fadeSpeed=1f;
    private bool isFadeActionSwitch=false;
    private bool isFadeAction=false;
    void Start()
    {
        if(isFade){
            spriteRenderer=GetComponent<SpriteRenderer>();
            fadeSpeed=(spriteRenderer.color.a/FadeTime)*FadeActionTime;
            StartCoroutine("fadeActionSwitch");
        }
        transform.localScale=new Vector3(Startsize.x,Startsize.y,transform.localScale.z);
        if(isDelete){
            StartCoroutine("deleteAction");
        }
        
    }
    void Update()
    {
        if(isFadeActionSwitch&&!isFadeAction){
            StartCoroutine("fadeAction");
        }
    }
    private IEnumerator deleteAction(){
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }
    private IEnumerator fadeActionSwitch(){
        yield return new WaitForSeconds(Duration-FadeTime);
        isFadeActionSwitch=true;
    }
    private IEnumerator fadeAction(){
        isFadeAction=true;
        yield return new WaitForSeconds(FadeActionTime);
        spriteRenderer.color+=new Color(0,0,0,-fadeSpeed);
        isFadeAction=false;
    }
    
}
