using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelStuff : MonoBehaviour{

    // Start is called before the first frame update
    void Main(){
        int inventoryNumber;
        inventoryNumber = UnityEngine.Random.Range(1,4);  // generate a random number corresp to inventory item to drop

        Console.WriteLine("Drop this inventory item: " + inventoryNumber);

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
        /*
        for(int i = 0; i < 2; i++){
            float yCoord = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0,0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float xCoord = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Vector2 spawnInvItem = new Vector2(xCoord, yCoord);
            Instantiate(item, spawnInvItem);
        }
        */
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
