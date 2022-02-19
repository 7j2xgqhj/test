using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public float span=1f;
    public float fortspan=0f;
    public float fortnum=3f;
    public float radius=3f;
    private bool action_flag=false;
    public GameObject bulletPrefab;
    public GameObject effect=null;
    List<GameObject> _poolObjList=new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if(action_flag==false){
                StartCoroutine("action");
        }
    }
    void OnDisable(){
        foreach (var obj in _poolObjList) {
            Destroy(obj);
        }
        _poolObjList.Clear();
    }
    private IEnumerator action(){
        action_flag=true;
        for(float i=0;i<fortnum;i++){
            shotObject ( 
            transform.position+new Vector3(radius*Mathf.Cos((2*Mathf.PI/fortnum)*i),radius*Mathf.Sin((2*Mathf.PI/fortnum)*i),0),
            transform.rotation
            );
            yield return new WaitForSeconds(fortspan);
        }
        yield return new WaitForSeconds(span);
        action_flag=false;
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

