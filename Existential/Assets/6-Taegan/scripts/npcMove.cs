using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* npcMove.cs
* A script to move an NPC Player in random directions
* TW
*/
public class npcMove : MonoBehaviour {
    public float range;  // Variable for speed movement (should be about 2)
    private Rigidbody2D rb;  // Rigidbody2D for 2D character movement
    public bool timer = false; // timer for movment of player
    GameObject Snow; // stores the snow
    GameObject MainPlayer; // Game Object for the main player, used to stop for dialouge
    private Vector2[] moveDirections; //an array of Vector2 directions
    Sound s1; // static instantiation of the Sound Class
    bool collision; // used to detect collisions with boundaries


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components
        MainPlayer = GameObject.FindGameObjectWithTag("Player");
        moveDirections = new Vector2[] { Vector2.right, Vector2.left, Vector2.up, Vector2.down, Vector2.zero, Vector2.zero };
        s1 = new Sound();
        AudioClip returnedFromScript = s1.WalkSound(); //grab Audio from Sound Script
        GetComponent<AudioSource>().clip = s1.WalkSound(); //set the clip on this component
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes

        //run only 1 coroutine at a time, managed with the timer boolean, and dont run if the player is in dialouge
        if (timer == false && MainPlayer.GetComponent<PlayerControllerRigidBody>().canMove == true) {
            StartCoroutine(Countdown()); //timer function to move the player
        }
    }

    //function to count time before calling the on trigger exit
    private IEnumerator Countdown() {

        timer = true; //Set the Countdown as active

        //Choose a random movement direction
        int currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));

        //Start the Audio
        GetComponent<AudioSource>().Play();

        //If the player is not moving stop the audio
        if (moveDirections[currentMoveDirection] == Vector2.zero) {
            GetComponent<AudioSource>().Stop();
        }

        //time variables and loop
        float duration = 3f; // wait 3 seconds before change of path                      
        float normalizedTime = 0;
        while (normalizedTime <= 1f) {

            // if the player collides with an object, do not move the player
            if (collision != true) {
                //move player in the randon direction chosen.
                rb.MovePosition(rb.position += moveDirections[currentMoveDirection] * Time.deltaTime * range);
            }
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }

        //reset collision and timer variables to allow for a newCoroutine
        collision = false;
        timer = false;    
    }

    //if the player colides with a wall, allow for movement
    void OnCollisionEnter2D(Collision2D coll)
    {
        collision = true;
        Debug.Log("Collision");
        rb.velocity = new Vector2(0, 0);
        GetComponent<AudioSource>().Stop();
    }
}
