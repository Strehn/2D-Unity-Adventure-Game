using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is used in the game to move the camera with the player movement. It is 	  
    attached to the main camera.  
*/

public class CameraController : MonoBehaviour{
    //store a reference to the player game object
    public GameObject player;        

    //store the distance between the player and camera
    private Vector3 offset;           

    // Use this for initialization
    void Start (){
        //Calculate and store the offset value by getting the distance between the 
        //player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate (){
        // Set the position of the camera's transform to be the same as the player's, but 
	// offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
