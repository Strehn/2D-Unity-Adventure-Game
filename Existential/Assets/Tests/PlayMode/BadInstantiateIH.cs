using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class BadInstantiateIH{
        // Written by Isabel
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

        void SetupScene(){
            // Main character and camera
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
            // My level
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/levelTilemap"));
        }
    }
}



