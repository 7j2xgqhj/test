using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyA : MonoBehaviour
{
    enemy_actions enemy_actions;
    Rigidbody2D rb =null;
    Transform target; 
    bool action_flag=false;
    float action_span=3;
    int form=0;
    void Start()
    {
        enemy_actions=GetComponent<enemy_actions>();
        target=enemy_actions.target;
        rb =GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(form!=enemy_actions.form){
            form=(int)enemy_actions.form;
            switch(form){
                case 1:
                    
                    
                    break;
                case 2:
                    
                    
                    break;
            }
            if(form>1) enemy_actions.action_barrage[form-2].SetActive(false);
            enemy_actions.action_barrage[form-1].SetActive(true);
        }
        if(action_flag==false){
                StartCoroutine("action_"+enemy_actions.actions[form-1]);
        }
        if(target!=null){
            transform.rotation = Quaternion.FromToRotation(Vector3.up, target.position-transform.position);
        }
    }
        private IEnumerator action_Defo(){
        action_flag=true;
        float rad=UnityEngine.Random.Range(0,2*Mathf.PI);
        action_span=UnityEngine.Random.Range(0.5f,3f);
        rb.velocity= new Vector2(Mathf.Cos(rad),Mathf.Sin(rad))*UnityEngine.Random.Range(1f,3f);
        yield return new WaitForSeconds(action_span);
        action_flag=false;
    }
    private IEnumerator action_Attack(){
        action_flag=true;
        rb.velocity=transform.up*50f;
        yield return new WaitForSeconds(action_span);
        action_flag=false;
    }
}
