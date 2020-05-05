/* Created by Isabel Hinkle to make a scene transition from town scene to the graveyard scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour{
    public GameObject mainCharacter; 

    public void Update(){
        Scene scene;
        Transform transform = mainCharacter.GetComponent<Transform>();
        Vector2 position = transform.position;
        scene = SceneManager.GetActiveScene();

        if(scene.buildIndex == 1){
            if(27.17 < position.x  && position.x < 27.67){
                if(position.y < -27.24 && position.y > -27.945){
                    SceneManager.LoadScene(2);
                }
            } 
        }
    }
}
