/*******************
 * Ronnie Keating - End game script
 * This is a script to end the game.
 * The entire screen is wiped and turned
 * to black once the player is done 
 * talking with the dragon and the grim
 * reaper. Confetti falls and returns to 
 * main menu.
 *
 * Instructions:
 * -Add this script to the gird. Note
 * that this only works with one dialogue scene
 ******************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollCredits : MonoBehaviour {

    private bool dialogueStart; // Check for dialouge has started
    private PlayerControllerRigidBody thePlayer; // Got this from Sam's script, where the player.canmove function exists
    private Particles ascript; //Particles scripts
    private Grid grid1; //grid component
    private bool returnToMenu; //if talking has happened, set returnToMenu to true
    private float time; //time for end scene
    void Start() {
        grid1 = GetComponent<Grid>(); //Initialized, kept forgetting this and lots of errors
        ascript = GetComponent<Particles>(); //also forgot this, so nothing was happening
        dialogueStart = false; //dialogue does not start right when player enters scene
        ascript.enabled = false; //disable Particles, not time to celebrate yet
        time = Time.time; //TIME.TIME, not TIME.DELTATIME
        thePlayer = FindObjectOfType<PlayerControllerRigidBody>(); //initialize, also from Sam's
        returnToMenu = false; //Not time yet
    }

    void Update() {
        //This means dialogue has started
        if(thePlayer.canMove == false && dialogueStart == false) {
            dialogueStart = true;
            Debug.Log("Yes");
        }
        //This means dialogue has ended, start end scene with confetti
        if(thePlayer.canMove == true && dialogueStart == true) {
            ascript.enabled = true;
            Destroy(dragonInstantiate.Dragon1);
            Destroy(grid1);
            time = Time.time + 5f;
            returnToMenu = true;
            thePlayer.canMove = false;
            Debug.Log("once");
        }
        //Timer before returning to menu
        if(time < Time.time && returnToMenu == true) {
            Debug.Log("End of game");
            SceneManager.LoadScene("Credits");
        }
    }

}