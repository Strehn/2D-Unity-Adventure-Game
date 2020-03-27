using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    /*
    * Tests for Inventory and ToriScene (Level)
    * 
    * [Bounds] - 
    * [Bounds] - test picking up 8+ items
    * [Stress] - spawn inventory items in same spot until system overload
    * 
    *
    * After conducting the test, the player breaks past the wall on ice
    * at a speed of 164.
    */
    public class ToriTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ToriTestsSimplePasses()
        {
            SetupScene();
            // Use the Assert class to test conditions
            
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ToriTestsWithEnumeratorPasses()
        {
            Debug.Log("testing");
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
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
