using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy_actions : MonoBehaviour{
    public Transform target; 
    public List<GameObject> action_barrage=new List<GameObject>();
    public enum actionlist{
        Defo,
        Attack,
        Horming,
        Stop
    }
    public List<actionlist> actions=new List<actionlist>(){};
    public float form{get;set;}=1;
    public bool countup_form(){
        if(action_barrage.Count<=form){
            return false;
        }else{
            form++;
            return true;
        }
    }
}


