using System.Collections;
using UnityEngine;

/*
* iceMove.cs
* Triggers a boolean value if the player is on ice, and error corrects if the player is not
* TW
*/
public class iceMove : MonoBehaviour {
    public bool activeButton = false; //boolean to set if the player is on ice
    public bool timer = false;

    //OBSERVER PATTERN -- This boundary observers the subject "player" and updates
    //If the player enters the ice area
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            activeButton = true;
            timer = false; // set timer to unavailable
            StartCoroutine(Countdown()); // call a timer to execute to allow player on ice without calling exit
            collision.GetComponent<PlayerControllerRigidBody>().enabled = false;
             collision.GetComponent<PlayerControllerRigidBody2>().enabled = true;
        }
    }

    //If the player exits the ice area
    private void OnTriggerExit2D(Collider2D collision) {
        if (timer == true) { //if player has been on the ice and moving onto ground
            collision.GetComponent<PlayerControllerRigidBody>().enabled = true;
             collision.GetComponent<PlayerControllerRigidBody2>().enabled = false;
            activeButton = false;
            timer = false;
        }  
    }

    //function to count time before calling the on trigger exit
    private IEnumerator Countdown() {
        float duration = 0.1f; // wait 0.1 seconds before exit can be called.                      
        float normalizedTime = 0;
        while (normalizedTime <= 1f) {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        timer = true;
    }
}