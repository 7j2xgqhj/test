using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonFunction : MonoBehaviour
{
    public GameObject EnemyObject;
    public void LoadButtleScene(){
        StaticVariable.EnemyObject=EnemyObject;
        SceneManager.LoadScene("buttle");
    }
    public void LoadTitleScene(){
        SceneManager.LoadScene("title");
    }
    public void LoadStageSelectScene(){
        
        SceneManager.LoadScene("StageSelect");
    }
}
