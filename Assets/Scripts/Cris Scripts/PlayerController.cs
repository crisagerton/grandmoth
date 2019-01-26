using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private Vector2 velocity;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + 
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.fixedDeltaTime * speed);
    }
}
