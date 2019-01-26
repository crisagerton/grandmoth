using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GlowAnimation glow;

    public void activateBulb()
    {
        glow.startGlow();

        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
