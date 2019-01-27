using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Interactable
{
    [Header("Door Trigger Values")]
    public GlowAnimation glow;
    public DoorAnimation doorAni;

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

        glow.startGlow();

        sr.color = Color.red;

        doorAni.startMovement(currentState);
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        glow.startGlow();

        sr.color = Color.red;

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
