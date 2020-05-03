/* Created by Sam Spalding, edited by Sydney Petrehn for level
 * Script to display canvas of "BC Mode" if the B key is pressed
 * Allows for turning off the minimap
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FBCMode : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject helpMenuUI;

    // Update is called once per frame
    void Update()
    {

        // If player hits B key...
        if (Input.GetKeyDown(KeyCode.B))
        {
            // Debug.Log("B key was pressed");

            // ...when game is in the pause menu, then it will resume
            if (gameIsPaused)
            {

                Resume();
            }
            // ...when game is playing in the scene, then it will bring up the BC mode
            else
            {

                BC();
            }
        }
    }

    // Function to pause time of game and bring up pause menu to screen
    public void BC()
    {

        helpMenuUI.SetActive(true);
        Time.timeScale = 0f; // Stop time from moving in-game
        gameIsPaused = true;
        
    }

    // Function to resume playing the game
    public void Resume()
    {

        helpMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume time in-game
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {

        helpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {

        GameObject mainChar = GameObject.Find("MainCharacter");
        Vector2 EndLocation = new Vector2(23, 15);
        Vector2 OrbLocation = new Vector2(21, 15);
        GameObject SpiritOrb1 = GameObject.Find("SpiritOrb");
        GameObject SpiritOrb2 = GameObject.Find("SpiritOrb (1)");
        GameObject SpiritOrb3 = GameObject.Find("SpiritOrb (2)");
        GameObject SpiritOrb4 = GameObject.Find("SpiritOrb (3)");

        //Move to end location
        mainChar.transform.position = EndLocation;

        //Move orbs to end location
        SpiritOrb1.transform.position = OrbLocation;
        SpiritOrb2.transform.position = OrbLocation;
        SpiritOrb3.transform.position = OrbLocation;
        SpiritOrb4.transform.position = OrbLocation;

        helpMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Minimap()
    {
        // Find the object that is hidden
        GameObject Minimap = GameObject.Find("Minimap");
        // Turn on the object
        Minimap.SetActive(false);

        helpMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }
}
