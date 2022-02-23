using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionList : MonoBehaviour
{
    private EnemyActions enemyActions;
    private Rigidbody2D rb =null;
    private Transform target; 
    private bool isAction=false;
    float action_span=3;
    private int form=0;
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").transform;
        enemyActions=GetComponent<EnemyActions>();
        rb =GetComponent<Rigidbody2D>();
        form=enemyActions.Form;
        enemyActions.BarrageObjectsList[form].SetActive(true);
    }

    
    void Update()
    {
        if(form!=enemyActions.Form){
            enemyActions.BarrageObjectsList[form].SetActive(false);
            form=enemyActions.Form;
            enemyActions.BarrageObjectsList[form].SetActive(true);
        }
        if(isAction==false){
                StartCoroutine(""+enemyActions.ActionPatternsList[form]);
        }
    }
        private IEnumerator Standard(){
        isAction=true;
        float rad=UnityEngine.Random.Range(0,2*Mathf.PI);
        rb.velocity= new Vector2(Mathf.Cos(rad),Mathf.Sin(rad))*UnityEngine.Random.Range(1f,3f);
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f,3f));
        isAction=false;
    }
    private IEnumerator Attack(){
        isAction=true;
        if(target!=null){
            transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position-transform.position);
        }
        rb.velocity=transform.up*50f;
        yield return new WaitForSeconds(action_span);
        isAction=false;
    }
}
