/* Written by Isabel Hinkle
 * This script is a child class inheriting from the parent "IsabelLevel" 
 * in this script, dynamic binding is used to override the Update() function in the parent class
 * by printing out a simple statement showcasing the main character's name. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsabelLevelStatic : IsabelLevel{
    public void Update(){
        Scene scene;
        Transform transform = mainCharacter.GetComponent<Transform>();
        Vector2 position = transform.position;
        scene = SceneManager.GetActiveScene();

        if(scene.buildIndex == 2){
            if((position.x <= 25 && position.x >= 24) && (position.y <= 7 && position.y >= 6.7)){  // Check if we ever make it to the right position
                Debug.Log("You are in the right spot to move forward..");

                if(GameObject.FindWithTag("key") == false){  // Check that the key was picked up
                    Debug.Log("Moving on to next level.");
                    SceneManager.LoadScene(3);  // For now, move on to next scene if in the right position
                }
                else{
                    Debug.Log("You need to return the correct object to the spirit in order to advance.");
                }
            }   
        }
    }

    // This function is utilized in the static binding for the parent/child class
    public void SaySomething(){
        Debug.Log("This is the static type of the child class. This message should not appear in the console!");
    }
    // This function is utilized in the dynamic binding of the child class
    public override void WelcomeMessage(){
        Debug.Log("In this level your objective is to return an object to the correct spirit.");
    } 
}

