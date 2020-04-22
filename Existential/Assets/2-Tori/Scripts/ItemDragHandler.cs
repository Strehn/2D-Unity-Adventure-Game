/***********************
Implemented by Victoria Gehring
This script tells what item is being dragged
so that the inventory scripts have an item 
reference for removal purposes
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler{
    // Get instance of item being dragged 
    public IInventoryItem Item { get; set; }

    public void OnDrag(PointerEventData eventData){
        // Debug.Log("[Item Drag Handler] On Drag ");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        // Debug.Log("[Item Drag Handler] On End Drag ");
        transform.localPosition = Vector2.zero;
    }

}
