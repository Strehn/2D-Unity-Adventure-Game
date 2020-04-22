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

        [UnityTest]
        public bool CheckHudExists()
        {
            SetupScene();
            GameObject hud = GameObject.Find("HUDINV");
            if(hud != null){
                return true;
            }
            else{
                return false;
            }
        }

        [UnityTest]
        public bool CheckInvExists()
        {
            SetupScene();
            GameObject inv = GameObject.Find("Inventory");
            
            if (inv != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
        [UnityTest]
        public bool CheckInvScriptExists()
        {
            SetupScene();
            GameObject inv = GameObject.Find("Inventory");
            Inventory inventory = inv.GetComponent<Inventory>();
            if (inventory != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
        // Test spawn items
        // [PASS] Frame rate is unaffected for many spawned items
        // [FAIL] frame rate is affected poorly by spawned items
        [UnityTest]
        public IEnumerator ToriTestsInventoryOverload(){
            Vector2 itemLocation = new Vector2(0, 0);
            SetupScene();

            var time = 1/Time.deltaTime;
            // overall this loop will spawn 100 items (on success)
            for (int i = 0; i < 10; i++){
                time = 1 / Time.deltaTime;
                for(int j = 0; j < 10; j++){
                    // spawn 10 items
                    spawnItem(itemLocation);
                }
                time = 1 / Time.deltaTime;
                Debug.Log(time);
                yield return new WaitForSeconds(1);
                if(time < 10){
                    if (i < 5){
                        // if you cant spawn 50 items without frame rate
                        // dropping, then fail the test
                        Assert.Fail();
                    }
                    yield break;
                }
                
            }
            Debug.Log("100 items were spawned without impacting frame rate significantly");
            Assert.Pass();
            
        }

        // Test slots in inventory
        // [PASS] There are 8 slots in the inventory hud
        // [FAIL] There are not 8 slots in the inventory hud
        
        [UnityTest]
        public bool ToriTestsItemSlots(){
            SetupScene();
            GameObject invHud = GameObject.Find("HUDINV");
             
            GameObject inventoryObj = null; ;
            foreach (Transform transform in invHud.transform){
                if (transform.name == "Inventory"){
                    inventoryObj = transform.gameObject;
                }
            }
            if(inventoryObj != null){
                return true;
            }else{
                return false;
            }
            //return Assert.True(inventoryObj);
           
            /*
            if(inventoryObj != null){
                Transform invPanel = inventoryObj.GetComponent<Transform>();
                int expectedSlots = 8;
                int actualSlots = 0;
                foreach (Transform slot in invPanel){
                    if (slot.GetChild(0) != null) ;
                    actualSlots++;
                }
                Assert.AreEqual(expectedSlots, actualSlots);
                yield break;
            }
            Assert.Pass();
            */
        }

        /*
        [UnityTest]
        public IEnumerator getInvRef(){
            GameObject invRef = new Inventory();
            Assert.True(invRef);
        }
        */

        // Test max item pickup
        // [PASS] 8 items can be picked up
        // [FAIL] 8 items pick up unsuccessful
        /*
        [UnityTest]
        public IEnumerator ToriTestsMaxPickUp(){
            SetupScene();
            GameObject HUDINV = GameObject.Find("HUDINV");
            GameObject flower = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/pinkFlower"));
            GameObject inventoryObj = null;
            foreach (Transform transform in HUDINV.transform){
                if (transform.name == "Inventory"){
                    inventoryObj = transform.gameObject;
                }
            }
            if(inventoryObj != null){
                int maxItems = inventoryObj.GetComponent<Inventory>.MAXITEMS;

                for (int i = 0; i < maxItems; i++){
                    inventoryObj.GetComponent<Inventory>().AddItem(flower);
                }
                Assert.AreEqual(maxItems, inventoryObj.GetComponent<Inventory>().inventoryList.Count);

                yield break;
            }
            Assert.Pass();
        }
        */
        void spawnItem(Vector2 location){
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
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
           

            //Prefab with the Inventory Hud
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/HUDINV"));
            
        }
    }
}
