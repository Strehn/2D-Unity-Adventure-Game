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

    // Function copied from Tori to change scenes based on position
    public void Update(){
        Scene scene;
        Transform transform = mainCharacter.GetComponent<Transform>();
        Vector2 position = transform.position;
        scene = SceneManager.GetActiveScene();

        if(scene.buildIndex == 2){  // If we are in my scene (just to make sure)
            if((position.x <= 25 && position.x >= 24) && (position.y <= 7 && position.y >= 6.7)){  // Check if at right position
                // if(inventoryObject was gifted to the right person){ TODO: Implement this
                    // then we can move inside this if statement
                //}
                SceneManager.LoadScene(3);  // For now, move on to next scene if in the right position
            }
        }
    }
}

