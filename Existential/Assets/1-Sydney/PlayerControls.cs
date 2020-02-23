using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static Vector2 topRight;


    // Start is called before the first frame update
    void Start()
    {
        // Convert screen's pixel coordinate into game's coordinate 
       bottomLeft = Camera.main.ScreenToWorldPoint (new Vector2(0,0));
       topRight = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
	// ----- PLAYER MOVEMENT -----
	// if Input.GetKey("w")){
	//PlayerMovement

	// if Input.GetKey("s")){
	//PlayerMovement

	// if Input.GetKey("a")){
	//PlayerMovement

	// if Input.GetKey("d")){
	//PlayerMovement

	//Call Scripts
		//PlayerMovement
		//MenuOpen/Close
		//InventoryOpen/Close

        // check for user input
		//mouse input
			// if object is available to pickup
		//keyboard press
			//inventory scene
			//menu scene
			//escape button
    }
}
