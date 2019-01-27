using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimDoorTrigger : Interactable
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void mothTriggerEffect()
    {
        currentState = States.Active;
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;
    }

    public override void mothLeaveEffect()
    {
        currentState = States.Rest;
    }

    public override void lightLeaveEffect()
    {
        currentState = States.Rest;
    }

    public Interactable.States getTriggerState()
    {
        return currentState;
    }
}
