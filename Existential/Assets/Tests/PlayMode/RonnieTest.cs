/*********************
 * Ronnie Keating's Test cases
 * 2 Boundary tests, 1 stress test
 * Tested on snow/leaves/ash particle effects
 ********************/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RonnieTest
    {

        //Tests spawns a bunch of snow particles over and over to try and decrease the FPS. Last value is the number of spawned particles
        [UnityTest]
        public IEnumerator StressTest()
        {
            GameObject Snow;
            float rand;
            Vector2 poss;
            var T = 1 / Time.deltaTime;
            SetupScene();

            //run test 100 times
            for (int i = 0; i < 100; i++)
            {
                T = 1 / Time.deltaTime;

                //spawn 1000 objects over the x axis at the top of the camera
                for (int j = 0; j < i * 50; j++)
                {
                    rand = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
                    poss = new Vector2(rand, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                    Snow = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Snow"));
                    Snow.transform.position = poss;
                }
                T = 1 / Time.deltaTime;
                Debug.Log(T);
                //wait a second
                yield return new WaitForSeconds(1);
                if (T < 15)
                {
                    //determine frame rates
                    //Debug.Log((i + 1) * 100);
                    Debug.Log("-----");
                    Debug.Log("Number of particles:");
                    Debug.Log(i * 50);
                    if (i < 5) Assert.Fail();
                    yield break;
                }

            }
        }

        //This test determines the limit of speed that should be applied to all particle affects
        //The output is some value at which the particle instantiated, fell, and destroyed in less
        //than .5 seconds. This is definitely not a plausible speed for which a particle should fall.
        //The test was originally meant to determine if particles could destroy significantly later than
        //they were supposed to (e.i. instead of destroying at -3.001f, they destroy at like -3.2f). But
        //I need a while loop in order to constantly check the position of the particle, but while loops
        //crash the Unity editor.
        [UnityTest]
        public IEnumerator BoundaryTest1()
        {
            SetupScene();
            GameObject[] Snows;
            Snows = new GameObject[15];
            Vector3 temp;
            for(int i = 0; i < 15; i++)
            {
                Snows[i] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Snow"));
                Snows[i].GetComponent<Transform>().position = new Vector2(0f, 3f);
                Snows[i].GetComponent<Rigidbody2D>().AddForce(Physics.gravity * i * i);
                yield return new WaitForSeconds(.3f);
                if (Snows[i] == null)
                {
                    //temp = Snows[i].transform.position;
                    //Debug.Log(temp);
                    Debug.Log("Particle instantiated and destroyed in less than .5 seconds at speed of: ");
                    temp = i * i * Physics.gravity;
                    //Debug.Log(i * i * Physics.gravity);
                    Debug.Log(temp.y);
                    if (i < 3) Assert.Fail();
                    yield break;
                }
                yield return new WaitForSeconds(2);
               
            }
             

            Debug.Log("Nothing failed");
        }


        //Currently does not work because of a Unity bug, crashes the entire editor. What it does is it speeds up the rate
        //at which particles fall and sees if they ever go past the point where they are supposed to be destroyed (with a little
        //wiggle room).
        //Last value is the speed at which the object was going
        /*[UnityTest]
        public IEnumerator BoundaryTest1()
		{
            GameObject Snow;
            SetupScene();
            bool flag = true;
            //Snow = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Snow"));
            for (int i = 0; flag && i < 15; i++)
            {
                Snow = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Snow"));
                Snow.GetComponent<Transform>().position = new Vector2(0f, 3f);
                Snow.GetComponent<Rigidbody2D>().AddForce(Physics.gravity * i * i);
                yield return new WaitForSeconds(1);
                if (Snow != null && Snow.transform.position.y < -3.01f)
                {
                    flag = false;
                    Debug.Log(i * i * Physics.gravity);
                    if (i < 3) Assert.Fail();
                    yield break;
                }
            }
            //Assert.Fail();
        }*/

        //Tests to see how quickly we can move the player before the snow particles become too far out of reach.
        //This does not affect their ability to relocate, it just shows that there needs to be a limit on the player
        //speed to decrease the likelihood of bugs
        //Last object is a variable that shows how far we moved the player at one time
        [UnityTest]
        public IEnumerator BoundaryTest2()
		{
            GameObject Snow;
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Grid"));
            GameObject Character = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Character")); ;
            Vector2 spawn;
            //SetupScene();
            int i = 0;
            while(i < 100)
			{
                yield return new WaitForSeconds(.5f);
                Debug.Log(Character.transform.position.x);
                Snow = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Snow"));
                spawn = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x + 5f, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                Snow.transform.position = spawn;
                i++;
                Character.transform.position = new Vector2(Character.transform.position.x + i/2, Character.transform.position.y);
                if (Snow.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x - 1f || Snow.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x + 1f)
                {
                    Debug.Log("-----");
                    Debug.Log("Particles escape looping sequence (by 1f) when character jumps in x:");
                    Debug.Log(i/2);
                    yield break;
                }
            }
            Assert.Fail();
        }

        void SetupScene()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Grid"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Character"));
        }
    }
}
