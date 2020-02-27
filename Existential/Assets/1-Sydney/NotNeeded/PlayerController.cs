using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    This is the script for main character. It allows the player to move the main    
    character. It needs to be attached to the main character sprite. 

*/

public class PlayerController : MonoBehaviour{
    //variable to store the player's movement speed.
    public float speed;                

    //required to use 2D Physics.
    private Rigidbody2D rb2d;    
   
    // Use this for initialization
    void Start(){
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. 
    // This is where physics calculation happens
    void FixedUpdate(){
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");  // Isabel

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");  // Isabel

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d to move our player.
        rb2d.AddForce (movement * speed);
    }
}
