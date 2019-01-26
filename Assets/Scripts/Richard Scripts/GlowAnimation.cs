using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowAnimation : MonoBehaviour
{
    public float duration = 3f;

    private bool activeGrow = false;
    private bool maxLight = false;

    private bool activeShrink = false;

    private float startSize;
    private float startTime;

    private float currentSize;

    public void Awake()
    {
        activeGrow = false;
        maxLight = false;

        activeShrink = false;

        startSize = transform.localScale.x;
        
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeGrow)
        {
            float t = (Time.time - startTime) / duration;
            
            if (t > 1)
            {
                activeGrow = false;
                maxLight = true;
            }
            else
            {
                transform.localScale = new Vector3(Mathf.SmoothStep(0, startSize, t), Mathf.SmoothStep(0, startSize, t), 0);
            }
        }

        if (activeShrink)
        {
            float t = (Time.time - startTime) / duration;

            if (t > 1)
            {
                activeShrink = false;
                maxLight = false;
            }
            else
            {
                transform.localScale = new Vector3(Mathf.SmoothStep(currentSize, 0, t), Mathf.SmoothStep(currentSize, 0, t), 0);
            }
        }
    }

    public void startGlow()
    {
        activeGrow = true;

        startTime = Time.time;

        transform.localScale = Vector3.zero;        
    }

    public void disableGlow()
    {
        activeShrink = true;

        startTime = Time.time;

        currentSize = transform.localScale.x;
    }

    public bool isActive()
    {
        return activeGrow;
    }

    public bool isMaxLight()
    {
        return maxLight;
    }
}
