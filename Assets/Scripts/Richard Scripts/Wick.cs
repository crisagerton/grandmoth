using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wick : Interactable
{
    // TEMPORARY
    private SpriteRenderer sr;

    private Animator animator;

    public override void Awake()
    {
        base.Awake();

        sr = GetComponent<SpriteRenderer>();

        animator = transform.parent.GetComponent<Animator>();
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

        sr.color = Color.red;

        animator.SetTrigger("shrink");
    }
}
