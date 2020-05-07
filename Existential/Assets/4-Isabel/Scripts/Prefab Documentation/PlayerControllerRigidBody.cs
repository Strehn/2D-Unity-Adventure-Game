/* Created  by Isabel Hinkle, modified by Sam
 * Takes in a player rigidbody 2D and controls movement of player on screen based on key input
 * Based on the video by Blackthornprod: https://www.youtube.com/watch?v=CeXAiaQOzmY
 */

 /* Documentation for Main Character Prefab
 * Written by Isabel Hinkle
 * Have you ever wanted to create a 2D orthographic game that utilizes pixel art?
 * Well, look no further! The Main Character Prefab contains a sprite 2D UI image for our pixel art character, Estelle!
 * The prefab will come loaded with:
 *  - A main camera attached
 *  - An audio source
 *  - A sound script (which features a large array of sounds collected) 
 *    to play sounds as the main character traverses through your wonderful Unity game
 *  - The player controller rigid body script (also written by me) which is used to move the player on screen
 *  - A rigidbody 2D for movement
 *  - A box collider 2D for interactions with other NPC's, inventory objects, boundaries... the sky is the limit!
 * Prefab features:
 *  - Complete flexibility to use with other sprites
 *  - The freedom to scale the prefab
 *  - The freedom to transform the prefab's position starting on screen 
 *  - The ability to change the sorting layer
 * Tech Specs:
 *  - Unity 2019
 *  - Clean, well-documented C# scripts for all components
 *  - Mobile friendly - Android
 * Refund Policy:
 *  - This prefab is free on the Unity Asset Store for a limited time - so download it now!
 *  - Otherwise, we will not accept refunds due to short staffing :/
 * Other Notes:
 *  - We love to see our prefabs being used! Please tag us in your projects on social media @ StudioBlueBox 
 *  - If you have any questions, please do not hesitate to contact our 24 hour customer care @ 208.292.2671
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigidBody : MonoBehaviour {
    public float speed;  // Variable for speed movement (should be about 2)
    private Rigidbody2D rb;  // Rigidbody2D for 2D character movement
    private Vector2 moveVelocity;  // Vector for how fast the player will move on screen

    public bool canMove; // Sam - Boolean to dictate whether player can move the main character or not




    //Added By Taegan
    public Animator animator;


    void Start() {

        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components 

        canMove = true; // Sam - Set so that player can move to start 
    }

    // Update is called once per frame
    void Update(){

        //Added By Taegan
        float horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        float verticalMove = Input.GetAxisRaw("Vertical") * speed;
        animator.SetFloat("horizontal",horizontalMove);
        if (horizontalMove > 0)
        {
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        }
        else
        {
            animator.SetFloat("speed", Mathf.Abs(verticalMove));
        }
        
        
        animator.SetFloat("vertical", verticalMove);

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
