using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Isabel

public class PlayerControllerRigidBody : MonoBehaviour{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // Get input from Horizontal and Vertical Axes
        moveVelocity = moveInput.normalized * speed;  // Move according to speed
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);  // Move as long as the arrow keys are pressed
    }

}
