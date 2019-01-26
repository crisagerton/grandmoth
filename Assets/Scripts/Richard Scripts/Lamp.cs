using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    [Header("Lamp Values")]
    public GlowAnimation glow;

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
        return;
    }

    public override void lightTriggerEffect()
    {
        active = true;

        glow.startGlow();

        sr.color = Color.red;
    }
}
