using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HormingCircle : MonoBehaviour
{
    public GameObject Effectlike=null;
    public GameObject bulletPrefab;
    private GameObject bullet;
    private Transform target;
    void OnEnable()
    {
        target=GameObject.FindWithTag("Player").transform;
        StartCoroutine("action");
    }
    private IEnumerator action(){
        yield return new WaitForSeconds(0.1f);
        if(Effectlike!=null){
            Instantiate (Effectlike, target.position, transform.rotation);
        }
        yield return new WaitForSeconds(1);
        bullet=Instantiate (bulletPrefab, target.position, transform.rotation);
    }
    void OnDisable(){
        Destroy(bullet);
    }
}
