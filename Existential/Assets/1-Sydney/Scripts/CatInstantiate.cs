/**********************
// Sydney Petrehn - Instantiate Cat
// * This script instantiates one and only one cat.
 //* You could try to instantiate more than one cat,
// * However, there is a Singleton pattern on the cat
// * to check for mutliple instances of the cat.
// * If so, it destroys the newest cat instance.
// *
// * Instruction:
// * -Add this script to anything in the hierarchy that
// * is immediately called (like the game element holder).
 //* -Drag the cat prefab into the public gameobject of Cat on the script
// *********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CatInstantiate : MonoBehaviour
{
    public static GameObject Cat1;
    private GameObject Cat2;
    public GameObject Cat;
    // Start is called before the first frame update
    void Start()
    {
        Cat1 = Instantiate(Cat, new Vector2(8, 4), transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}