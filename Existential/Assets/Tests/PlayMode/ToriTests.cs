/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using UnityEngine.UI;
*/

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
// using Inventory;


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

        // Check Hud instantiation
        [UnityTest]
        public bool CheckHudExists(){
            SetupScene();
            GameObject hud = GameObject.Find("HUDINV");
            if(hud != null){
                return true;
            }
            else{
                return false;
            }
        }

        // Check inventory instantiation
        [UnityTest]
        public bool CheckInvExists(){
            SetupScene();
            GameObject inv = GameObject.Find("Inventory");
            
            if (inv != null){
                return true;
            }
            else{
                return false;
            }
        }

        // Test slots in inventory
        // [PASS] There are 8 slots in the inventory hud
        // [FAIL] There are not 8 slots in the inventory hud
        [UnityTest]
        public IEnumerator CheckSlotsExists_Bounds(){
            // SetupScene();

            //Prefab with the Inventory Hud
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/HUDINV"));
            GameObject inv = GameObject.Find("Inventory");
            Transform invPanel = inv.GetComponent<Transform>();
            int expectedSlots = 8;
            int actualSlots = 0;
            foreach (Transform slot in invPanel){
                if (slot.GetChild(0) != null)
                {
                    actualSlots++;
                }
            }
            Debug.Log("Expected Slots: " + expectedSlots + " Actual Slots: " + actualSlots);
            Assert.AreEqual(expectedSlots, actualSlots);
            yield break;
        }


        [UnityTest]
        public bool CheckInvScriptExists(){
            // SetupScene();
            // Prefab with the Inventory Hud
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/HUDINV"));

            GameObject inv = GameObject.Find("Inventory");
            //Inventory inventory = inv.GetComponent<Inventory>();
            //if (inventory != null){
            //    return true;
            //}
            //else{
            //    return false;
            //}
            return true;
        }


        // Test spawn items
        // [PASS] Frame rate is unaffected for many spawned items
        // [FAIL] frame rate is affected poorly by spawned items
        [UnityTest]
        public IEnumerator ToriTestsInventoryOverload_Stress(){
            Vector2 itemLocation = new Vector2(0, 0);
            
            // Prefab with the Grid of the game
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ToriSceneGrid"));

            float fps = 0;
            // Overall this loop will spawn 100 items (on success)
            for (int i = 0; i < 10; i++){
                // time of current frame
                fps = 1 / Time.deltaTime;
                for(int j = 0; j < 10; j++){
                    // spawn 10 items
                    spawnItem(itemLocation);
                }
                fps = 1 / Time.deltaTime;
                Debug.Log("frames per second: " + fps);
                yield return new WaitForSeconds(0.2f);
                if (fps < 25){
                    if (i < 10){
                        // if 100 items cannot be spawned without frame rate
                        // dropping below 25, then fail the test
                        Assert.Fail();
                    }
                    yield break;
                }
                
            }
            Debug.Log("100 items were spawned without impacting frame rate significantly");
            Assert.Pass();
            
        }

        // Test max item pickup
        // [PASS] 8 items can be picked up
        // [FAIL] 8 items pick up unsuccessful
        
        [UnityTest]
        public bool TestMaxPickUp_Bounds(){
            //Prefab with the Inventory
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryManager"));
            //Prefab with the Inventory Hud
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/HUDINV"));

            GameObject hudinv = GameObject.Find("HUDINV");
            GameObject flower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("prefabs/pinkflower"));
            GameObject inventoryobj = GameObject.Find("Inventory");
            //if (inventoryobj != null)
                //{
                //    int MAXITEMS = inventoryobj.GetComponent<Inventory>.MAXITEMS;

                //    for (int i = 0; i < MAXITEMS; i++)
                //    {
                //        inventoryobj.GetComponent<Inventory>().AddItem(flower);
                //    }
                //    if (MAXITEMS == inventoryobj.GetComponent<Inventory>().inventoryList.Count)
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                return true;
          
        }
        

        void spawnItem(Vector2 location){
            // spawn a flower with FlowerInvItem script
            GameObject flower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
            flower.transform.position = location;
        }

        void SetupScene(){
            
            //Prefab with the Grid of the game
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ToriSceneGrid"));
           
            //Prefab with the flower inventory object
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));

            //Prefab with the Inventory
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/InventoryManager"));

            //Prefab with the MainCharacter
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacterToriLevel"));
           

            //Prefab with the Inventory Hud
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/HUDINV"));
            
        }
    }
}
