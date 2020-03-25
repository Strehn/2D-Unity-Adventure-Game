using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class IsabelBadInstantiate{
        // Written by Isabel - used code from Team Lead 3's presentation
        // Boundary test to instantiate an object that does not exist in the hierarchy
        [Test]
        public IEnumerator InstantiateNonExistentObject(){
            SetupScene();
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/newObject"));
                if (GameObject.Find("newObject").GetComponent<Rigidbody>()){ 
                    yield break;
                }
                else{
                    Assert.Fail();
                }
        }

        void SetupScene(){
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/MainCharacter"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/newObject"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        }
    }
}