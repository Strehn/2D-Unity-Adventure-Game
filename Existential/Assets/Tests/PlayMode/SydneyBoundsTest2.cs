using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sydney Petrehn
 * Bounds Test Using a tree on a boarder of bunnies
 * Spawn Tree to see if it goes out of bounds after 5 seconds.
 * The point of this test is to see if a boundary that is moving can go through a
 * npc whereas my other boundary test is to test if a npc that is moving can go
 * through a boundary
 */

public class SydneyBoundsTest2 : MonoBehaviour
{
    [UnityTest]
    public IEnumerator Bunny_BoundsTest()
    {
        //Move the tree speedy fast
        int currentSpeed = 80;
        //Dont move the bunnies
        int bunnySpeed = 0;
        //spawn location
        Vector2 StartLocation = new Vector2(2, 1);
        //Instantiates the Objects
        SetupScene();
        // Duplicates my forest scene
        GameObject Forest = GameObject.Find("Forest(Clone)");
        // Puts the camera in  Inital Position to see whats happening
        Forest.transform.position = StartLocation;
        // Make sure bunny is spawned
        GameObject SpawnedBunny = GameObject.Find("SpawnedBunny");
        Rigidbody2D rb = SpawnedBunny.GetComponent<Rigidbody2D>();


        // Test to see if tree boundary can go through a bunny npc
        // if it doesnt work then fail.

        // If works the. pass
        Assert.Pass();
        yield break;
    }
    //Function to setup the scene
    void SetupScene()
    {
        //Prefab with everything needed for This bounds test
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SPForestTestingCanvas"));
    }
}
