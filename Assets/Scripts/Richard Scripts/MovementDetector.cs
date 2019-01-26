using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    public GameObject indicator;

    private Vector3 originalPosition;
    private float allowableOffset = 0.05f;

    public void Awake()
    {
        indicator.SetActive(true);

        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (xOffsetCheck() || yOffsetCheck())
        {
            indicator.SetActive(false);
            this.enabled = false;
        }
    }

    public bool xOffsetCheck()
    {
        return transform.position.x > originalPosition.x + allowableOffset || transform.position.x < originalPosition.x - allowableOffset;
    }

    public bool yOffsetCheck()
    {
        return transform.position.y > originalPosition.y + allowableOffset || transform.position.y < originalPosition.y - allowableOffset;
    }
}
