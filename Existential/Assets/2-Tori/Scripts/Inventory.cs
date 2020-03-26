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
    public event EventHandler<InventoryEventArgs> ItemDropped;
  
    public void AddItem(IInventoryItem item){
        if(inventoryList.Count < MAXITEMS){
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled){
                collider.enabled = false;
                inventoryList.Add(item);
                item.OnPickup();

                if(ItemAdded != null){
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void DropItem(IInventoryItem item)
    {
        inventoryList.Remove(item);
        item.OnDrop();

        if (ItemDropped != null)
        {
            ItemDropped(this, new InventoryEventArgs(item));
        }
    }

}


