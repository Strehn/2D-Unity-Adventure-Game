/****************************
 * Ronnie Keating - Prefab Documentation
 * This is the particle spawner. Put it on a 
 * grid, add the prefab to the gameobject location
 * on the script and it should work. This involves 
 * static and dynamic binding, and also an
 * iterator pattern.
 *
 ***************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {
    [SerializeField] public int numOfObjects; // change this variable to make more or less objects spawn
    public GameObject obj; //add prefab here
    public GameObject[] objs; // Snow, leaves, ash, confetti
    private float rand; // random spawn location (somewhere on the top of the camera x-axis)
    [SerializeField] public float spawnSpeed; //speed at which the likelihood of particles spawning
    private int j; //iterator
    Snow c1; //Snow class
    [SerializeField] public int typeOfParticle; //whichever class we want to use, the Snow: Snow class or Confetti: Snow clas

    // Start is called before the first frame update
    void Start() {
        j = RonnieIterate.first(); //set j to first of the iterator
        objs = new GameObject[numOfObjects]; //an array of new gameobjects (obj)
        //which particle type do we want to use (1 for snow, 2 for confetti)
        if(typeOfParticle == 1)
            c1 = new Snow(); //super class
        else if(typeOfParticle == 2)
            c1 = new Confetti(); //sub class
    }

    // Update is called once per frame
    void Update() {
        //both snow and confetti have a function isSpawn, but is only declared in the snow class.
        //confetti inherits this function since it is virtual. isSpawn is a random number generator
        //to determine if we should spawn the object yet or not.
        if(c1.isSpawn(numOfObjects, spawnSpeed)) {
            //rand is a random value on the x-axis to make the particle fall more natural
            rand = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            //instantiate whatever object we are at in the iterator
            objs[j] = Instantiate(obj, new Vector2(rand, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y), transform.rotation);
            //confetti has a different changeColor function than snow, so it is static in snow
            //change color either makes the particle white or gives it a random color (limited to 5 colors, still looks like confetti)
            c1.changeColor(objs[j]);
            //use the iterator next function
            j = RonnieIterate.next();
        }
    }
}
