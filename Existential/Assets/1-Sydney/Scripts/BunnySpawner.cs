/****************************
 * Sydney Petrehn - Prefab Documentation
 * This is the Bunny spawner. Put it on a 
 * grid, add the bunny prefab to the gameobject location
 * on the script and it should work. This involves 
 * static and dynamic binding, and also an
 * iterator pattern.
 *
 ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnySpawner : MonoBehaviour
{
    [SerializeField] public int numOfObjects; // change this variable to make more or less objects spawn
    public GameObject obj; //add prefab here
    public GameObject[] objs; // Bunny, Cat
    private float randx; // random spawn location (x-axis)
    private float randy; // random spawn location (y-axis)
    [SerializeField] public float spawnSpeed; //speed at which the likelihood of bunny sprites spawning
    private int i; //iterator
    Bunny c1; //Bunny class
    [SerializeField] public int typeOfAnimal; //whichever class we want to use, the Bunny: bunny class or Cat: Bunny class

    // Start is called before the first frame update
    void Start()
    {
        i = SydneyIterate.first(); //set i to first of the iterator
        objs = new GameObject[numOfObjects]; //an array of new gameobjects (obj)
        //which particle type do we want to use (1 for Bunny, 2 for Cat)
        if (typeOfAnimal == 1)
            c1 = new Bunny(); //super class
        else if (typeOfAnimal == 2)
            c1 = new Cat(); //sub class
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
            randx = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            randy = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            //instantiate whatever object we are at in the iterator
            objs[i] = Instantiate(obj, new Vector2(randx,randy ), transform.rotation);
            //cat has a different spawnBun function than bunny, so it is static in bunny
            //spawnBun either makes the sprite spawned a bunny or a cat
            c1.spawnBun(objs[i]);
            //use the iterator next function
            i = SydneyIterate.next();
        }
    }
}
