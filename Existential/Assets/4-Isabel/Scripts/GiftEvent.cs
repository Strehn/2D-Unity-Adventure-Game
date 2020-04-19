/* Written by Isabel Hinkle
 * Script to find which inventory object spawned and check the requirements to spawn a key
 * once the key is picked up the player can move to the next scene
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiftEvent : MonoBehaviour{
    public GameObject Key;
    public bool chalice;
    public bool necklace;
    public bool vase;
    public bool invItemPresent;

    public void Start(){
        chalice = GameObject.Find("Chalice(Clone)").GetComponent<GiftInvItem>().giftedItem;
        necklace = GameObject.Find("Necklace(Clone)").GetComponent<GiftInvItem>().giftedItem;
        vase = GameObject.Find("Vase(Clone)").GetComponent<GiftInvItem>().giftedItem;

        // This section checks to make sure we only set invItemPresent to true if there is only one object that isn't false
        if((chalice == true) && (necklace == false) && (vase == false)){
            invItemPresent = true;
        }
        else if((chalice == false) && (necklace == true) && (vase == false)){
            invItemPresent = true;
        }
        else if((chalice == false) && (necklace == false) && (vase != true)){
            invItemPresent = true;
        }
    }

    // Function to instantiate one key based on a bool value
    public void InstantiateKey(){
        if(invItemPresent == true){
            GameObject i = Instantiate(Key) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(14, 5.5f);
        }
        else{
            Debug.Log("Please gift the item before clicking this button.");
        }
    }
}
