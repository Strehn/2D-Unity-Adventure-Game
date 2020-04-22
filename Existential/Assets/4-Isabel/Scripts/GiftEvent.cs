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
    public bool invItemPresent;
    public bool onlyOneItem = false;

    public void Start(){
        invItemPresent = false;
    }

    public void Update(){
        // This section checks to make sure we only set invItemPresent to true if there is only one object that is found
        if( GameObject.Find("Chalice(Clone)") ){
            invItemPresent = true;
            onlyOneItem = true;
        }
        else if( GameObject.Find("Necklace(Clone)") ){
            invItemPresent = true;
            onlyOneItem = true;
        }
        else if( GameObject.Find("Vase(Clone)") ){
            invItemPresent = true;
            onlyOneItem = true;
        }
        else{
            invItemPresent = false;
        }
    }

    // Function to instantiate one key based on a bool value
    public void InstantiateKey(){
        if(invItemPresent && onlyOneItem){  // invItemPresent can only be true or false, so this is where singleton is executed
            Debug.Log("Thank you for the gift. There is a key waiting for you to get to the next level.");
            GameObject i = Instantiate(Key) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(14, 5.5f);
        }
        else{
            Debug.Log("Please gift the item before clicking this button.");
        }
    }
}
