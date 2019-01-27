using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Interactable
{
    [Header("Door Trigger Values")]
    public GlowAnimation glow;
    public DoorAnimation doorAni;    

    public override void Awake()
    {
        base.Awake();
    }

    public override void mothTriggerEffect()
    {
        currentState = States.Active;

        if (glow != null)
            glow.startGlow();

        doorAni.startMovement(currentState);
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        if (glow != null)
            glow.startGlow();
        
        doorAni.startMovement(currentState);
    }

    public override void mothLeaveEffect()
    {
        currentState = States.Deactivate;

        doorAni.startMovement(currentState);
    }

    public override void lightLeaveEffect()
    {
        currentState = States.Deactivate;

        doorAni.startMovement(currentState);
    }
}
