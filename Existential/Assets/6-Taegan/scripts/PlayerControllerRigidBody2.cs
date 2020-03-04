using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Isabel -- Recrafted by Taegan

public class PlayerControllerRigidBody2 : MonoBehaviour
{
    public float speed;  // Variable for speed movement (should be about 2)
    private Rigidbody2D rb;  // Rigidbody2D for 2D character movement
    private Vector2 moveVelocity;  // Vector for how fast the player will move on screen

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes
        moveVelocity = moveInput.normalized * speed;  // Move according to speed
    }
    // FixedUpdate runs independently per frame (can be zero, one, or multiple)
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);  // Move as long as the arrow keys are pressed
    }

    //Changes direction of the ball based on its speed and position on the paddle
    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb.velocity.x - 5;
            vel.y = rb.velocity.y - 5;
            rb.velocity = vel;
        }
    }

}
