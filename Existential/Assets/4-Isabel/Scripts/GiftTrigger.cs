/* Script created by Isabel Hinkle to trigger a gift exchange when two characters collide
   WILL BE DEPRECATED
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftTrigger : MonoBehaviour{

    public GameObject giftButton;

    private bool npcCollision = false;

     void Update(){
        if(npcCollision == true){
            giftButton.SetActive(true);
        }
        else{
            giftButton.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D npcColl){
        if(npcColl.tag == "interObject"){
            Debug.Log("Ran into NPC");
            npcCollision = true;
        }
    }

    public void OnTriggerExit2D(Collider2D npcColl){
        if (npcColl.tag == "interObject"){
            Debug.Log("Moving away from NPC");
            npcCollision = false;
        }
    }
}
