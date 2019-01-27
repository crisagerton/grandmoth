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
    
    public override void Awake()
    {
        base.Awake();
    }

    public void Update()
    {
        if (currentState == States.Active)
        {
            lightTimer -= Time.deltaTime;

            if (lightTimer <= 0f)
            {
                glow.disableGlow();

                currentState = States.Rest;
            }
        }
    }

    public override void mothTriggerEffect()
    {
        return;
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        if (!glow.isActive())
            glow.startGlow();

        lightTimer = setLightTimer;
    }

    public override void mothLeaveEffect()
    {
        return;
    }

    public override void lightLeaveEffect()
    {
        return;
    }
}
