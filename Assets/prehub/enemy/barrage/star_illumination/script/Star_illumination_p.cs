using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_illumination_p : MonoBehaviour
{
    public GameObject magic_array_circle_1;
    public GameObject magic_array_circle_2;
    public GameObject magic_array_circle_3;

    public GameObject effectlike=null;
    public float span=0f;


    void Start()
    {
        StartCoroutine("action");
    }
    private IEnumerator action(){
        if(effectlike!=null){
            Instantiate (effectlike, transform.position, transform.rotation);
            yield return new WaitForSeconds(span);
        }
        Instantiate (magic_array_circle_1, transform.position, transform.rotation,gameObject.transform);
        Instantiate (magic_array_circle_2, transform.position, transform.rotation,gameObject.transform);
        Instantiate (magic_array_circle_3, transform.position, transform.rotation,gameObject.transform);
    }
}
