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
    * [Bounds] - ToriTestsItemSlots - Ensure there are 8 inventory item slots
    * [Bounds] - ToriTestsMaxPickUp - Test picking up 8+ items and dropping 8+ items
    * [Stress] - ToriTestsInventoryOverload - Spawn inventory items in same spot until system overload via frame rate
    * 
    */
    public class ToriTests{
        // Test scene setup
        [Test]
        public void ToriTestsSimplePasses(){
            SetupScene();
        }

        // Test spawn items
        // [PASS] Checks that frame rate is affected by spawned items
        // [FAIL] frame rate is unaffected
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
                GameObject flower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));

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
                    Assert.Fail();
                }
                yield return new WaitForSeconds(0.1f);
            }
            Assert.Pass();

        }

        // Test slots in inventory
        // [PASS] There are 8 slots in the inventory hud
        // [FAIL] There are not 8 slots in the inventory hud
        [UnityTest]
        public IEnumerator ToriTestsItemSlots(){
            SetupScene();
            Debug.Log("testing");
            GameObject pinkFlower = GameObject.Find("pinkFlower");
            GameObject HUDINV = GameObject.Find("HUDINV");
            Transform invPanel = HUDINV.GetComponent<Transform>();
            int expectedSlots = 8;
            int actualSlots = 0;
            foreach (Transform slot in invPanel){
                if (slot.GetChild(0) != null);
                actualSlots++;
            }
            Assert.AreEqual(expectedSlots, actualSlots);
            yield break;
            
        }

        // Test max item pickup
        // [PASS] 8 items can be picked up
        // [FAIL] 8 items pick up unsuccessful
        [UnityTest]
        public IEnumerator ToriTestsMaxPickUp(){
            SetupScene();
            GameObject HUDINV = GameObject.Find("HUDINV");
            GameObject flower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
            //GameObject invPanel = HUDINV.GetComponent<Inventory>();
            //int maxItems = invPanel.GetComponent<Inventory>().MAXITEMS;
            /*
            for (int i = 0; i < maxItems; i++){
                //invPanel.GetComponent<Inventory>().AddItem(flower);
            }
            //Assert.AreEqual(maxItems, invPanel.GetComponent<Inventory>().inventoryList.Count);
            */
            yield break;

        }

        void spawnItem(Vector2 location){
            GameObject flower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
            flower.transform.position = location;
        }

        void SetupScene(){
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
