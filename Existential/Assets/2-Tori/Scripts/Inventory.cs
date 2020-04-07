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
    // This is private so that it is only instantiated once (no conflicting inventories)
    private List<IInventoryItem> inventoryList = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public void Start()
    {
        Debug.Log("inventory");
    }
  
    public void AddItem(IInventoryItem item){
        Debug.Log(inventoryList);
        Debug.Log(inventoryList.Count);
        if(inventoryList.Count < MAXITEMS){
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled){
                collider.enabled = false;
                inventoryList.Add(item);
                Debug.Log("[Inventory] Add Item");
                item.OnPickup();
                if(ItemAdded != null){
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(IInventoryItem item){
        Debug.Log("[Inventory] Item being removed:" + item);
        if(inventoryList.Contains(item)){
            //inventoryList.Remove(item);
            Debug.Log("[Inventory] List contains item");
            bool retval = inventoryList.Remove(item);
            Debug.Log(retval);
            // item.OnDrop();

            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if(collider != null){
                collider.enabled = true;
            }

            if(ItemRemoved != null){
                Debug.Log("[Inventory] Sending this: " + this + "and this item: " + item);
                ItemRemoved(this, new InventoryEventArgs(item));
            }
            item.OnDrop();
            inventoryList.Remove(item);
            
        }
    }

}


