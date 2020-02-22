using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will move the character forward, side to side
//or backwards depending on the keys WSAD.

//CharacterController needs to be attatched to main character
public class PlayerMovement : MonoBehaviour
{

    CharacterController characterController;

    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        { 
            // move direction directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
        }
        // Move the main character
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
