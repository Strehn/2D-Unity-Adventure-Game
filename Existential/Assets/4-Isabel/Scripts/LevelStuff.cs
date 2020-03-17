using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelStuff : MonoBehaviour{
    public GameObject Chalice;

    // Start is called before the first frame update
    void Main(){
        int inventoryNumber;
        inventoryNumber = UnityEngine.Random.Range(1,4);  // generate a random number corresp to inventory item to drop

        /*if(inventoryNumber == 1){
            // drop inventoryObject 1 on scene (belonging to Dia1)

        }
        else if(inventoryNumber == 2){
            // drop inventoryObject 2 on scene (belonging to Dia2)

        }
        else if(inventoryNumber == 3){
            // drop inventoryObject 3 on scene (belonging to Dia3)

        }*/
    }

    void Start(){
        Instantiate(Chalice, new Vector2(0f, -6.18f), transform.rotation);
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
