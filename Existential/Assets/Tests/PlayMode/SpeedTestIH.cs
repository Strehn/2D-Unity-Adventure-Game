using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class SpeedTestIH{
        // Written by Isabel - used code from Team Lead 3's presentation
        // Boundary test to see which speed the main character breaks the boundary
        [Test]
        public IEnumerator SpeedTest(){
            SetupScene();
            int defaultSpeed = 2;
            int MAX = 20;
            GameObject Clone = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
            for (int i = 0; i < MAX; i++){
                MovePos(defaultSpeed);
                yield return new WaitForSeconds(1);

                if (Clone.GetComponent<Transform>().position.y < 14){
                    Debug.Log("New speed: " + i * 10);
                    defaultSpeed = defaultSpeed * 2;  // Double the speed each time
                }
                else{
                    Assert.Fail();  // Test fails, player breaks boundary
                }
            }
        }
        void MovePos(int defaultSpeed){  // Code from Taegan, edited by me
            GameObject MainCharacter_1 = GameObject.Find("MainCharacter");
            Rigidbody2D rb = MainCharacter_1.GetComponent<Rigidbody2D>();
            MainCharacter_1.transform.position = new Vector2(0, -2);
            rb.velocity = new Vector2(defaultSpeed, 0);
        }

        void SetupScene(){
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Canvas"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/LevelTilemap"));
        }
    }
}
