using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsabelHelp : MonoBehaviour{
    public void BCHelp (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
