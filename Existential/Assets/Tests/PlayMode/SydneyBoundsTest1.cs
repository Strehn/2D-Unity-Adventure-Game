using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/* Sydney Petrehn
 * Bounds Test Using a bunny
 * Spawn Buny to see if it goes out of bounds
 */

public class SydneyBoundsTest1 : MonoBehaviour
{
    [UnityTest]
    public IEnumerator Bunny_Speed()
    {
        //Move the bunnies super fast
        int currentSpeed = 80;
        // spawn location
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

        //Runs the test for a total of 10 runs, if it does not break the wall, the test passes
        for (int i = 0; i < 10; i++)
        {
            //Function to give the Bunny velocity and reset if it hits the wall
            Bunny_Move(currentSpeed, StartLocation, SpawnedBunny, rb);

            //Let the test run for 3 secconds
            yield return new WaitForSeconds(3);

            //Function to check if the bunny is out of bounds
            bool returnedValue = Check_Position(SpawnedBunny);

            if (returnedValue == false)
            {
                currentSpeed += 1;
                Debug.Log("Adding Speed - Current Speed: " + currentSpeed);
            }
            else
            {
                Debug.Log("Asserting False - Final Speed: " + currentSpeed);
                Assert.Fail();
            }
        }
        Assert.Pass();
        yield break;
    }

    //Function to setup the scene
    void SetupScene()
    {
        //Prefab with the Camera
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SPCanvas"));

        //Prefab with the Forest
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ForestTile"));
    }

    //Function to give the Bunny Velocity and reset the Bunny
    void Bunny_Move(int currentSpeed, Vector2 StartLocation, GameObject SpawnedBunny, Rigidbody2D rb)
    {
        //Debug.Log("Moving Bunny");
        if (SpawnedBunny.transform.position.x > 1f && SpawnedBunny.transform.position.x < 100f)
        {
            //Debug.Log("Resetting Bunny");
            SpawnedBunny.transform.position = StartLocation;
        }
        rb.velocity = new Vector2(currentSpeed, 0);
    }

    //Function to check if the Bunny is past the wall
    bool Check_Position(GameObject SpawnedBunny)
    {
        if (SpawnedBunny.transform.position.x > 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
