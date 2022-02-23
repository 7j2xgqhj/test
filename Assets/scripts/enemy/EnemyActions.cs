using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyActions : MonoBehaviour{
    public List<GameObject> BarrageObjectsList=new List<GameObject>();
    public enum actionlist{
        Standard,
        Attack,
        Horming,
        Stop
    }
    public List<actionlist> ActionPatternsList=new List<actionlist>(){};
    public int Form{get;set;}=0;

    public bool CountUpForm(){
        if((BarrageObjectsList.Count-1)<=Form){
            return false;
        }else{
            Form++;
            return true;
        }
    }
}


