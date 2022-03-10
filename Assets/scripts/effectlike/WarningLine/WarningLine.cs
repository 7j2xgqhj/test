using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLine : MonoBehaviour
{
    [Header("出現時の大きさ")]public Vector2 Startsize=new Vector2(1f,1f);
    [Header("消滅の有無")]public bool isDelete=true;
    [Header("消滅までの時間")]public float Duration=5f;
    [Header("フェードイン")]public bool isFadeIn=true;
    [Header("フェードインまでの時間")]public float FadeInTime=0.5f;
    [Header("フェードイン処理の間隔")]public float FadeInActionTime=0.1f;
    [Header("フェードアウト")]public bool isFadeOut=true;
    [Header("フェードアウトまでの時間")]public float FadeOutTime=0.5f;
    [Header("フェードアウト処理の間隔")]public float FadeOutActionTime=0.1f;
    [Header("変化後のスケール")]public Vector2 Size=new Vector2(1f,1f);
    [Header("変化にかける時間")]public float Time=1f;
    [Header("処理間隔")]public float ActionTime=0.1f;
    [Header("X端を固定")]public bool isKeepX=false;
    [Header("Y端を固定")]public bool isKeepY=true;
    private SpriteRenderer spriteRenderer=null;
    private float fadeInSpeed=0f;
    private bool isFadeInActionSwitch=false;
    private bool isFadeInAction=false;
    private float fadeOutSpeed=0f;
    private bool isFadeOutActionSwitch=false;
    private bool isFadeOutAction=false;
    private Vector2 changeSpeed=new Vector2(1f,1f);
    private bool isAction =false;
    private bool isActionSwitch=true;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        if(isFadeOut){
            fadeOutSpeed=(spriteRenderer.color.a/FadeOutTime)*FadeOutActionTime;
            StartCoroutine("fadeOutActionSwitch");
        }
        if(isFadeIn){
            isFadeInActionSwitch=true;
            fadeInSpeed=(spriteRenderer.color.a/FadeInTime)*FadeInActionTime;
            spriteRenderer.color-=new Color(0,0,0,spriteRenderer.color.a);
            StartCoroutine("fadeInActionSwitch");
        }
        transform.localScale=new Vector3(Startsize.x,Startsize.y,transform.localScale.z);
        if(isDelete){
            StartCoroutine("deleteAction");
        }
        changeSpeed=((Size-Startsize)/Time)*ActionTime;
        StartCoroutine("actionSwitch");
    }
    void Update()
    {
        if(isFadeInActionSwitch&&!isFadeInAction){
            StartCoroutine("fadeInAction");
        }
        if(isFadeOutActionSwitch&&!isFadeOutAction){
            StartCoroutine("fadeOutAction");
        }
        if(isActionSwitch&&!isAction){
            StartCoroutine("action");
        }
    }
    private IEnumerator deleteAction(){
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);
    }
    private IEnumerator fadeOutActionSwitch(){
        yield return new WaitForSeconds(Duration-FadeOutTime);
        isFadeOutActionSwitch=true;
    }
    private IEnumerator fadeOutAction(){
        isFadeOutAction=true;
        yield return new WaitForSeconds(FadeOutActionTime);
        spriteRenderer.color+=new Color(0,0,0,-fadeOutSpeed);
        isFadeOutAction=false;
    }
    private IEnumerator fadeInActionSwitch(){
        yield return new WaitForSeconds(FadeInTime);
        isFadeInActionSwitch=false;
    }
    private IEnumerator fadeInAction(){
        isFadeInAction=true;
        yield return new WaitForSeconds(FadeInActionTime);
        spriteRenderer.color+=new Color(0,0,0,fadeInSpeed);
        isFadeInAction=false;
    }
    private IEnumerator action(){
        isAction=true;
        yield return new WaitForSeconds(ActionTime);
        transform.localScale+=new Vector3(changeSpeed.x,changeSpeed.y,0);
        if(isKeepX){
            transform.position+=new Vector3(changeSpeed.x/2,0,0);
        }
        if(isKeepY){
            transform.position+=new Vector3(0,changeSpeed.y/2,0);
        }
        isAction=false;
        }
    private IEnumerator actionSwitch(){
        yield return new WaitForSeconds(Time);
        isActionSwitch=false;
    }
}
