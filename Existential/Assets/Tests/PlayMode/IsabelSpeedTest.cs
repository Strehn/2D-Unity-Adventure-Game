using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests{
    public class IsabelSpeedTest{
        // Written by Isabel - used code from Team Lead 3's presentation
        // Boundary test to see which speed the main character breaks the boundary
        [Test]
        public IEnumerator SpeedTest(){
            SetupScene();
            bool flag = true;
            GameObject Clone = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/MainCharacter"));
            for (int i = 0; flag; i++){
                Clone.GetComponent<Transform>().position = new Vector3(20f, 5f, 20f);
                Clone.GetComponent<Rigidbody>().velocity = new Vector3(-10f * i, 0, 0);
                yield return new WaitForSeconds(1);

                if (Clone.GetComponent<Transform>().position.x < -10){
                    flag = false;
                    Debug.Log(i * 10);
                    if (i < 10) Assert.Fail();
                    yield break; 
                }
            }
            Assert.Fail();
        }

        void SetupScene(){
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/MainCharacter"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Assets/Isabel/Prefabs/newObject"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Main Camera"));
        }
    }
}
