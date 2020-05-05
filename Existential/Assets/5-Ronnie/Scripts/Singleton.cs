/********************
 * Ronnie Keating - Singleton Pattern
 *
 * Also decalred on RonniePattern, but had some issues with
 * it due to naming scheme. Cannot be attached to prefab
 * with different class name than .cs name
 * Attach to dragon prefab
 * Used code from 
 * https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern
 *******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance; //instance of Singleton class called instance
    public static Singleton Instance { //function that returns an instance of Singleton
        get { 
            return instance; //return instance of the class
        }
    }

    private void Awake() {
        if(instance != null && instance != this) { //if other instance of class and class is not the initial instance
            Destroy(this.gameObject); //destroy any other instances of the class
            Debug.Log("Deleted second Dragon");
        }
        else {
            instance = this; //first instance of the class
        }
    }
}
