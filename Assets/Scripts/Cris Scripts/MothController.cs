using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothController : MonoBehaviour
{
    public float speed;

    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    //add impulse to increase speed and stuff so they can have different accelerations

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position +
            new Vector2(Input.GetAxis("Horizontal1"), Input.GetAxis("Vertical1")) * Time.fixedDeltaTime * speed);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Contains("Light"))
        {
            //Add it so that it falls asleep 
            //half a second of slowdown before falling asleep
            //add public variable for the amount of time before it falls asleep
        }
    }
}
