using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Always show the canvas so the player can see the button
        GetComponent<Canvas>.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToInventory(){
        Debug.Log("Going to inventory screen");
        // Will add scene later SceneManager.LoadScene();
    }
}
