using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GameObject glow;

    public void Awake()
    {
        glow.SetActive(false);
    }

    public void activateBulb()
    {
        glow.SetActive(true);

        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
