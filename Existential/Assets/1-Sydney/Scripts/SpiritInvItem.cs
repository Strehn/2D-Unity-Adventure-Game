/*

    This is for the floating collectables in the forest levels so they are added to the inventory.
    Based on Tori's scripts for items
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritInvItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "SpiritOrb";
        }
    }
    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnDrop()
    {
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
