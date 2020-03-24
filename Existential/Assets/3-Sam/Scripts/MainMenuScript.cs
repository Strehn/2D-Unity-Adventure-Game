using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour{

    //Function for NewGameButton
    public void PlayNewGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Function for QuitGameButton
    public void QuitGame() {

        Debug.Log("QUIT");
        Application.Quit();
    }
}
