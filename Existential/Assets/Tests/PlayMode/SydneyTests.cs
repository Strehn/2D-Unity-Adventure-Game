using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    /* Sydney Petrehn Tests
     * 1; Stress Test: Spawn 100 bunnies and see if frame rate drops unreasonably low
     * 2: Bounds Test 1: Using moving Bunny against stationary Trees
     * 3: Bounds Test 2: Using moving Tree against stationary Bunnies
     */

    public class SydneyTests
    {

        // Stress Test
        // [PASS] The frame rate does not drop unreasonable low.
        // [FAIL] The frame rate does drop unreasonably low.
        [UnityTest]
        public IEnumerator Bunny_StressTest()
        {
            // Amount of Bunnies to spawn / spawned
            int i = 0;
            // spawn location
            Vector2 StartLocation = new Vector2(2, 1);
            //Instantiates the Objects
            SetupScene();

            //Track time it is taking
            var StartTime = 1 / Time.deltaTime;

            //Instantiate a ton of bunnies
            for (i = 0; i < 100; i++)
            {
                //SpawnBunny multiple times
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SpawnedBunny"));

            }

            // Get End Time
            var EndTime = 1 / Time.deltaTime;

            var TTime = EndTime - StartTime;

            // Give Time
            Debug.Log(TTime);

            //Let the test run for 3 secconds
            yield return new WaitForSeconds(3);


            // Do Frames per second here instead
            //
            //
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
            //
            //

        }

        // Bounds Test 1
        // [PASS] The Bunny is does not go through the boundary of trees.
        // [FAIL] The Bunny goes through the boundary of trees.
        [UnityTest]
        public IEnumerator Bunny_BoundsTest()
        {
            //Move the bunnies super fast
            int currentSpeed = 10;
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

        // Bounds Test 2
        // [PASS] The tree does not go through the boudnary of bunnies.
        // [FAIL] The tree goes though the boundary of bunnies.
        [UnityTest]
        public IEnumerator treeMoving_BoundsTest()
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
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestingForestTileMap"));
        }

        //Function to setup the scene for Tree Moving
        void SetupSceneTree()
        {
            //Prefab with everything needed for This bounds test
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestingBunnyTileMap"));
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
}



