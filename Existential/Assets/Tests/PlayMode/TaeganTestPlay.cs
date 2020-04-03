using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TaeganTest {
        /*
         *TaeganTest - Test Cases for TaeganScene
         * 
         * This Unity Test checks the player speed on the ice, if the player
         * goes to fast then it will break past the barrier.
         *
         * After conducting the test, the player breaks past the wall on ice
         * at a speed of 134.
         */
        [UnityTest]
        public IEnumerator Check_Speed_Of_PlayerTW() {
            // After multiple test, 160 is a suitable number before the game breaks
            int currentSpeed = 130;
            Vector2 StartLocation = new Vector2(208, -54); // The location to spawn the player
            SetupScene(); //Instantiates the Objects
            GameObject Player = GameObject.Find("TaeganCanvasNew(Clone)"); // Locates the Canvas
            GameObject[] ObjectArray = GameObject.FindObjectsOfType<GameObject>(); // Locates the Canvas
            Debug.Log("Player");
            for(int i = 0; i < ObjectArray.Length; i++)
            {
                Debug.Log("Object: "+ ObjectArray[i]);
            }
            Player.transform.position = StartLocation; // Puts the camera and player in  Inital Position
            Debug.Log("Made it");
            GameObject Character = GameObject.Find("MainCharacter");
            Rigidbody2D rb = Character.GetComponent<Rigidbody2D>();

            //Runs the test for a total of 10 runs, if it does not break the wall, the test passes
            for (int i = 0; i < 10; i++){
                //Function to give player velocity and reset if it hits the wall
                Player_Slide(currentSpeed, StartLocation, Character, rb);

                //Let the test run for 3 secconds
                yield return new WaitForSeconds(3);

                //Function to check if the player broke past the wall
                bool returnedValue = Check_Position(Character);

                if (returnedValue == false) {
                    currentSpeed += 1;
                    Debug.Log("Adding Speed - Current Speed: " + currentSpeed);
                }
                else {
                    Debug.Log("Asserting False - Final Speed: " + currentSpeed);
                    Assert.Pass();
                }
            }
            Assert.Fail();
            yield break;
        }

        //Function to setup the scene
        void SetupScene() {
            
            //Prefab with the Camera and Main Character
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TaeganCanvasNew"));

            //Prefab with the Cave Layout
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/TaeganGridNew"));
        }

        //Function to give the Main Character Velocity and reset the player
        void Player_Slide(int currentSpeed, Vector2 StartLocation, GameObject Player, Rigidbody2D rb) {
            //Debug.Log("Sliding: " + Player.transform.position.x);
            if (Player.transform.position.x > 236.73f && Player.transform.position.x < 236.75f) {
                //Debug.Log("Resetting Player");
                Player.transform.position = StartLocation;
            }
            rb.velocity = new Vector2(currentSpeed, 0);
        }

        //Function to check if the player is past the wall
        bool Check_Position(GameObject Player) {
            if (Player.transform.position.x > 237) {
                return true;
            }
            else {
                return false;
            }
        }

        /*
         *TaeganTest - Test Cases for TaeganScene
         * 
         * This Unity Test is a stress test to see when the number of Fog objects produced
         * per seccond becomes higher than the FPS
         *
         * After conducting 2 test We can create 268 - 378 fog objects on Taegan's Laptop
         * in 20 - 30 secconds before the FPS is lower than the Fob objects per Seccond
         */
        [UnityTest]
        public IEnumerator Fog_Creation_FPS_TestTW() {
            Vector2 StartLocation = new Vector2(42, -33); // The location to spawn the player
            SetupScene(); //Instantiates the Objects

            GameObject Player = GameObject.Find("TaeganCanvasNew(Clone)"); // Locates the Canvas
            Player.transform.position = StartLocation; // Puts the camera and player in  Inital Position

            //time variables to store FPS and Total Time
            var deltaTime = 0.0;
            var fps = 0.0;
            var timeBegin = 0.0;

            int count = 1; // counts the number of fog objects. Yes, 1 to start.
            yield return new WaitForSeconds(1);
            //Runs the test for a total of 10 runs, if it does not break the wall, the test passes
            for (int i = 0; i < 1000; i++) {
                //Function to create fog object
                create_Fog(StartLocation);

                //count Fog and Time
                count++;
                timeBegin += Time.deltaTime;

                //calcuate FPS
                deltaTime += Time.deltaTime;
                deltaTime /= 2.0;
                fps = 1.0 / deltaTime;
                Debug.Log("Frames: " + fps);

                // If frames drop below 10, stop the test
                if (fps < 15) {
                    var timeFinish = timeBegin % 60;
                    Debug.Log("The creation of Fog objects per seccond is now greater than the FPS!");
                    Debug.Log("Was able to create " + count + " fog objects before FPS < 15 in " + timeFinish + " seconds");
                    Assert.Pass();
                }

                //spawn Fog every 0.1 secconds (10 per seccond)
                yield return new WaitForSeconds(0.1f);

            }
            //If 1000 objects are created without dropping below 10 FPS we pass!
            Assert.Fail();
        }

        //Function to create fog objects and place them within the same location
        void create_Fog(Vector2 StartLocation)
        {
            GameObject Fog = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Fog"));
            Fog.transform.position = StartLocation;
        }
    }
}