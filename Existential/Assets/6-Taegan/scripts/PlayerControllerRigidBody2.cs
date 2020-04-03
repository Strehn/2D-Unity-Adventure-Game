using System.Collections;
using UnityEngine;
using System;

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
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components 
    }

    // Update is called once per frame
    void Update() {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes
        moveVelocity = moveInput.normalized * speed;  // Move according to speed


        // Causes Problems with test
        //if (active == false)
        //{
        //    rb.velocity == new Vector2(0, 0);
        //}


        // If the player is not moving set active to false
        if (rb.velocity == new Vector2(0, 0)) {
            active = false;
        }

        // if the player is in front of a door way, transfer him to the next cave
        // from ice cave to fog cave
        if (rb.position.x >= 192.2f && rb.position.x <= 193.8 && rb.position.y >= 3.1f) {
            transform.position = new Vector2(46, -28);
        }

        // from fog cave to ice cave
        else if (rb.position.x >= 46 && rb.position.x <= 48 && rb.position.y >= -26) {
            transform.position = new Vector2(192.6f, 2f);
        }
    }

    // Seperate Update function with the focus of the player is on ice
    void FixedUpdate() {


        try
        {
            // bool value to signal player is on ice
            activeButton = GameObject.Find("Ice").GetComponent<iceMove>().activeButton;
        }
        catch (Exception e)
        {
            Debug.Log("Exception Thrown: " + e);
        }
        // code to make the player move on ice
        if (activeButton == true) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && active == false) {
                rb.velocity = new Vector2(-speed, 0);
                active = true;
                
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && active == false) {
                rb.velocity = new Vector2(speed, 0);
                active = true;
              
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && active == false) {
                rb.velocity = new Vector2(0, speed);
                active = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && active == false) {
                rb.velocity = new Vector2(0, -speed);
                active = true;
            }
            if (timer == false && active == true) {
                StartCoroutine(Countdown());
            }
        }
        else {
            // code to make the player move normally
            active = false;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }

    //if the player colides with a wall, allow for movement
    void OnCollisionEnter2D(Collision2D coll) {
            active = false;
            rb.velocity = new Vector2(0, 0);
    }


    // Countdown to check if the player is moving in an uninteded manner
    private IEnumerator Countdown() {
        timer = true;
        float duration = 1f; // 1 second before checking velocity          
        float normalizedTime = 0;
        while (normalizedTime <= 1f) {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        // If player is not moving as the velocity should, stop the player
        if (Math.Abs(rb.velocity.x) != Math.Abs(speed) && rb.velocity.x != 0 && Math.Abs(rb.velocity.x) != Math.Abs(speed) && rb.velocity.y != 0) {
            active = false;
        }
        timer = false;
    }
}

