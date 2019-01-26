using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    [Header("Switch Values")]
    public Bulb bulb;
    
    public override void Awake()
    {
        base.Awake();
    }

    public override void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (mothTriggerCheck(collision))
        {
            mothTriggerEffect();

            gameObject.SetActive(false);
        }

        if (lightTriggerCheck(collision))
        {
            lightTriggerEffect();

            gameObject.SetActive(false);
        }
    }

    public override void mothTriggerEffect()
    {
        active = true;

        bulb.activateBulb();
    }

    public override void lightTriggerEffect()
    {
        active = true;

        bulb.activateBulb();
    }
}
