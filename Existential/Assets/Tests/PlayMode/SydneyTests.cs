using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    /* Sydney Petrehn Tests
     * 1; Stress Test: Spawn 100 bunnies and see if frame rate drops unreasonably low
     * 2: Bounds Test 1: Using moving Bunny against stationary Trees
     * 3: Bounds Test 2: Using moving Tree against stationary Bunnies
     */

    public class SydneyTests{

        // Stress Test
        // [PASS] The frame rate does not drop unreasonable low.
        // [FAIL] The frame rate does drop unreasonably low.
        [UnityTest]
        public IEnumerator Bunny_StressTest(){
            // counter for Amount of Bunnies to spawn / spawned
            int count = 1; //Scene starts with one in the scene
            // spawn location
            Vector2 SpawnLocation = new Vector2(2, 1);
            // Used to calculate frame rate
            var deltaTime = 0.0;
            var fps = 0.0;
            var timeBegin = 0.0;
            //Instantiates the Objects
            SetupScene();

            //Begin Stress Testing
            //Instantiate a ton of bunnies
            for (int i = 0; i < 100; i++){
                //Spawn a new Bunny
                Spawner(SpawnLocation);
                count++;

                timeBegin += Time.deltaTime;

                //calcuate FPS
                deltaTime += Time.deltaTime;
                deltaTime /= 2.0;
                fps = 1.0 / deltaTime;
                Debug.Log("Frames: " + fps);

                // If frames drop below 10, stop the test
                if (fps < 10){
                    var timeFinish = timeBegin % 60;
                    Assert.Fail();
                }
                yield return new WaitForSeconds(0.1f);
            }
            Assert.Pass();
        }


        // Bounds Test 1
        // [PASS] The Bunny is does not go through the boundary of trees.
        // [FAIL] The Bunny goes through the boundary of trees.
        [UnityTest]
        public IEnumerator Bunny_BoundsTest(){
            //Test the speed the bunny is able to break through the boundary
            //Move the bunnies super fast
            //Begin Speed
            int beginSpeed = 10;
            //increment to increase speed
            int speedAdd = 10;
            //Instantiates the Objects
            SetupScene();
            //Find the bunny in the Forest Test Scene and Get it's rigidbody
            GameObject bunny = GameObject.Find("SpawnedBunny");
            //This lets me grab onto the object and move it against the wall
            Rigidbody2D rb = bunny.GetComponent<Rigidbody2D>();

            //Run test 10 times incrimenting the speed every time
                for (int i = 0; i < 10; i++){
                     //Function to give the Bunny velocity and reset if it hits the wall
                     moveObject(beginSpeed, rb);

                     //Let the test run for 1 secconds
                     yield return new WaitForSeconds(1);

                    //See if the bunny is out of bounds
                    //The bounds are 0-26 so if it is less than 0 or above 26 it is out of bounds
                    if (bunny.transform.position.y < 26 && bunny.transform.position.y > 0){ //in boundary
                    Debug.Log("Current Speed: " + beginSpeed);
                    //add the speed incriment
                    beginSpeed += speedAdd;  
                }
                else{ //broke boundary
                    Debug.Log("[FAIL] Final Speed: " + beginSpeed);
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
        public IEnumerator treeMoving_BoundsTest(){
            //Test the speed the tree is able to break through the boundary
            //Move the tree super fast
            //Begin Speed
            int beginSpeed = 10;
            //increment to increase speed
            int speedAdd = 10;
            //Instantiates the Objects
            SetupSceneTree();
            //Find the movingtree in the Forest Test Scene and Get it's rigidbody
            GameObject movingTree = GameObject.Find("movingTree");
            //This lets me grab onto the object and move it against the wall
            Rigidbody2D rb = movingTree.GetComponent<Rigidbody2D>();

            //Run test 10 times incrimenting the speed every time
            for (int i = 0; i < 10; i++){
                //Function to give the Bunny velocity and reset if it hits the wall
                moveObject(beginSpeed, rb);

                //Let the test run for 1 secconds
                yield return new WaitForSeconds(1);

                //See if the bunny is out of bounds
                //The bounds are 0-26 so if it is less than 0 or above 26 it is out of bounds
                if (movingTree.transform.position.y < 14 && movingTree.transform.position.y > 12){ //in boundary
                    Debug.Log("Current Speed: " + beginSpeed);
                    //add the speed incriment
                    beginSpeed += speedAdd;
                }
                else{ //broke boundary
                    Debug.Log("[FAIL] Final Speed: " + beginSpeed);
                    Assert.Fail();
                }
            }
            Assert.Pass();
            yield break;
        }


        //Function to setup the scene
        void SetupScene(){
            //Prefab with everything needed for Stress test and bounds test 1
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestingForestTileMap"));
        }

        //Function to setup the scene for Tree Moving
        void SetupSceneTree(){
            //Prefab with everything needed for bounds test 2
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TestingBunnyTileMap"));
        }

        //Functin to spawn bunnies
        void Spawner(Vector2 SpawnLocation){
            GameObject bunny = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/SpawnedBunny"));
            bunny.transform.position = SpawnLocation;
        }

        // Moves the object on the screen
        void moveObject(int defaultSpeed, Rigidbody2D rb)
        {
            rb.velocity = new Vector2(defaultSpeed, 0);
            Vector2 move = rb.transform.up * defaultSpeed;
            rb.transform.Translate(move * Time.fixedDeltaTime);
        }
    }
}



