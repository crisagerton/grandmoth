using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoorTrigger : Interactable
{
    [Header("Side Door Trigger Values")]
    public GlowAnimation glow;
    public SideDoorAnimation sideDoorAni;

    // TEMPORARY
    private SpriteRenderer sr;


    public override void Awake()
    {
        base.Awake();

        sr = GetComponent<SpriteRenderer>();
    }

    public override void mothTriggerEffect()
    {
        currentState = States.Active;

        if (glow != null)
            glow.startGlow();

        sr.color = Color.red;

        sideDoorAni.startMovement(currentState);
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        if (glow != null)
            glow.startGlow();

        sr.color = Color.red;

        sideDoorAni.startMovement(currentState);
    }

    public override void mothLeaveEffect()
    {
        currentState = States.Deactivate;

        sideDoorAni.startMovement(currentState);
    }

    public override void lightLeaveEffect()
    {
        currentState = States.Deactivate;

        sideDoorAni.startMovement(currentState);
    }
}
