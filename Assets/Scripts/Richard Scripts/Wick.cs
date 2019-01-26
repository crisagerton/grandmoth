using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wick : Interactable
{
    [Header("Wick Values")]
    public GlowAnimation glow;

    // TEMPORARY
    private SpriteRenderer sr;

    private CandleAnimation candleAni;

    public override void Awake()
    {
        base.Awake();

        sr = GetComponent<SpriteRenderer>();

        candleAni = transform.parent.GetComponent<CandleAnimation>();
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

        candleAni.startMovement();
    }
}
