using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject Effect=null;
    private List<GameObject> poolObjList=new List<GameObject>();
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            shotObject( Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,9f)),transform.rotation);
        }
    }
        private bool shotObject(Vector3 position,Quaternion rotation){
        // 使用中でないものを探して返す
        foreach (var obj in poolObjList) {
            if (obj.activeSelf == false) {
                obj.transform.position=position;
                obj.transform.rotation=rotation;
                obj.SetActive(true);
                return true;
            }
        }
        // 全て使用中だったら新しく作って返す
        poolObjList.Add(Instantiate (Effect, position, rotation));
        return false;
    }
}
