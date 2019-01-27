using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTorch : MonoBehaviour
{
    [Header("Torch Values")]
    [Range(0f, 5f)]
    public float setLightTimer = 5f;
    public GlowAnimation glow;
    public TorchTrigger torchTrigger;

    private float lightTimer;
    private Interactable.States currentState = Interactable.States.Active;

    // TEMPORARY
    private SpriteRenderer sr;

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (currentState == Interactable.States.Active)
        {
            lightTimer -= Time.deltaTime;

            if (lightTimer <= 0f)
            {
                glow.disableGlow();

                sr.color = Color.white;

                currentState = Interactable.States.Rest;
                torchTrigger.enableRest();
            }
        }
    }

    public void activateDummyTorch()
    {
        currentState = Interactable.States.Active;

        if (!glow.isActive())
            glow.startGlow();

        sr.color = Color.red;

        lightTimer = setLightTimer;
    }
}
