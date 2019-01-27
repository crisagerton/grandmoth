using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimDoorTrigger : Interactable
{
    [Header("Door Trigger Values")]
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

        sr.color = Color.red;

        doorAni.startMovement(currentState);
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        sr.color = Color.red;

        doorAni.startMovement(currentState);
    }

    public override void mothLeaveEffect()
    {
        currentState = States.Rest;

        sr.color = Color.white;

        doorAni.startMovement(currentState);
    }

    public override void lightLeaveEffect()
    {
        currentState = States.Rest;

        sr.color = Color.white;

        doorAni.startMovement(currentState);
    }

    public Interactable.States getTriggerState()
    {
        return currentState;
    }
}
