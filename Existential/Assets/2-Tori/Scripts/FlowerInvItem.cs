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
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
