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
    private GameObject chalice; 
    private GameObject necklace;
    private GameObject vase; 

    public bool invItemPresent;
    public bool instantiateKey;

    public void Start(){
        instantiateKey = true;
    }

    public void Update(){
        chalice = GameObject.Find("Chalice(Clone)");
        necklace = GameObject.Find("Necklace(Clone)");
        vase = GameObject.Find("Vase(Clone)");

        FindItem();
    }

    public void FindItem(){

        // This section checks to make sure we only set invItemPresent to true if there is only one object that is found
        if(chalice != null){
            invItemPresent = true;
        }
        else if(necklace != null){
            invItemPresent = true;
        }
        else if(vase != null){
            invItemPresent = true;
        }
        else{
            invItemPresent = false;
        }
    }

    // Function to instantiate one key based on a bool value
    public void InstantiateKey(){
        if(invItemPresent && instantiateKey){  // invItemPresent can only be true or false, so this is where singleton is executed
            Debug.Log("Thank you for the gift. There is a key waiting for you to get to the next level.");
            GameObject i = Instantiate(Key) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(14, 5.5f);
            invItemPresent = false;
            instantiateKey = false;  // Set this bool to false to ensure only one object can be "gifted" when Gift Exchange Complete is clicked
        }
        else{
            Debug.Log("Please gift the item before clicking this button.");
        }
        
    }
}
