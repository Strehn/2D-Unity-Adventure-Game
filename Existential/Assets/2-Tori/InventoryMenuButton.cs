using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryMenuButton : MonoBehaviour
{ 
    public void OnMouseDown()
    {
        Debug.Log("Going to inventory screen");
        SceneManager.LoadScene(2);
    }



}
