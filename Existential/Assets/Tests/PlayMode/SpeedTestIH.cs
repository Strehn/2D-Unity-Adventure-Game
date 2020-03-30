using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class SpeedTestIH{
        // Written by Isabel - used code from Team Lead 3's presentation
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

        // Instantiates the scene objects (only 2 needed)
        void SetupScene(){
            // Main character and camera
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
            // My level
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/levelTilemap"));
        }

        // Moves the character on the screen
        void MovePos(int defaultSpeed, GameObject Player, Rigidbody2D rb){
            rb.velocity = new Vector2(defaultSpeed, 0);
            Vector2 move = rb.transform.up * defaultSpeed;
            rb.transform.Translate(move * Time.fixedDeltaTime);
        }
    }
}
