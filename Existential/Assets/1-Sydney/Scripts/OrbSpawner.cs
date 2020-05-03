/****************************
 * Sydney Petrehn - Prefab Documentation
 * This is the Orb Spawner. Put it on a 
 * grid, add the bunny prefab to the gameobject location
 * on the script and it should work. This involves 
 * static and dynamic binding, and also an
 * iterator pattern.
 *
 ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField] public int numOfObjects; // change this variable to make more or less objects spawn
    public GameObject obj; //add prefab here
    public GameObject[] objs; // Yellow orb, Orange Orb
    private float randx; // random spawn location (x-axis)
    private float randy; // random spawn location (y-axis)
    [SerializeField] public float spawnSpeed; //speed at which the likelihood of bunny sprites spawning
    private int i; //iterator
    Spiritorbs c1; //Bunny class
    [SerializeField] public int typeOfOrb; //whichever class we want to use, the Bunny: bunny class or Cat: Bunny class

    // Start is called before the first frame update
    void Start()
    {
        i = SydneyIterate.first(); //set i to first of the iterator
        objs = new GameObject[numOfObjects]; //an array of new gameobjects (obj)
        //which particle type do we want to use (1 for Bunny, 2 for Cat)
        if (typeOfOrb == 1)
            c1 = new Spiritorbs(); //super class
        else if (typeOfOrb == 2)
            c1 = new OrangeOrb(); //sub class
    }

    // Update is called once per frame
    void Update()
    {
        //both Bunny and Cat have a function isSpawn, but is only declared in the Bunny class.
        //Cat inherits this function since it is virtual. isSpawn is a random number generator
        //to determine if we should spawn the object yet or not.
        if (c1.isSpawn(numOfObjects, spawnSpeed))
        {
            //rand is a random value on the x-axis to make the particle fall more natural
            randx = Random.Range(0, 16);
            randy = Random.Range(0, 16);

            //instantiate whatever object we are at in the iterator
            objs[i] = Instantiate(obj, new Vector2(randx, randy), transform.rotation);
            //cat has a different spawnBun function than bunny, so it is static in bunny
            //spawnBun either makes the sprite spawned a bunny or a cat
            c1.spawnOrb(objs[i]);
            //use the iterator next function
            i = SydneyIterate.next();
        }
    }
}
