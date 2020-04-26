/* Written by Victoria Gehring, modified by Isabel Hinkle
 * Script to categorize certain inventory objects in my level as "giftable" objects
 * Takes a game instance and image to create a giftable object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftableInventory : MonoBehaviour, IInventoryItem{
    public string Name{
        get{
            return "InventoryObject";
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
