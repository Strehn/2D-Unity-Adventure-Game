using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public const int MAXITEMS = 8;
    public Camera cam;
    private List<IInventoryItem> inventoryList = new List<IInventoryItem>();
    public event EventHandler<InventoryEventArgs> ItemAdded;
  
    public void AddItem(IInventoryItem item)
    {
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

}


