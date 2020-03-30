/***********************
Implemented by Victoria Gehring
This script controls the inventory hud by managing the 
display on the game screen
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HudInventory : MonoBehaviour{
    public Inventory Inventory;

    // Start is called before the first frame update
    void Start(){
        Inventory.ItemAdded += Inventory_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e){
        Transform inventoryPanel = transform.Find("Inventory");
        
        foreach(Transform itemSlot in inventoryPanel){

            Transform imageTransform = itemSlot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            
            if (!image.enabled){ 
                image.enabled = true;
                image.sprite = e.Item.Image;
                itemDragHandler.Item = e.Item;
                Debug.Log(e.Item);
                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e){
        Transform inventoryPanel = transform.Find("Inventory");
        foreach (Transform itemSlot in inventoryPanel){
            Transform imageTransform = itemSlot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            Debug.Log("item drag handler item");
            Debug.Log(itemDragHandler.Item);
            Debug.Log("e.item");
            Debug.Log(e.Item);
            if (itemDragHandler.Item.Equals(e.Item)){
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
            }
           
        }
    }

}
