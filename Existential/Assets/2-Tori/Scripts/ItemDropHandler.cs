/***********************
Implemented by Victoria Gehring
This script notices when an item has been dragged
out of the inventory and starts the RemoveItem and
OnDrop functions
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler{

    public Inventory _Inventory;
    public Camera cam;

    // If mouse leaves the inventory then get item reference and call remove item/drop item functions
    public void OnDrop(PointerEventData eventData){
        RectTransform invPanel = transform as RectTransform;
        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)){
            // Debug.Log("[Item Drop Handler] Drop item");
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
            if(item != null){
                // Debug.Log(item);
                _Inventory.RemoveItem(item);
                item.OnDrop();   
            }
            
        }
    }
    
}
