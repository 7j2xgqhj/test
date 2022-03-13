using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFort : MonoBehaviour
{
    [Header("発射間隔")]public float ActionSpan=1f;
    [Header("設置時間間隔")]public float InstallationTimeInterval=0f;
    [Header("砲の数")]public float NumOfForts=3f;
    [Header("設置円の半径")]public float RadiusOfCircle=3f;
    [Header("設置順")]public bool InstallationOrder=true;
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
        if(InstallationOrder){
            for(float i =0;i<NumOfForts;i++){
            shotObject(
            transform.position+new Vector3(RadiusOfCircle*Mathf.Cos(((360/NumOfForts)*i+transform.localEulerAngles.z+90)*Mathf.PI/180),RadiusOfCircle*Mathf.Sin(((360/NumOfForts)*i+transform.localEulerAngles.z+90)*Mathf.PI/180),0),
            transform.rotation*Quaternion.Euler(0,0,(360/NumOfForts)*i)
            );
            yield return new WaitForSeconds(InstallationTimeInterval);
            }
        }else{
            for(float i =0;i<NumOfForts;i++){
            shotObject(
            transform.position+new Vector3(-1*RadiusOfCircle*Mathf.Cos((2*Mathf.PI/NumOfForts)*i+Mathf.PI/2),RadiusOfCircle*Mathf.Sin((2*Mathf.PI/NumOfForts)*i+Mathf.PI/2),0),
            transform.rotation*Quaternion.Euler(0,0,-(360/NumOfForts)*i)
            );
            yield return new WaitForSeconds(InstallationTimeInterval);
            }
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

