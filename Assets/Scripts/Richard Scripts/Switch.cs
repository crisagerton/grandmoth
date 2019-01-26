using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    [Header("Switch Values")]
    public Bulb bulb;

    // TEMPORARY
    private SpriteRenderer sr;

    public override void Awake()
    {
        base.Awake();

        sr = GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void mothTriggerEffect()
    {
        active = true;

        sr.color = Color.red;

        bulb.activateBulb();
    }

    public override void lightTriggerEffect()
    {
        return;
    }
}
