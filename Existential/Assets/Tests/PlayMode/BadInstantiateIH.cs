using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class BadInstantiateIH{
        // Written by Isabel - used code from Team Lead 3's presentation
        // Boundary test to instantiate an object that does not exist in the prefabs
        [Test]
        public IEnumerator InstantiateNonExistentObject(){
            SetupScene();
                if (GameObject.Find("newObject").GetComponent<Rigidbody2D>()){ 
                    yield break;
                }
                else{
                    Assert.Fail();
                }
        }

        void SetupScene(){
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Canvas"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/newObject"));
        }
    }
}



