using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    public float speed = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Light")
        {
            col.GetComponent<PlayerController>().speed = speed;
        }
    }
}
