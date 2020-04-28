using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/*
 * playerControllerRigidBody2.cs
 * Allows the player to move within the cave system.
 * Checks for position and changes characters movements accordingly.
 * Created by Isabel -- Recrafted by Taegan
 */

/*
* TaeganCanvasNew PREFAB DOCUMENTATION
 Many tests involve instantiating a main character and a camera.
* Purpose 
In many Unity projects, a test involves instantiating a character and a camera. This provides a quick and easy way to get started.
* Features 
- Creates an instantiation of the Player Prefab (Isables) and a camera that is attached to the player
* Usage 
- Import prefab into Assets/ under Prefabs/ folder
- Prefab can be found in this project under Assets/6-Taegan/Assets/Resources/Prefabs/
- Instantiate the prefab, or drag-and-drop it into your scene
* 
*/
public class PlayerControllerRigidBody2 : MonoBehaviour {
    public float speed;  // Variable for speed movement (should be about 2)
    private Rigidbody2D rb;  // Rigidbody2D for 2D character movement
    private Vector2 moveVelocity;  // Vector for how fast the player will move on screen
    public bool active = false;  // Variable to store if the player is moving on ice 
    public bool timer = false; // timer for movment of player
    public Vector2 pastPosition; // stores previous velocity incase player gets stuck
    public bool canMove; // Sam - Boolean to dictate whether player can move the main character or not
    GameObject Snow; // Game Object to access the snow
    public bool activeButton; //Boolean, true if the player is on the ice

    // ---------------------- NOT INCLUDED IN CLASS DIAGRAM
    int numOfObject; // Stores number of snow particles

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components
        canMove = true; // Sam - Set so that player can move to start
        Snow = GameObject.Find("Grid"); // Grab Snow Object
        if (Snow != null){
            numOfObject = Snow.GetComponent<Particles>().numOfObjects;
        }
       
    }


    // Update is called once per frame
    void Update() {
        GameObject[] SnowVariant = GameObject.FindGameObjectsWithTag("snowParticle"); // Snow Object
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes
        moveVelocity = moveInput.normalized * speed;  // Move according to speed
        

        //// -------------- DEBUG ADD IN ------------------
        //// Stops the player if not on the ice.
        //if (active == false) {
        //    rb.velocity = new Vector2(0, 0);
        //}

        // If player is not moving, give control back to the player
        if (rb.velocity == Vector2.zero)
        {
            active = false;
        }



        // Sam - if, in another script, canMove has been set to false, then player may not move (Used in DialogueManager script to keep player from moving while tlaking with an NPC)
        if (!canMove) {
            rb.velocity = Vector2.zero;
            return;
        }

        //Debug.Log("x: " + rb.position.x + "y: " + rb.position.y);

    }

    // Seperate Update function with the focus of the player is on ice
    void FixedUpdate() {
        try {
            // bool value to signal player is on ice
            //iceMove a = gameObject.AddComponent<iceMove>();
            //activeButton = a.activeButton;
            activeButton = GameObject.Find("Ice").GetComponent<iceMove>().activeButton;
        }
        catch (Exception e) {
            Debug.Log("Exception Thrown: " + e);
        }


        //OBSERVER PATTERN -- CONCRETESUBJECT, observer updated active Button, player is in ice
        // PULL NOTIFICATION - This subscribes to the published value on iceMove.cs
        // code to make the player move on ice
        // if player is on ice, activeButton is true, set on iceMove.cs
        if (activeButton == true) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && active == false) {
                //LEFT
                rb.velocity = new Vector2(-speed, 0);
                active = true; //set the player to moving
                
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && active == false) {
                //RIGHT
                rb.velocity = new Vector2(speed, 0);
                active = true;
              
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && active == false) {
                //UP
                rb.velocity = new Vector2(0, speed);
                active = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && active == false) {
                //DOWN
                rb.velocity = new Vector2(0, -speed);
                active = true;
            }


            // if timer is not accessed and player is ready to move 
            if (timer == false && active == true) {
                // ----------- ERROR CHECKING ---------------
                StartCoroutine(Countdown()); // Checks if the player is moving diagnal
            }
        }
        else {
            // if the player is in dialouge set movement to 0
            if (!canMove) {
                rb.velocity = Vector2.zero;
                return;
            }


            // code to make the player move normally
            active = false;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }

    //if the player colides with a wall allow the player to move
    void OnCollisionEnter2D(Collision2D coll) {
       if (this.enabled)
        {
            active = false;
            rb.velocity = new Vector2(0, 0);
        }      
    }


    // Countdown to check if the player is moving in an uninteded manner
    private IEnumerator Countdown() {
        timer = true; //timer instance is accessed

        //timer variables
        float duration = 1f; // 1 second before checking velocity          
        float normalizedTime = 0;
        while (normalizedTime <= 1f) {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        // If player is not moving straight, stop the player and allow for movement
        if (Math.Abs(rb.velocity.x) != Math.Abs(speed) && rb.velocity.x != 0 && Math.Abs(rb.velocity.x) != Math.Abs(speed) && rb.velocity.y != 0) {
            active = false;
            rb.velocity = new Vector2(0, 0);
        }

        timer = false; // timer exited
    }
}

