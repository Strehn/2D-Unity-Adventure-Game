using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiftEvent : GiftInvItem{
    public GameObject mainCharacter;

    public void Start(){
        if(giftedItem == true){
            Debug.Log("Thanks for the gift.");
        }
        else{
            Debug.Log("Keep trying.");
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
                if(giftedItem == true){
                    Debug.Log("Moving on to next level.");
                    SceneManager.LoadScene(3);  // For now, move on to next scene if in the right position
                }
                else{
                    Debug.Log("You need to return the correct object to the spirit in order to advance.");
                }
                //SceneManager.LoadScene(3);  // For now, move on to next scene if in the right position
            }
        }
    }
}
