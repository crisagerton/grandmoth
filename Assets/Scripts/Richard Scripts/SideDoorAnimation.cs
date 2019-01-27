using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoorAnimation : MonoBehaviour
{
    public float distanceMoved = 3f;

    public float moveDuration = 3f;

    private float startXPosition;
    private float currentXPosition;
    private float newXPosition;

    public SideDoorTrigger sdTrigger;

    Interactable.States currentState = Interactable.States.Rest;

    private float startTime;

    void Awake()
    {
        startXPosition = transform.position.x;

        newXPosition = startXPosition - distanceMoved;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == Interactable.States.Active)
        {
            float t = (Time.time - startTime) / moveDuration;

            if (t > 1)
            {
                currentState = Interactable.States.Rest;
                if (sdTrigger != null)
                {
                    sdTrigger.enabled = false;
                    enabled = false;
                }
            }
            else
                transform.position = new Vector3(Mathf.SmoothStep(currentXPosition, newXPosition, t), transform.position.y, 0);
        }
        else if (currentState == Interactable.States.Deactivate)
        {
            float t = (Time.time - startTime) / moveDuration;

            if (t > 1)
                currentState = Interactable.States.Rest;
            else
                transform.position = new Vector3(Mathf.SmoothStep(currentXPosition, startXPosition, t), transform.position.y, 0);
        }
        else
        {
            return;
        }
    }

    public void startMovement(Interactable.States state)
    {
        currentState = state;

        currentXPosition = transform.position.x;

        startTime = Time.time;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MovingDoor")
        {
            startMovement(Interactable.States.Deactivate);
        }
    }
}
