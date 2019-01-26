using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Interactable
{
    [Header("Torch Values")]
    [Range(0f, 5f)]
    public float setLightTimer = 2;
    public GlowAnimation glow;

    private float lightTimer;

    // TEMPORARY
    private SpriteRenderer sr;

    public override void Awake()
    {
        base.Awake();

        sr = GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        base.Update();

        if (active)
        {
            lightTimer -= Time.deltaTime;

            if (lightTimer <= 0f)
            {
                glow.disableGlow();

                sr.color = Color.white;

                active = false;
            }
        }
    }

    public override void mothTriggerEffect()
    {
        return;
    }

    public override void lightTriggerEffect()
    {
        active = true;

        if (!glow.isActive())
            glow.startGlow();

        sr.color = Color.red;

        lightTimer = setLightTimer;
    }
}
