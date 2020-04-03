// Created by Sam Spalding

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {

        // If player hits Escape key...
        if (Input.GetKeyDown(KeyCode.Escape)) {

            // ...when game is in the pause menu, then it will resume
            if (gameIsPaused) {

                Resume();
            }
            // ...when game is playing in the scene, then it will bring up the pause menu
            else {

                Pause();
            }
        }
    }

    // Function to pause time of game and bring up pause menu to screen
    public void Pause() {  

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Stop time from moving in-game
        gameIsPaused = true;
    }

    // Function to resume playing the game
    public void Resume() {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time in-game
        gameIsPaused = false;
    }

    public void LoadMainMenu() {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
