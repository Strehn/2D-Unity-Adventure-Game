//Created by Sam Spalding

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    //Function for QuitGameButton that will quit out of the game
    public void QuitGame() {

        Debug.Log("QUIT");
        Application.Quit();
    }
}
