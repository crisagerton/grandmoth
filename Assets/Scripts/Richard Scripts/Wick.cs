using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wick : Interactable
{
    [Header("Wick Values")]
    public GameObject glow;

    // TEMPORARY
    private SpriteRenderer sr;

    private Animator animator;

    public override void Awake()
    {
        base.Awake();

        glow.SetActive(false);

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

        glow.SetActive(true);

        sr.color = Color.red;

        animator.SetTrigger("shrink");
    }
}
