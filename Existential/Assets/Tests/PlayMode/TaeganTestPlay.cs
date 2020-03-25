using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TaeganTest
    {
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator Check_Speed_Of_Player()
        {
            SetupScene();
            int currentSpeed = 5;
            for (int i = 0; i < 10; i++)
            {
                Player_Slide(currentSpeed);
                yield return new WaitForSeconds(3);
                bool returnedValue = Check_Position();
                if (returnedValue == false)
                {
                    Debug.Log("Adding Speed");
                    currentSpeed *= 2;
                }
                else
                {
                    Debug.Log("Asserting False");
                    Assert.Fail();
                }
                
            }

            yield break;
        }

        void SetupScene()
        {
            //SceneManager.LoadScene("Assets/6-Taegan/Scenes/TaeganScene.unity",LoadSceneMode.Single);
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Canvas"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Grid"));
            //MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Main Camera 1"));
        }

        void Player_Slide(int currentSpeed) {

            Debug.Log("Sliding");
            GameObject Character = GameObject.Find("MainCharacter");
            GameObject Player = GameObject.Find("Canvas(Clone)");
            Rigidbody2D rb = Character.GetComponent<Rigidbody2D>();
            Player.transform.position = new Vector2(208, -54);
            rb.velocity = new Vector2(currentSpeed, 0);
        }


        bool Check_Position() {

            GameObject Character = GameObject.Find("MainCharacter");
            GameObject Player = GameObject.Find("Canvas(Clone)");
            Rigidbody2D rb = Character.GetComponent<Rigidbody2D>();

            if (Player.transform.position.x > 838 || Player.transform.position.x < 206)
            {
                return true;
            }
            else
            {
                Player.transform.position = new Vector2(208, -54);
                return false;
            }



        }

    }
}

//MonoBehaviour.Instantiate(Resources.Load<GameObject>("Sphere Variant"));

//            for (int i = 0; i< 10; i++)
//            {
//                yield return new WaitForSeconds(3);
//                if (GameObject.Find("Sphere Variant(Clone)").GetComponent<Rigidbody>().velocity.sqrMagnitude< .0001)
//                { 
//                    yield break;
//                }
//            }
//            Assert.Fail();