using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardFort : MonoBehaviour
{
    [Header("発射間隔")]public float ActionSpan=0.5f; 
    public GameObject BulletPrefab;
    private List<GameObject> poolObjList=new List<GameObject>();
    private bool isAction=false;
    void Update()
    {
        if(!isAction){
            StartCoroutine("periodicExecution");
        }
    }
    void OnDisable(){
        foreach (var obj in poolObjList) {
            Destroy(obj);
        }
        poolObjList.Clear();
    }
private IEnumerator periodicExecution(){
        isAction=true;
        shotObject(transform.position,transform.rotation);
        yield return new WaitForSeconds(ActionSpan);
        isAction=false;
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
        poolObjList.Add(Instantiate (BulletPrefab, position, rotation));
        return false;
    }
}
