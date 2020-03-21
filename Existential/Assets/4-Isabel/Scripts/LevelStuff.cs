// Created by Isabel
// Inspo: https://www.youtube.com/watch?v=E7gmylDS1C4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStuff : MonoBehaviour{
    public GameObject Chalice;
    public GameObject Necklace;
    public GameObject Vase;
    public GameObject newObject;  // for Sam

    void Start(){
        int inventoryNumber = UnityEngine.Random.Range(1, 4);  // Generate a random inventory item to spawn on screen
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
        /* For Sam testing purposes:
        else{
            // drop random object on screen? This would initiate an error because in my scene I do 
            // not have another gameObject and the number should be between 1-3 - so this could be a boundary test.

            GameObject i = Instantiate(newObject) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(0, -6.18f);
        }
        */
    }

    void Update(){
        /* For Sam testing purposes:
            GameObject i = Instantiate(Chalice) as GameObject;
            i.SetActive(true);
            i.transform.position = new Vector2(0, -6.18f);
        */
    }
}

/* For Sam: 
    Boundary: Instantiating an object that doesn't exist
    Boundary: Testing which speed it takes for the player to be able to run off screen through tilemap boundary
    Stress: Instantiating too many objects on screen - the commented code in the update function
*/
