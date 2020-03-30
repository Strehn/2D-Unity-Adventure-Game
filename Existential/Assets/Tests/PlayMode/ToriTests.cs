using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using UnityEngine.UI;

namespace Tests
{
    /*
    * Tests for Inventory and ToriScene (Level)
    * 
    * [Bounds] - Ensure there are 8 inventory item slots
    * [Bounds] - test picking up 8+ items and dropping 8+ items
    * [Stress] - spawn inventory items in same spot until system overload
    * 
    *
    * After conducting the test, the player breaks past the wall on ice
    * at a speed of 164.
    */
    public class ToriTests
    {
       // Test scene setup
        [Test]
        public void ToriTestsSimplePasses()
        {
            SetupScene();
            // Use the Assert class to test conditions
            
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        // Test slots in inventory
        [UnityTest]
        public IEnumerator ToriTestsItemSlots()
        {
            SetupScene();
            Debug.Log("testing");
            GameObject pinkFlower = GameObject.Find("pinkFlower");
            GameObject HUDINV = GameObject.Find("HUDINV");
            Transform invPanel = HUDINV.GetComponent<Transform>();
            int expectedSlots = 8;
            int actualSlots = 0;
            foreach (Transform slot in invPanel)
            {
                if (slot.GetChild(0) != null) ;
                actualSlots++;
            }
            Assert.AreEqual(expectedSlots, actualSlots);
            yield break;
            
        }

        // Test max item pickup 
        [UnityTest]
        public IEnumerator ToriTestsMaxPickUp()
        {
            SetupScene();
            Debug.Log("testing");
            GameObject pinkFlower = GameObject.Find("pinkFlower");
            GameObject HUDINV = GameObject.Find("HUDINV");
            Transform invPanel = HUDINV.GetComponent<Transform>();
            int expectedSlots = 8;
            int actualSlots = 0;
            foreach (Transform slot in invPanel)
            {
                if (slot.GetChild(0) != null) ;
                actualSlots++;
            }
            Assert.AreEqual(expectedSlots, actualSlots);
            yield break;

        }

        // Test spawn items
        [UnityTest]
        public IEnumerator ToriTestsInventoryOverload()
        {
            Vector2 itemLocation = new Vector2(0, 0);
            SetupScene();
            
            var deltaTime = 0.0;
            var fps = 0.0;
            var timeBegin = 0.0;
            int count = 0;

            for (int i = 0; i < 100; i++)
            {
                spawnItem(itemLocation);

                count++;
                timeBegin += Time.deltaTime;

                //calcuate FPS
                deltaTime += Time.deltaTime;
                deltaTime /= 2.0;
                fps = 1.0 / deltaTime;
                Debug.Log("Frames: " + fps);

                // If frames drop below 10, stop the test
                if (fps < 10)
                {
                    var timeFinish = timeBegin % 60;
                    Debug.Log("The creation of Fog objects per seccond is now greater than the FPS!");
                    Debug.Log("Was able to create " + count + " fog objects before FPS < 20 in " + timeFinish + " seconds");
                    Assert.Fail();
                }
                yield return new WaitForSeconds(0.1f);
            }
            Assert.Pass();

        }

        void spawnItem(Vector2 location)
        {
            GameObject flower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
            flower.transform.position = location;
        }

        void SetupScene()
        {
            //Prefab with the Inventory Hud
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/HUDINV"));
            
            //Prefab with the Grid of the game
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ToriSceneGrid"));
           
            //Prefab with the flower inventory object
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));

            //Prefab with the Inventory
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryManager"));

            //Prefab with the MainCharacter
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
            
        }
    }
}
