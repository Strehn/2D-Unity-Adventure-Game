/*
 * Ronnie Keating
 * Pattern Implementations
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton Pattern, this one was very useful with the instantiation of the dragon
public class RonnieSingleton : MonoBehaviour {
    
    private static RonnieSingleton instance;

    public static RonnieSingleton Instance {get { return instance; }}

    private void Awake() {
        if(instance != null && instance != this)
            Destroy(this.gameObject);
        else {
            instance = this;
        }
    }
}


//Iterator Pattern
public class RonnieIterate : MonoBehaviour {
    static int index = 0;
    static public int first() { return index; } //initialize first variable
    static public int next() { return index++; } //iterate to next 
    static public bool isDone(int max) { return index == max; } //return if iteration is done
}