using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFort : MonoBehaviour
{
    [Header("発射間隔")]public float ActionSpan=1f;
    [Header("設置時間間隔")]public float InstallationTimeInterval=0f;
    [Header("砲の数")]public float NumOfForts=3f;
    [Header("設置円の半径")]public float RadiusOfCircle=3f;
    public GameObject BulletPrefab;
    private bool isAction=false;
    private List<GameObject> poolObjList=new List<GameObject>();
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
        for(float i=0;i<NumOfForts;i++){
            shotObject ( 
                transform.position+new Vector3(RadiusOfCircle*Mathf.Cos((2*Mathf.PI/NumOfForts)*i)
                    ,RadiusOfCircle*Mathf.Sin((2*Mathf.PI/NumOfForts)*i)
                    ,0)
                ,transform.rotation
            );
            yield return new WaitForSeconds(InstallationTimeInterval);
        }
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

