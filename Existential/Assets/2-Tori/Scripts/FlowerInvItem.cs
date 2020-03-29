/***********************
Implemented by Victoria Gehring
This script creates an inventory item of type flower
It consists of the image attached to the game object
It's name is "Flower" 
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInvItem : MonoBehaviour, IInventoryItem{
    public string Name{
        get{
            return "Flower";
        }
    }
    public Sprite _Image = null;

    public Sprite Image{
        get{
            return _Image;
        }
    }

    public void OnPickup(){
        gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            //gameObject.transform.position = hit.point;
        }
        
    }
    
}
