using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This script can be attached to the button in the pause menu for the main menu. It will    
    open the main menu.  
*/

public class OpenMainScript : MonoBehaviour{
    // Start is called before the first frame update
    void goMainMenu(){
	int ContinueActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }

    
}