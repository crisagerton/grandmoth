using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimDoorTrigger : Interactable
{
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
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        sr.color = Color.red;
    }

    public override void mothLeaveEffect()
    {
        currentState = States.Rest;

        sr.color = Color.white;
    }

    public override void lightLeaveEffect()
    {
        currentState = States.Rest;

        sr.color = Color.white;
    }

    public Interactable.States getTriggerState()
    {
        return currentState;
    }
}
