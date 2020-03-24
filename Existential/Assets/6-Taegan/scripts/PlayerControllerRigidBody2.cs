using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Isabel -- Recrafted by Taegan

public class PlayerControllerRigidBody2 : MonoBehaviour
{
    public float speed;  // Variable for speed movement (should be about 2)
    private Rigidbody2D rb;  // Rigidbody2D for 2D character movement
    private Vector2 moveVelocity;  // Vector for how fast the player will move on screen
    public bool active = false;
    public bool activeDown = false; // moves player down once going through a door
    public bool activeUp = false; //moves player up once going through a door
    public bool timer = false; // timer for movment of player
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from the character components 

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes
        moveVelocity = moveInput.normalized * speed;  // Move according to speed
        if (rb.velocity == new Vector2(0, 0))
        {
            active = false;
        }

        // Move as long as the arrow keys are pressed
        if (rb.position.x >= 192.2f && rb.position.x <= 193.8 && rb.position.y >= 3.1f)
        {
            //temp respawn to beginning of level, will add more.
            transform.position = new Vector2(46, -28);

        }
        else if (rb.position.x >= 46 && rb.position.x <= 48 && rb.position.y >= -26)
        {
            
            //temp respawn to beginning of level, will add more.
            transform.position = new Vector2(192.6f, 2f);
            
       
        }
        else
        {
           // Debug.Log("Position x:" + rb.position.x + "\nPosition y:" + rb.position.y );
        }
        

    }


    void FixedUpdate()
    {

        bool activeButton = GameObject.Find("Ice").GetComponent<iceMove>().activeButton;
        if (activeButton == true)
        {


            if (Input.GetKeyDown(KeyCode.LeftArrow) && active == false)
            {
                rb.isKinematic = false;
                rb.velocity = new Vector2(-speed, 0);
                active = true;
                //rb.angularDrag = 1;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && active == false)
            {
                rb.isKinematic = false;
                rb.velocity = new Vector2(speed, 0);
                active = true;
                //rb.angularDrag = 2;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && active == false)
            {
                rb.isKinematic = false;
                rb.velocity = new Vector2(0, speed);
                active = true;

                //rb.angularDrag = 3;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && active == false)
            {
                rb.isKinematic = false;
                rb.velocity = new Vector2(0, -speed);
                active = true;
                //rb.angularDrag = 4;

            }
            if (active == false)
            {
                rb.isKinematic = false;
                rb.angularDrag = 0;
                rb.velocity = new Vector2(0,0);
            }
        }
        else
        {
            active = false;
            rb.isKinematic = false;
            rb.angularDrag = 0;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
        }

    


    }
        //Changes direction of the ball based on its speed and position on the paddle
        void OnCollisionEnter2D(Collision2D coll)
        {

            active = false;
            Vector2 vel;
            vel.x = 0;
            vel.y = 0;
            rb.angularDrag = 0.5f;
            rb.velocity = vel;
        }




    private IEnumerator Countdown()
    {
        float duration = 2f; // 3 seconds you can change this 
                               //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        timer = true;
        activeDown = false;
        activeUp = false;
    }

}

