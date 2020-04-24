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
public class PlayerControllerRigidBody2 : MonoBehaviour {
    public float speed;  // Variable for speed movement (should be about 2)
    private Rigidbody2D rb;  // Rigidbody2D for 2D character movement
    private Vector2 moveVelocity;  // Vector for how fast the player will move on screen
    public bool active = false;  // Variable to store if the player is moving on ice 
    public bool timer = false; // timer for movment of player
    public Vector2 pastPosition; // stores previous velocity incase player gets stuck
    bool activeButton = false;
    public bool canMove; // Sam - Boolean to dictate whether player can move the main character or not
    GameObject Snow; // Game Object to access the snow

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components
        canMove = true; // Sam - Set so that player can move to start
        Snow = GameObject.Find("Grid"); // Grab Snow Object
    }


    // Update is called once per frame
    void Update() {
        GameObject[] SnowVariant = GameObject.FindGameObjectsWithTag("snowParticle"); // Snow Object
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes
        moveVelocity = moveInput.normalized * speed;  // Move according to speed


        // -------------- DEBUG ADD IN ------------------
        // Stops the player if not on the ice.
        if (active == false) {
            rb.velocity = new Vector2(0, 0);
        }

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



        //--------- TRANSPORT SCRIPTS -----------
        // if the player is in field, transfer him to the next area

        // from ice cave to fog cave
        if (rb.position.x >= 144 && rb.position.x <= 148 && rb.position.y <= -7) {
            transform.position = new Vector2(46, -28);
        }

        // from fog cave to ice cave
        else if (rb.position.x >= 46 && rb.position.x <= 48 && rb.position.y >= -26) {
            transform.position = new Vector2(147, -6.3f);
        }

        // from fog cave to entrance
        else if (rb.position.x >= 4.1f && rb.position.x <= 4.8f && rb.position.y >= 2) {
            transform.position = new Vector2(-74, -82);
            Snow.GetComponent<Particles>().enabled = true; // enable snow particle effect
        }

        // from fog entrance to cave
        else if (rb.position.x >= -74.5f && rb.position.x <= -73.5f && rb.position.y <= -84) {
            transform.position = new Vector2(4.4f, 1);
            Snow.GetComponent<Particles>().enabled = false; // disable snow particle effect
            int numOfObject = Snow.GetComponent<Particles>().numOfObjects;
            foreach(GameObject snowPiece in SnowVariant) {
                Destroy(snowPiece);
            }     
        }

        // from ice cave to end
        else if (rb.position.x >= 234 && rb.position.x <= 235 && rb.position.y >= -25) {
            transform.position = new Vector2(69, -240);
            Snow.GetComponent<Particles>().enabled = true; // enable snow particle effect
        }

        // from end to ice cave
        else if (rb.position.x >= 68 && rb.position.x <= 71f && rb.position.y <= -242) {
            transform.position = new Vector2(234.5f,-26);
            Snow.GetComponent<Particles>().enabled = false; // disable snow particle effect
            int numOfObject = Snow.GetComponent<Particles>().numOfObjects;
            foreach (GameObject snowPiece in SnowVariant) {
                Destroy(snowPiece);
            }
        }

        // from end to End Level
        else if (rb.position.x >= 69 && rb.position.x <= 71f && rb.position.y >= -204) {
            SceneManager.LoadScene(6); //Load Ronnies Start Scene
        }
    }

    // Seperate Update function with the focus of the player is on ice
    void FixedUpdate() {
        try {
            // bool value to signal player is on ice
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
            active = false;
            rb.velocity = new Vector2(0, 0);
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
        }

        timer = false; // timer exited
    }
}

