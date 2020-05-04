using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This is the script for any environmental sprites. It allows the sprites
    to move randomly.
*/

public class spriteMovement : MonoBehaviour{
    // check for movement and apply it to player object
    public float speed;                //Floating point variable to store the sprite's movement speed.

    private Vector2 minWalkPoint = new Vector2(2, 7);
    private Vector2 maxWalkPoint = new Vector2(5, 13);
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    private int WalkDirection;

    // used in random spawning
    public GameObject prefab;

    //Use this for initialization
    void Start(){
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

        //Adds how long and when the npc will move
        waitCounter = waitTime;
        walkCounter = walkTime;

        //Randomly choose direction
        ChooseDirection();

    }

    // update is called once per frame
    void Update(){
        //vary between walking and waiting
        if(isWalking){
            walkCounter -= Time.deltaTime;


            switch(WalkDirection){
                case 0:
                    //move upward
                    rb2d.velocity = new Vector2(0, speed);
                    if(transform.position.y > maxWalkPoint.y){
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 1:
                    // move right
                    rb2d.velocity = new Vector2(speed, 0);
                    if (transform.position.x > maxWalkPoint.x){
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 2:
                    // move down
                    rb2d.velocity = new Vector2(0, -speed);
                    if (transform.position.y < minWalkPoint.y){
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    // move left
                    rb2d.velocity = new Vector2(-speed, 0);
                    if (transform.position.x < minWalkPoint.x){
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter < 0){
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else{
            waitCounter -= Time.deltaTime;

            rb2d.velocity = Vector2.zero;
            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection(){
        // will always be 0,  1, 2, or 3 never 4
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
