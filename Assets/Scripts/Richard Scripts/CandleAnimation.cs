using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleAnimation : MonoBehaviour
{
    public float distanceMoved = 3f;

    public float moveDuration = 3f;

    private float startYPosition;
    private float newYPosition;
    private bool active = false;
    private bool closeDoor = false;
    private float startTime;
    
    void Awake()
    {
        startYPosition = transform.position.y;

        newYPosition = startYPosition - distanceMoved;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            float t = (Time.time - startTime) / moveDuration;

            if (t > 1)
            {
                active = false;
            }
            else
                transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(startYPosition, newYPosition, t), 0);
        }
        else if(closeDoor)
        {
            float t = (Time.time - startTime) / moveDuration;

            if (t > 1)
                closeDoor = false;
            else
                transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(newYPosition, startYPosition, t), 0);
        }
    }

    public void startMovement()
    {
        active = true;

        startTime = Time.time;
    }

    public void returnMovement()
    {
        active = false;
        closeDoor = true;

        startTime = Time.time;
    }
}
