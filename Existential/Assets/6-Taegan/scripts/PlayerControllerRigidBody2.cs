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


    }
    

    void FixedUpdate()
    {
        
        bool activeButton = GameObject.Find("Ice").GetComponent<iceMove>().activeButton;
        if (activeButton == true) {
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
                rb.velocity = new Vector2(0,-speed);
                active = true;
                //rb.angularDrag = 4;
            }
        }

        else {
            active = false;
            rb.isKinematic = false;
            rb.angularDrag = 0;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);  // Move as long as the arrow keys are pressed}
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

}
