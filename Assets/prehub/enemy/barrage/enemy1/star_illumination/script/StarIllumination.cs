using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarIllumination : MonoBehaviour
{
    public GameObject MagicArrayCircle1;
    public GameObject MagicArrayCircle2;
    public GameObject MagicArrayCircle3;
    public GameObject Effectlike=null;
    [Header("エフェクトが出てから弾幕開始までの間隔")]public float EffectDelay=0f;


    void Start()
    {
        StartCoroutine("action");
    }
    private IEnumerator action(){
        if(Effectlike!=null){
            Instantiate (Effectlike, transform.position, transform.rotation);
            yield return new WaitForSeconds(EffectDelay);
        }
        Instantiate (MagicArrayCircle1, transform.position, transform.rotation,gameObject.transform);
        Instantiate (MagicArrayCircle2, transform.position, transform.rotation,gameObject.transform);
        Instantiate (MagicArrayCircle3, transform.position, transform.rotation,gameObject.transform);
    }
}
