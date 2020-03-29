using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class BadInstantiateIH{
        // Written by Isabel - used code from Team Lead 3's presentation
        // Boundary test to instantiate an object that does not exist in the prefabs - it will fail until an object is created in the prefabs
        [UnityTest]
        public IEnumerator InstantiateNonExistentObject(){
            SetupScene();
                if (GameObject.Find("newObject")){  // if we find the object in the scene, we pass
                    Assert.Pass();
                    yield break;
                }
                else{
                    Assert.Fail();  // otherwise, we fail
                    yield break;
                }
        }

        void SetupScene(){
            // Main character and camera
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/MainCharacter"));
            // My level
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/levelTilemap"));
            // Bad object
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/newObject"));
        }
    }
}



