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

        SceneManager.LoadScene(1);
    }

    public void PlayLevel2() {

        SceneManager.LoadScene(2);
    }
    public void PlayLevel3() {

        SceneManager.LoadScene(3);
    }
    public void PlayLevel4() {

        SceneManager.LoadScene(4);
    }
    public void PlayLevel5() {

        SceneManager.LoadScene(5);
    }
    public void PlayLevel6() {

        SceneManager.LoadScene(6);
    }
}
