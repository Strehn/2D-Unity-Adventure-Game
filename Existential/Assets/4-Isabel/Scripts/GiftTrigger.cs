/* Script created by Isabel Hinkle to trigger a gift exchange when two characters collide
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftTrigger : MonoBehaviour{

    public GameObject giftButton;
    public int numNPCsInter = 0;
    private bool npcCollision = false;  // for interaction
    public bool npcCollision1 = false;  // for decorator


    void Start(){
        Debug.Log("You have collided with " + numNPCsInter + " NPC's.");
    }

    // Used to find out whether or not we are at an NPC and set the gift exchange button active
    void Update(){
        if(npcCollision == true){
            giftButton.SetActive(true);
        }
        else{
            giftButton.SetActive(false);
        }
    }

    // This function is used when entering an NPC collider
    public void OnTriggerEnter2D(Collider2D npcColl){
        if(npcColl.tag == "interObject"){
            //Debug.Log("Ran into NPC");
            npcCollision = true;
            npcCollision1 = true;
            numNPCsInter += 1;
        }
    }

    // This function is used when leaving an NPC collider
    public void OnTriggerExit2D(Collider2D npcColl){
        if (npcColl.tag == "interObject"){
            //Debug.Log("Moving away from NPC");
            npcCollision = false;
            npcCollision1 = false;
        }
    }
    // This function helps implement decorator
    public virtual int NPCInterTotal(){
        return numNPCsInter;
    }
}
