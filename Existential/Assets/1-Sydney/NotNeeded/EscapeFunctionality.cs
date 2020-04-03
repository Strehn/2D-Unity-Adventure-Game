using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script can be attached to any button that needs to exit the game and can be used 
    to check for user input to exit the game.  
*/
 
public class ExitFunctionality : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey("escape")){
		Application.Quit();
	 }
    }
}
