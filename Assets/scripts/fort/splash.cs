using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class splash : MonoBehaviour
{
    // Start is called before the first frame update
    private float span_frame=0;

    public float span=10f; 
    public GameObject bulletPrefab;
    public float angle_of_fire=0;
    public GameObject effect=null;
    List<GameObject> _poolObjList=new List<GameObject>();
    void Update()
    {
        span_frame++;
        if (span<=span_frame){
                shotObject(
                    transform.position,
                    transform.rotation*Quaternion.Euler(0f, 0f, Random.Range(-1*angle_of_fire,angle_of_fire)));
                span_frame=0;
            }
    }
    void OnDisable(){
        foreach (var obj in _poolObjList) {
            Destroy(obj);
        }
        _poolObjList.Clear();
    }
    public bool shotObject(Vector3 position,Quaternion rotation){
        // 使用中でないものを探して返す
        foreach (var obj in _poolObjList) {
            if (obj.activeSelf == false) {
                obj.transform.position=position;
                obj.transform.rotation=rotation;
                obj.SetActive(true);
                return true;
            }
        }
        // 全て使用中だったら新しく作って返す
        _poolObjList.Add(Instantiate (bulletPrefab, position, rotation));
        return false;
    }
}
