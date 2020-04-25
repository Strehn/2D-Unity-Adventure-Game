/* Created by Isabel
 * Inspo: https://www.youtube.com/watch?v=E7gmylDS1C4
 * Script to spawn 1 of 3 inventory objects on screen based on a random number between 1-3
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsabelLevel : MonoBehaviour{
    public GameObject Chalice;
    public GameObject Necklace;
    public GameObject Vase;
    public GameObject mainCharacter;

    void Start(){
        SaySomething();
        WelcomeMessage();
        int inventoryNumber = UnityEngine.Random.Range(1, 4);  // Generate a random inventory item to spawn on screen
        //giftedItemBool = GII.giftedItem;
        // Debug.Log(inventoryNumber); testing purposes

        if(inventoryNumber == 1){
            // drop inventoryObject 1 on scene (belonging to Dia1)
            GameObject i = Instantiate(Chalice) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(0, -6.18f);
        }
        else if(inventoryNumber == 2){
            // drop inventoryObject 2 on scene (belonging to Dia2)
            GameObject i = Instantiate(Necklace) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(0, -6.18f);
        }
        else if(inventoryNumber == 3){
            // drop inventoryObject 3 on scene (belonging to Dia3)
            GameObject i = Instantiate(Vase) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(0, -6.18f);
        }
        
    }

    // This function is utilized in the dynamic binding for the child class
    public virtual void WelcomeMessage(){
        Debug.Log("Welcome to level 2! This function is utilized in dynamic binding and should not appear in the console!");
    }
    // This function is utilized in the static binding for the parent/child class
    public void SaySomething(){
        Debug.Log("Welcome to level 2! Created by Isabel Hinkle");
    }
}

