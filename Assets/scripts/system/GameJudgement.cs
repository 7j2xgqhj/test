using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameJudgement : MonoBehaviour
{
    #region public
    public GameObject HpObject;
    public Canvas Canvas;
    public GameObject EnemyLifeObjectPrehub;
    public GameObject GameOverObject;
    public GameObject GameClearObject;
    #endregion
    #region startで初期化する変数
    private GameObject PlayerObject;
    private GameObject EnemyObject;
    private HpManager playerHpManager;
    private HpManager enemyHpManager;
    private EnemyActions enemyActions;
    private Slider hpSlider;
    private float enemyHpMax;
    private List<GameObject> enemyLifeObjectsManager = new List<GameObject>();
    #endregion
    #region フラグ
    private bool isGamePlay=true;
    #endregion
    void Awake(){
        EnemyObject=Instantiate(StaticVariable.EnemyObject,new Vector3(10,0,0),Quaternion.Euler(0,0,0),gameObject.transform);
    }
    void Start()
    {
        PlayerObject=GameObject.FindGameObjectWithTag("Player");
        playerHpManager=PlayerObject.GetComponent<HpManager>();
        enemyHpManager=EnemyObject.GetComponent<HpManager>();
        enemyActions=EnemyObject.GetComponent<EnemyActions>();
        hpSlider = HpObject.GetComponent<Slider>();
        enemyHpMax=enemyHpManager.Hp;
        
        #region 敵のライフの初期化
        for(int i =0;i<enemyActions.BarrageObjectsList.Count;i++){
            enemyLifeObjectsManager.Add(Instantiate (EnemyLifeObjectPrehub, new Vector3(300-i*20, 210, 0), transform.rotation));
            enemyLifeObjectsManager[i].transform.SetParent(Canvas.transform,false);
        }
        #endregion
    }


    void Update()
    {
        if (isGamePlay){
            #region hpバーを動かす
            if(enemyHpManager.Hp!=hpSlider.value){
                hpSlider.value=enemyHpManager.Hp;
            }
            #endregion
            #region gameover,gameclear判定,敵の形態変化
            if (hpSlider.value==0f){
                enemyLifeObjectsManager[enemyLifeObjectsManager.Count-1].SetActive(false);
                enemyLifeObjectsManager.RemoveAt(enemyLifeObjectsManager.Count-1);
                if(enemyActions.CountUpForm()){
                    enemyHpManager.Hp=enemyHpMax;
                    enemyHpManager.isAlive=true;
                    hpSlider.value=enemyHpManager.Hp;
                }else{
                    isGamePlay=false;
                    GameClearObject.SetActive(true);
                }
            }
            if(PlayerObject==null||!playerHpManager.isAlive){
                isGamePlay=false;
                GameOverObject.SetActive(true);
            }
            #endregion
        }
    }
}
