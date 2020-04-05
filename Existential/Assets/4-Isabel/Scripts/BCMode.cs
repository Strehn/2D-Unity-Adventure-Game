// Created by Sam Spalding, edited by Isabel Hinkle for level

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BCMode : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject helpMenuUI;

    // Update is called once per frame
    void Update() {

        // If player hits B key...
        if (Input.GetKeyDown(KeyCode.B)) {
            Debug.Log("B key was pressed");

            // ...when game is in the pause menu, then it will resume
            if (gameIsPaused) {

                Resume();
            }
            // ...when game is playing in the scene, then it will bring up the BC mode
            else {

                BC();
            }
        }
    }

    // Function to pause time of game and bring up pause menu to screen
    public void BC() {  

        helpMenuUI.SetActive(true);
        Time.timeScale = 0f; // Stop time from moving in-game
        gameIsPaused = true;
    }

    // Function to resume playing the game
    public void Resume() {

        helpMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time in-game
        gameIsPaused = false;
    }

    public void LoadMainMenu() {

        helpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
