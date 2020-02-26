using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TGExitInvMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: change depending what level they came from
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey("escape")){
            Application.Quit();
        }
  
    }
}
