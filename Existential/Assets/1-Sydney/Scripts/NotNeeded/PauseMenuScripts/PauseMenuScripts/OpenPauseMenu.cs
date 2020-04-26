using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    This will be attached to every level to allow for the player to open the pause menu by
    Pressing the button 'p'.  
*/

public class OpenPauseMenu : MonoBehaviour{
    // save active scene
    int ContinueActiveScene = SceneManager.GetActiveScene().buildIndex;

    // Start is called before the first frame update
    void openPause(){
        SceneManager.LoadScene(3);
    }

    void closePause(){
	SceneManager.LoadScene(ContinueActiveScene);
    }
}
