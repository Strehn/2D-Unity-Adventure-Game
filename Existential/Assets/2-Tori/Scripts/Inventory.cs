/***********************
Implemented by Victoria Gehring
This script defines the max inventory items and allows items
to be selected by using 2D colliders and calling InventoryEventArgs 
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour{
    public const int MAXITEMS = 8;
    public Camera cam;
    private List<IInventoryItem> inventoryList = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
  
    public void AddItem(IInventoryItem item){
        if(inventoryList.Count < MAXITEMS){
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled){
                collider.enabled = false;
                inventoryList.Add(item);
                Debug.Log("Add Item");
                item.OnPickup();
                if(ItemAdded != null){
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(IInventoryItem item){
        if (inventoryList.Contains(item)){
            inventoryList.Remove(item);
            //item.OnDrop();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if(collider != null){
                collider.enabled = true;
            }

            if(ItemRemoved != null){
                ItemRemoved(this, new InventoryEventArgs(item));
            }

        }
    }

}


