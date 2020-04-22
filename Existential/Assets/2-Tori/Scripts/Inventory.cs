/***********************
Implemented by Victoria Gehring
This script defines the max inventory items and allows items
to be selected by using 2D colliders and calling InventoryEventArgs 
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour{
    static public int MAXITEMS = 8;
    public Camera cam;
    public GameObject mainChar;
    // This is private so that it cannot be modified elsewhere 
    private List<IInventoryItem> inventoryList = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
  
    public void AddItem(IInventoryItem item){
        // Debug.Log(inventoryList);
        // Debug.Log(inventoryList.Count);
        if(inventoryList.Count < MAXITEMS){
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled){
                collider.enabled = false;
                inventoryList.Add(item);
                // Debug.Log("[Inventory] Add Item");
                item.OnPickup();
                // Tell Hud to add the item
                if(ItemAdded != null){
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(IInventoryItem item){
        // Debug.Log("[Inventory] Item being removed:" + item);
        if(inventoryList.Contains(item)){
            // Debug.Log("[Inventory] List contains item");
            bool retval = inventoryList.Remove(item);
            // Debug.Log(retval);
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if(collider != null){
                collider.enabled = true;
            }

            if(ItemRemoved != null){
                // Debug.Log("[Inventory] Sending this: " + this + "and this item: " + item);
                // Tell Hud to remove the item
                ItemRemoved(this, new InventoryEventArgs(item));
            }
            item.OnDrop();
            inventoryList.Remove(item);
            
        }
    }

    // Handles scene transitions for Meadow Level to Cave
    public void Update(){
        Scene scene;
        Transform transform = mainChar.GetComponent<Transform>();
        Vector2 position = transform.position;
        scene = SceneManager.GetActiveScene();
        if(scene.buildIndex == 4){
            if ((position.x > 42) && (position.y > 7) && (inventoryList.Count == 8)){
                SceneManager.LoadScene(7);
            }
        }
        if (scene.buildIndex == 7){
            if (position.x >= 4.5 && position.y >= -5){
                SceneManager.LoadScene(5);
            }
        }
       
       
    }

}


