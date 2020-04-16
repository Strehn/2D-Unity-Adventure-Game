/* Script created by Isabel Hinkle to trigger a gift exchange when two characters collide
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftTrigger : MonoBehaviour{

    public PlayerControllerRigidBody mainCharacter;
    public GameObject NPC1;
    public GameObject NPC2;
    public GameObject NPC3;
    public Button giftButton;

    void Start(){
        mainCharacter = FindObjectOfType<PlayerControllerRigidBody>();
    }

    public void OnTriggerEnter(Collider other ){
        if(other.gameObject.tag == "interObject"){
            Debug.Log("Ran into NPC");
            giftButton.gameObject.SetActive(true);
        }
    }
}
