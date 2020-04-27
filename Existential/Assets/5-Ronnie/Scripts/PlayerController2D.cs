/*******************
 * Ronnie Keating - Level Player script
 * Just apply this to a character prefab
 * and you have 2D platformer controls.
 *
 * This is my example of reuse.
 * I found the coding instructions on this
 * video: https://www.youtube.com/watch?v=44djqUTg2S
 * The legal implications I believe are nonexistent
 * since the reuse came from a tutorial video
 * Tilemap reuse: https://rpg.hamsterrepublic.com/ohrrpgce/Free_Tilemaps
 ******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour {
    Rigidbody2D rb; //player rigidbody
    private float speed; //speed of the player

    //determine if player is touching ground, do not want double jumps
    bool isGround;
    //This is a gameobject that I applied to the character in order to see if
    //the player is touching the ground
    [SerializeField] Transform groundCheck;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>(); //initialize rigidbody
        speed = 4f; //set speed
    }

    //Fixed update gets called every frame, more than once per frame, or zero times per frame. Depends
    private void FixedUpdate() {
        //This is the check to see if the groundCheck object is touching the ground.
        //Had to give boundaries in the grid a layer name of "Ground"
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) {
            isGround = true;
        }
        else {
            isGround = false;
        }

        //If button press is right, go right
        if (Input.GetKey("right")) {
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }

        //If button press is left, go left
        else if (Input.GetKey("left")) {
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        
        //This is to make sure the player does not slide
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //This is to move on to the next level. Acts like a door and so
        //we can press up and enter the door without jumping
        if(Input.GetKey("up") && rb.position.x >= 91.5 && rb.position.x <= 92.5) {
            SceneManager.LoadScene("EndScene");
        }

        //Else statement to avoid errors with up press, this is the actual jump
        else if (Input.GetKey("up") && isGround) {
            rb.velocity = new Vector2(rb.velocity.x, 9.5f);
        }

        //This is when the player falls in the lava
        if(rb.position.y < -3f) {
            transform.position = new Vector2(-8, -1);
        }
    }
}
