using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SydneyLevelManager : MonoBehaviour
{
    static public int MAXITEMS = 8;
    public Camera cam;
    // Need this to know how many inventory items i have
    //Potential here for pair programming: Get the number of inventory items from the inventory to actually implement this
    public int inventoryList = 4;
    public GameObject mainChar = GameObject.Find("MainCharacter");

    // Handles scene transitions for Forest to NightForest
    // Handles scene transitions for NightForest to next Scene
    public void Update()
    {
        Scene scene;
        Transform transform = mainChar.GetComponent<Transform>();
        Vector2 position = transform.position;
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 3)
        {
            if ((position.x <= 19) && (position.y >= 16.5) && (inventoryList == 4))
            {
                SceneManager.LoadScene(8);
            }
        }
        if (scene.buildIndex == 8)
        {
            mainChar = GameObject.Find("PlayerCharacter");
            transform = mainChar.GetComponent<Transform>();
            position = transform.position;
            if (position.x >= 13 && position.y <= 6.9)
            {
                SceneManager.LoadScene(5);
            }
        }


    }

        // This function is utilized in the dynamic binding for the child class
        public virtual void WelcomeMessage()
    {
        Debug.Log("Welcome to level 3! This function is utilized in dynamic binding and should not appear in the console!");
    }
    // This function is utilized in the static binding for the parent/child class
    public void Message()
    {
        Debug.Log("All of the inventory Items have been collected");
    }
}
