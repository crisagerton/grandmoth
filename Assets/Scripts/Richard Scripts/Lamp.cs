using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    [Header("Lamp Values")]
    public GlowAnimation glow;

    public override void Awake()
    {
        base.Awake();
    }

    public override void mothTriggerEffect()
    {
        return;
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        glow.startGlow();
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
