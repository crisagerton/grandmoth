using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoorTrigger : Interactable
{
    [Header("Side Door Trigger Values")]
    public GlowAnimation glow;
    public SideDoorAnimation sideDoorAni;

    public override void Awake()
    {
        base.Awake();
    }

    public override void mothTriggerEffect()
    {
        currentState = States.Active;

        if (glow != null)
            glow.startGlow();

        sideDoorAni.startMovement(currentState);
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        if (glow != null)
            glow.startGlow();

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
