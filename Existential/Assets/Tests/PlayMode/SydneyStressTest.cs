using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/* Sydney Petrehn
 * Stess Test Using Bunnies
 * Spawn Bunnies to see if the game can handle many bunnnies being spawned
 * Used the team lead 3 presentation for reference and teammates for help
 */

public class SydneyStressTest : MonoBehaviour
{
    [UnityTest]
    public IEnumerator Bunny_StressTest()
    {
        // Amount of Bunnies
        int i = 0;
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

        //Track time it is taking
        var StartTime = 1 / Time.deltaTime;

        //Instantiate a ton of bunnies
        for (i = 0; i < 100; i++)
        {
            //SpawnBunny
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SpawnedBunny"));

        }

        // Get End Time
        var EndTime = 1 / Time.deltaTime;

        var TTime = EndTime - StartTime;

        // Give Time
        Debug.Log(TTime);

        //Let the test run for 3 secconds
        yield return new WaitForSeconds(3);

        // See how it affected the game time
        if (TTime < 10)
        {
            Debug.Log((i + 1) * 100);
            if (i < 100)
            {
                Assert.Fail();
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
    }
}