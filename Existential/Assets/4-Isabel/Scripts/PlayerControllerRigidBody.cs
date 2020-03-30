using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Isabel

// Sam added a canMove bool to make it so player cannot mover if a condition is met (i.e. Player talking with NPC and dialogue box pops up)

public class PlayerControllerRigidBody : MonoBehaviour {
    public float speed;  // Variable for speed movement (should be about 2)
    private Rigidbody2D rb;  // Rigidbody2D for 2D character movement
    private Vector2 moveVelocity;  // Vector for how fast the player will move on screen

    public bool canMove; // Sam - Boolean to dictate whether player can move the main character or not

    void Start() {

        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components 

        canMove = true; // Sam - Set so that player can move to start
    }

    // Update is called once per frame
    void Update(){

        // Sam - if, in another script, canMove has been set to false, then player may not move (Used in DialogueManager script to keep player from moving while tlaking with an NPC)
        if (!canMove) {

            rb.velocity = Vector2.zero;
            return;
        }

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes
        moveVelocity = moveInput.normalized * speed;  // Move according to speed
    }
    // FixedUpdate runs independently per frame (can be zero, one, or multiple)
    void FixedUpdate(){
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);  // Move as long as the arrow keys are pressed
    }

}
