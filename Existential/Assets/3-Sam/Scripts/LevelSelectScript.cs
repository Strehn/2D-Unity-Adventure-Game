//Created by Sam Spalding

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {

    public Button[] levelButtons;

    /*
    void Start() {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++) {

            if (i + 1 > levelReached) {

                levelButtons[i].interactable = false;
            }
        }
    }
    */

    //The following functions are for the LevelxButtons in the LevelSelectMenu
    //Each function loads their corresponding level scene

    public void PlayLevel1() {

        SceneManager.LoadScene("SamScene");
    }

    public void PlayLevel2() {

        SceneManager.LoadScene("Isabel Level");
    }
    public void PlayLevel3() {

        SceneManager.LoadScene("SydneyForestScene");
    }
    public void PlayLevel4() {

        SceneManager.LoadScene("ToriScene");
    }
    public void PlayLevel5() {

        SceneManager.LoadScene("TaeganScene");
    }
    public void PlayLevel6() {

        SceneManager.LoadScene("RonnieScene");
    }
}
