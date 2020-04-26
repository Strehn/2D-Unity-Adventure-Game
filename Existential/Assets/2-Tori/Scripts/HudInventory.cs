/***********************
Implemented by Victoria Gehring
This script controls the inventory hud by managing the 
display on the game screen
***********************/

/*
 * HUDINV PREFAB DOCUMENTATION
   Many games have a need for an inventory feature that is interactive and follows the player and camera.
* Purpose 
  In many Unity projects, an interactive UI inventory feature is needed. This provides a quick and easy way to get started.
* Features 
- Easily add items to the inventory by mousing over them 
- Easily remove items by dragging and dropping them
- 8 nice looking inventory slots that react to player actions
- Ability to see inventory in real time throughout gameplay
- Handles all inventory needs in a centralized location
- Real time updates
- Attached to the UI will follow the player and camera 
- Easy to use, Plug n play 
- Open Source code
* Usage 
- Import prefab into Assets/ under Prefabs/ folder
- Prefab can be found in this project under Assets/2-Tori/Assets/Resources/Prefabs/ 
* Remember 
- Also include Inventory Manager prefab and flower item prefabs in scene
- - - Prefab can be found in this project under Assets/2-Tori/Assets/Resources/Prefabs/ 
- Drag HUDINV.prefab in each scene 
- Drag InventoryManager.prefab in each scene
- Drag flower prefabs into scene
- Make sure to set camera and main character to the scripts
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// sealed means you cannot make a subclass of this class
public sealed class HudInventory : MonoBehaviour{
    public Inventory Inventory;
    // By making this instance private readonly other classes have to call getInstance
    // to access the hudInventory instance. It is thread safe due to the readonly.
    static private readonly HudInventory hudInventory = new HudInventory();
    // Private constructor ensures that only one gets instantiated
    private HudInventory() { }
    // This allows other classes who may need to use HudInventory to get see an instance
    public static HudInventory getInstance(){
        return hudInventory;  
    }
    // Start is called before the first frame update
    void Start(){

        Inventory.ItemAdded += Inventory_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e){
        Transform inventoryPanel = transform.Find("Inventory");
        // Look through all inventory slots
        foreach(Transform itemSlot in inventoryPanel){
            // Get the slot image component and itemDragHandler for one slot
            Transform imageTransform = itemSlot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            // if the slot has no image set the image and item for the drag handler
            if (!image.enabled){ 
                image.enabled = true;
                image.sprite = e.Item.Image;
                itemDragHandler.Item = e.Item;
                // Debug.Log("[HUD] adding " + e.Item);
                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e){
        Transform inventoryPanel = transform.Find("Inventory");
        bool foundslot = false;
        // Check inventory slot itemDragHandler script for item matching event item
        foreach (Transform itemSlot in inventoryPanel){
            Transform imageTransform = itemSlot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            // Debug.Log("[HUD] item drag handler item" + itemDragHandler.Item);
            // Debug.Log("[HUD] e.item" + e.Item);
            // Debug.Log("[HUD] itemslot " + itemSlot);
            // Empty the slot accordingly if they are the same
            if (itemDragHandler.Item != null && itemDragHandler.Item.Equals(e.Item)){
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                foundslot = true;
                break;
            }
            // once removed exit (this was important)
            if (foundslot){
                break;
            }
        }
    }

}
