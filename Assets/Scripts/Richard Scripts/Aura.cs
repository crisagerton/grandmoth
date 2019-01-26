using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public GameObject glow;

    public void Awake()
    {
        glow.SetActive(false);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Glow")
            glow.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Glow")
            glow.SetActive(false);
    }
}
