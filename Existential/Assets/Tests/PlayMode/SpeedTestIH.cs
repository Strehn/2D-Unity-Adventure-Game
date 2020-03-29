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
            SetupScene();
            int defaultSpeed = 100;
            int MAX = 20;
            GameObject MainCharacter_1 = GameObject.Find("MainCharacter");

            for (int i = 0; i < MAX; i++){
                defaultSpeed = 100;
                MovePos(defaultSpeed, MainCharacter_1);
                yield return new WaitForSeconds(1);

                if (MainCharacter_1.GetComponent<Transform>().position.y < 14){
                    Debug.Log("New speed: " + i * 10);
                    defaultSpeed = defaultSpeed + 10;  // Add 10 to the speed each time
                }
                else{
                    Assert.Fail();  // Test fails, player breaks boundary
                    yield break;
                }   
            }
            Assert.Pass();  // Pass the test if the player doesn't go through the boundary
            yield break;
        }
        void MovePos(int defaultSpeed, GameObject character){
            character.transform.position = new Vector2(0, -2);
        }

        void SetupScene(){
            // Main character
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
            // My level
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/levelTilemap")); 
        }
    }
}
