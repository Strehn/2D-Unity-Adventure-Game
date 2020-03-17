// Created by Isabel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour{

    public GameObject currentInterObj = null;  // object to currently interact with
    public InteractableObjects currentInterObjScript = null;  // script attatched to interactable object

    void Update(){
        if(Input.GetButtonDown("Interact") && currentInterObj){  // if we receive input to interact and check for interactable object
            // Check to see if object has a message/talks
            if(currentInterObjScript.talks){
                // Tell the object to give its message
                currentInterObjScript.Talk();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){  // store info about object that player collided with
        if(other.CompareTag("interObject")){  // if we walk into interactable object
            Debug.Log(other.name);  // testing
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent <InteractableObjects> ();
        }
    }

    void OnTriggerExit2D(Collider2D other){  // remove object once finished using
        if(other.CompareTag("interObject")){  
            if(other.gameObject == currentInterObj){
                currentInterObj = null;
            }
        }
    }

}
