/**********************
 * Ronnie Keating - Instantiate dragon
 * This script instantiates one and only one dragon.
 * You could try to instantiate more than one dragon,
 * However, there is a Singleton pattern on the dragon
 * to check for mutliple instances of the dragon.
 * If so, it destroys the newest dragon instance.
 *
 * Instruction:
 * -Add this script to anything in the hierarchy that
 * is immediately called (like the grid).
 * -Drag the dragon prefab (5-Ronnie) into the 
 * public gameobject of Dragon on the script
 *********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dragonInstantiate : MonoBehaviour
{
    public static GameObject Dragon1;
    private GameObject Dragon2;
    public GameObject Dragon;
    // Start is called before the first frame update
    void Start()
    {
        Dragon1 = Instantiate(Dragon, new Vector2(5.5f, 2), transform.rotation);
        Dragon2 = Instantiate(Dragon, new Vector2(4.5f, -3), transform.rotation); //check for singleton implementation
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}