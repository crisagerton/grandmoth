using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothController : MonoBehaviour
{
    public float speed;
    public float sleepySpeed; //the speed the moth falls asleep

    private Rigidbody2D rb2d;
    private Vector2 velocity;
    private float currentSpeed;
    private bool sleepyTime; //true if outside a light source
    //add impulse to increase speed and stuff so they can have different accelerations

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 0);
        currentSpeed = speed;
    }

    void FixedUpdate()
    {
        ///Adjusting current speed based on if it's outside a light source ("Glow")
        if (sleepyTime)
        {
            if (currentSpeed > 0.001)
                currentSpeed -= Time.fixedDeltaTime/sleepySpeed;
        }
        else
            currentSpeed = speed;

        Debug.Log(currentSpeed);

        rb2d.MovePosition(rb2d.position +
            new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1")) * Time.fixedDeltaTime * currentSpeed);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Contains("Glow"))
        {
            sleepyTime = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Contains("Glow"))
            sleepyTime = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Contains("Glow"))
            sleepyTime = false;
    }
}
