using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public GlowAnimation glow;

    public void OnTriggerStay2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        if (collision.tag == "Glow" && collision.gameObject != glow.gameObject)
        {
            if (!glow.isActive() && !glow.isMaxLight())
                glow.startGlow();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
      /*  if (collision.tag == "Glow" && collision.gameObject != glow.gameObject)
            glow.disableGlow(); */
    }
}
