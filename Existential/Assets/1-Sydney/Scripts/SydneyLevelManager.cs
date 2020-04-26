using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SydneyLevelManager : MonoBehaviour
{
    static public int MAXITEMS = 8;
    public Camera cam;
    public GameObject mainChar;
    // Need this to know how many inventory items i have
    public List<IInventoryItem> inventoryList = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded;

    public GameObject mainCharacter;


    // Handles scene transitions for Forest to NightForest
    // Handles scene transitions for NightForest to next Scene
    public void Update()
    {
        Scene scene;
        Transform transform = mainCharacter.GetComponent<Transform>();
        Vector2 position = transform.position;
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 3)
        {
            if ((position.x > 19) && (position.y < 16) && (inventoryList.Count == 4))
            {
                SceneManager.LoadScene(4);
            }
        }
        if (scene.buildIndex == 4)
        {
            if (position.x >= 4.5 && position.y >= -5)
            {
                SceneManager.LoadScene(5);
            }
        }


    }

    // Based on Tori's inventory script but i needed my own script in order to handle scene management
        public void AddItem(IInventoryItem item)
        {
            // Debug.Log(inventoryList);
            // Debug.Log(inventoryList.Count);
            if (inventoryList.Count < MAXITEMS)
            {
                Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
                if (collider.enabled)
                {
                    collider.enabled = false;
                    inventoryList.Add(item);
                    // Debug.Log("[Inventory] Add Item");
                    item.OnPickup();
                    // Tell Hud to add the item
                    if (ItemAdded != null)
                    {
                        ItemAdded(this, new InventoryEventArgs(item));
                    }
                }
            }
        }

        // I have no need to remove items on my level

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
