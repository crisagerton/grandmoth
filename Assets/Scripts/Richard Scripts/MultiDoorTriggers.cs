using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDoorTriggers : Interactable
{
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
        return;
    }

    public override void lightLeaveEffect()
    {
        return;
    }

    public States getCurrentState()
    {
        return currentState;
    }
}
