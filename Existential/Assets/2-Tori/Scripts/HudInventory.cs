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
        // TODO: disable all inventory images when dropped
        Inventory.ItemAdded += Inventory_ItemAdded;
        Inventory.ItemRemoved -= Inventory_ItemRemoved;
    }

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e){
        Transform inventoryPanel = transform.Find("Inventory");
        Debug.Log(inventoryPanel.GetComponent<GameObject>());
        foreach(Transform itemSlot in inventoryPanel){
            Transform imageTransform = itemSlot.GetChild(0);
            //Image image = itemSlot.GetChild(0).GetComponent<Image>();
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            Debug.Log(image);
            //Image image = itemSlot.GetComponent<Image>();
            if (!image.enabled){
                Debug.Log(image);
                image.enabled = true;
                image.sprite = e.Item.Image;
                itemDragHandler.Item = e.Item;
                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        Debug.Log(inventoryPanel.GetComponent<GameObject>());
        foreach (Transform itemSlot in inventoryPanel)
        {
            Transform imageTransform = itemSlot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            Debug.Log(image);

            if (itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
            }
            //Image image = itemSlot.GetComponent<Image>();
            /*
            if (image.enabled)
            {
                Debug.Log(image);
                image.enabled = false;
                //image.sprite = e.Item.Image;
                break;
            }
            */
        }
    }

    // Update is called once per frame
    void Update(){
        //Inventory.ItemAdded += Inventory_ItemAdded;
    }
}
