using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    [Header("Lamp Values")]
    public GameObject glow;

    // TEMPORARY
    private SpriteRenderer sr;

    public override void Awake()
    {
        base.Awake();

        glow.SetActive(false);

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

        glow.SetActive(true);

        sr.color = Color.red;
    }
}
