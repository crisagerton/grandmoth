using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : Interactable
{
    public DummyTorch dummyTorch;

    public GameObject glow;

    public SpriteRenderer sprite;

    private ParticleSystem particles;
    
    public override void Awake()
    {
        base.Awake();

        particles = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (glow.transform.localScale == Vector3.zero)
        {
            sprite.enabled = true;

            if (!particles.isPlaying)
                particles.Play();

            currentState = States.Rest;
        }
        else
        {
            sprite.enabled = false;

            if (particles.isPlaying)
                particles.Stop();
        }
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
