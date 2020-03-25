/***********************
Implemented by Victoria Gehring
This script is the interface for the inventory items
Inventory items will have a Name, Image, and Pickup function
It also creates the class InventoryEventArgs which will enable 
items to be selected.
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// All inventory item classes will be implemented using this interface
public interface IInventoryItem{
    string Name { get;  }
    Sprite Image { get;  }
    void OnPickup();
}

public class InventoryEventArgs: EventArgs{
    public InventoryEventArgs (IInventoryItem item){
        Item = item;
    }
    public IInventoryItem Item;
}
