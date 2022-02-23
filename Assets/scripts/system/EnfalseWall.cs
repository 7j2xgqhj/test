using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnfalseWall : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
