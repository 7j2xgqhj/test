using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class damage_detection : MonoBehaviour
{
    #region public
    GameObject playerobject;
    public GameObject enemyobject;
    public GameObject hp;
    public Canvas canvas;
    public GameObject hart;
    #endregion
    #region startで初期化する変数
    Damage_judgment player_hp;
    Damage_judgment enemy_hp;
    enemy_actions enemy_Actions;
    Slider hp_ber;
    float enemy_hp_max;
    List<GameObject> list_hart_e = new List<GameObject>();
    #endregion
    #region フラグ
    bool game_on=true;
    #endregion
    void Start()
    {
        #region 取得したコンポーネントを用いた初期化
        playerobject=transform.Find("player").gameObject;
        player_hp=playerobject.GetComponent<Damage_judgment>();
        enemy_hp=enemyobject.GetComponent<Damage_judgment>();
        enemy_Actions=enemyobject.GetComponent<enemy_actions>();
        hp_ber = hp.GetComponent<Slider>();
        enemy_hp_max=enemy_hp.hp;
        #endregion
        #region 敵のライフの初期化
        for(int i =0;i<enemy_Actions.action_barrage.Count;i++){
            list_hart_e.Add(Instantiate (hart, new Vector3(300-i*20, 210, 0), transform.rotation));
            list_hart_e[i].transform.SetParent(canvas.transform,false);
        }
        #endregion
    }


    void Update()
    {
        if (game_on){
            #region hpバーを動かす
            if(enemy_hp.hp!=hp_ber.value){
                hp_ber.value=enemy_hp.hp;
            }
            #endregion
            #region gameover,gameclear判定,敵の形態変化
            if (hp_ber.value==0f){
                list_hart_e[list_hart_e.Count-1].SetActive(false);
                list_hart_e.RemoveAt(list_hart_e.Count-1);
                if(enemy_Actions.countup_form()){
                    enemy_hp.hp=enemy_hp_max;
                    enemy_hp.alive=true;
                    hp_ber.value=enemy_hp.hp;
                    
                }else{
                    game_on=false;
                    GameObject gameclearobj =transform.Find("gameclear").gameObject;
                    gameclearobj.SetActive(true);
                }
            }
            if(playerobject==null||player_hp.alive==false){
                game_on=false;
                GameObject gameoverobj =transform.Find("gameover").gameObject;
                gameoverobj.SetActive(true);
                
            }
            #endregion
        }
    }
}
