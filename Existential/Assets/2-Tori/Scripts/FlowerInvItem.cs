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

    public virtual void OnPickup(){
        gameObject.SetActive(false);
    }

    public void OnDrop(){
        // Debug.Log("[FlowerInvItem] ON DROP");
        /* DEPRECATED
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000)){
            Debug.Log("[FlowerInvItem] game object = ");
            Debug.Log(gameObject);
            //gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
        */
        gameObject.SetActive(true);

    }

}
