using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    This is the script for main character. It allows the player to move the main    
    character. It needs to be attached to the main character sprite. 

*/

public class Movement : MonoBehaviour{

    // check for movement and apply it to player object
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Vector2 movementVector;
    private Vector2 spriteMovement;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    // update is called once per frame
    void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        movementVector = new Vector2(moveHorizontal, moveVertical);

        // get the speed the sprite needs to move at
        spriteMovement = movementVector.normalized * speed;
    }
        //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
        void FixedUpdate()
    {
        // apply movement to the sprite
        rb2d.MovePosition(rb2d.position + spriteMovement * Time.fixedDeltaTime); 

    }

}

