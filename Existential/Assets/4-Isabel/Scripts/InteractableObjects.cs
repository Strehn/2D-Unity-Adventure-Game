// Created by Isabel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour{
    public bool talks;  // If true the object can be talked to 
    public bool openable; // If true, this object can be opened
    public bool locked;  // If true, object is locked
    public GameObject itemNeeded;  // Item that this object needs to open

    public string message;  // Message to convey to player

    public void Talk(){ // Display the message
        Debug.Log(message);  // display message in console
    }
}
