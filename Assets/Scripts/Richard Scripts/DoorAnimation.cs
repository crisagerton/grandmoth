using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public float distanceMoved = 3f;

    public float moveDuration = 3f;

    private float startYPosition;
    private float currentYPosition;
    private float newYPosition;

    public DoorTrigger dTrigger;

    public GameObject[] simDTriggers;

    Interactable.States currentState = Interactable.States.Rest;

    private float startTime;
    
    void Awake()
    {
        startYPosition = transform.position.y;

        newYPosition = startYPosition - distanceMoved;
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


                if (dTrigger != null)
                    dTrigger.enabled = false;

                foreach (GameObject simDTrigger in simDTriggers)
                {
                    simDTrigger.GetComponent<SpriteRenderer>().enabled = false;

                    if (simDTrigger.GetComponent<ParticleSystem>() != null)
                        simDTrigger.GetComponent<ParticleSystem>().Stop();
                }

                enabled = false;


            }
            else
                transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(currentYPosition, newYPosition, t), 0);
        }
        else if (currentState == Interactable.States.Deactivate)
        {
            float t = (Time.time - startTime) / moveDuration;

            if (t > 1)
                currentState = Interactable.States.Rest;
            else
                transform.position = new Vector3(transform.position.x, Mathf.SmoothStep(currentYPosition, startYPosition, t), 0);
        }
        else
        {
            return;
        }
    }

    public void startMovement(Interactable.States state)
    {
        currentState = state;

        currentYPosition = transform.position.y;

        startTime = Time.time;
    }
}
