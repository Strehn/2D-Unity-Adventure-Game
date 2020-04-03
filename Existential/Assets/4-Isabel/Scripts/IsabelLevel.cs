// Created by Isabel
// Inspo: https://www.youtube.com/watch?v=E7gmylDS1C4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsabelLevel : MonoBehaviour{
    public GameObject Chalice;
    public GameObject Necklace;
    public GameObject Vase;

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
    }
}

