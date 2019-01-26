using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{

    public void activateBulb()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
