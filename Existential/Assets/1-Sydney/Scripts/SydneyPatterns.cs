/*
 * Sydney Petrehn
 * Pattern Implementations
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton Pattern, used to have one instance of the cat in the level
public class SydneySingleton : MonoBehaviour
{

    private static SydneySingleton instance;

    public static SydneySingleton Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
        }
    }
}


//Iterator Pattern
public class SydneyIterate : MonoBehaviour
{
    static int index = 0;
    static public int first() { return index; } //initialize first variable
    static public int next() { return index++; } //iterate to next 
    static public bool isDone(int max) { return index == max; } //return if iteration is done
}