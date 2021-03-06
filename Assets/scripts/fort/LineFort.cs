using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFort : MonoBehaviour
{
    [Header("長さ")]public float Scale=5f;
    [Header("配置数")]public float NumOfForts=5f;
    [Header("発射間隔")]public float ActionSpan=1f;
    [Header("設置時間間隔")]public float InstallationTimeInterval=0f;
    [Header("一回動作後消滅するか")]public bool SelfDestroy=false;
    public GameObject BulletPrefab;

    private List<GameObject> poolObjList=new List<GameObject>();
    void OnEnable()
    {
        StartCoroutine("periodicExecution");
    }
    private  IEnumerator periodicExecution(){
        yield return StartCoroutine ("lineFort");
        if(SelfDestroy){
            gameObject.SetActive(false);
        }
    }
    private  IEnumerator lineFort(){
        for(float i =0;i<NumOfForts;i++){
            shotObject(
                transform.position+new Vector3(
                    (Scale-i*(Scale*2/(NumOfForts-1)))*Mathf.Cos((transform.localEulerAngles.z)*Mathf.PI/180),
                    (Scale-i*(Scale*2/(NumOfForts-1)))*Mathf.Sin((transform.localEulerAngles.z)*Mathf.PI/180),
                    0
                ),
                transform.rotation
            );
            yield return new WaitForSeconds(InstallationTimeInterval);
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
        poolObjList.Add(Instantiate (BulletPrefab, position, rotation));
        return false;
    }
}

