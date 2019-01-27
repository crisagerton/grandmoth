using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : Interactable
{
    public DummyTorch dummyTorch;
    
    public override void Awake()
    {
        base.Awake();
    }

    public override void mothTriggerEffect()
    {
        currentState = States.Active;

        dummyTorch.activateDummyTorch();
    }

    public override void lightTriggerEffect()
    {
        currentState = States.Active;

        dummyTorch.activateDummyTorch();
    }

    public override void mothLeaveEffect()
    {
        return;
    }

    public override void lightLeaveEffect()
    {
        return;
    }

    public void enableRest()
    {
        currentState = States.Rest;
    }
}
