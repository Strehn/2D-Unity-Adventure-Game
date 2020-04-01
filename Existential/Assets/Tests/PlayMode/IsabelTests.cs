using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class IsabelTests{
        // Boundary test to find an object that does not exist in the prefabs
        // Expected output: the test will pass - there should not be a "newObject" in the scene
        [UnityTest]
        public IEnumerator FindNonExistentObject(){
            SetupScene();
                if (GameObject.Find("newObject")){  // if we find the object in the scene, we fail - this should  not happen
                    Assert.Fail();
                    yield break;
                }
                else{
                    Assert.Pass();  // otherwise, we pass
                    yield break;
                }
        }
        // Boundary test to see which speed the main character breaks the boundary
        [UnityTest]
        public IEnumerator SpeedTest(){
            int defaultSpeed = 100; // Typically, the player will only be at speed 2 - but for testing I will amp it up to 100
            SetupScene(); // Sets the scene with my level and the Main Character

            GameObject MC = GameObject.Find("MainCharacter(Clone)");  // Find the main character in the scene
            Rigidbody2D rb = MC.GetComponent<Rigidbody2D>();  // Find the MC's rigidbody

            // Run test 10 times
            for(int i = 0; i < 10; i++){
                MovePos(defaultSpeed, MC, rb);  // Moves the player
                yield return new WaitForSeconds(1);  // Run for 1 second, try again

                if(MC.transform.position.y < 14){
                    Debug.Log("Current Speed: " + defaultSpeed);
                    defaultSpeed += 15;  // Add 15 to the defaultSpeed
                }
                else{
                    Debug.Log("Final Speed: " + defaultSpeed);
                    Assert.Pass();  // The test will pass if we break the boundary in the timeframe
                }
            }
            Assert.Fail();  // The test will fail if we do not break the boundary in the right timeframe
            yield break;
        }
        // Stress test to instantiate a bunch of inventory objects on scene
        [UnityTest]
        public IEnumerator StressTest(){
            var T = 1/Time.deltaTime;
            SetupScene();
            for (int i = 0; i < 10; i++){  // Execute 100 times
                T = 1/Time.deltaTime;
                for (int j = 0; j < 10; j++){
                    // Inventory item made by me
                    MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Chalice"));
                }
                T = 1 / Time.deltaTime;
                Debug.Log(T);
                yield return new WaitForSeconds(1);  // Wait for 1 second
                if (T < 15){
                    Debug.Log((i+1) * 100);
                    if (i < 5){
                        Assert.Fail();
                    }
                    yield break;
                }  
            }
        }
        // Function to set up the scene we are working with
        void SetupScene(){
            // Main character and camera
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
            // My level
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/levelTilemap"));
            // My inventory object
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Chalice"));
        }
        // Moves the character on the screen
        void MovePos(int defaultSpeed, GameObject Player, Rigidbody2D rb){
            rb.velocity = new Vector2(defaultSpeed, 0);
            Vector2 move = rb.transform.up * defaultSpeed;
            rb.transform.Translate(move * Time.fixedDeltaTime);
        }
    }
}



