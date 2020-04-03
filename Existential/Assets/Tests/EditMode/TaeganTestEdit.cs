using NUnit.Framework;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tests {
    public class TaeganTestTW {
        /*
         *TaeganTest - Test Cases for TaeganScene
         * 
         * This Unity Test checks to see if a tag is set on an object within each
         * scene. This tag is critical to the sound of the player walking working
         * within the game. After conducting the test, the test passes if scenes
         * are returned that do not have the tag on at least 1 object.
         */

        [Test]
        public void Check_For_Ground_Tag() {

            bool trueIfSceneHasTag = false;
            bool testFails = false;
            var assets = AssetDatabase.FindAssets("t:Scene");

            //Itterate through each scene within the build settings
            for (int i = 0; i < assets.Length; ++i) {

                //Store and open the scene 
                var path = AssetDatabase.GUIDToAssetPath(assets[i]);
                EditorSceneManager.OpenScene(path, OpenSceneMode.Single);

                //Itterate through each object
                foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject))) {

                    // Check to see if the object has the tag
                    if (obj.tag == "rock" || obj.tag == "snow" || obj.tag == "wood" || obj.tag == "town" || obj.tag == "forest" || obj.tag == "grass" || obj.tag == "house" || obj.tag == "graveyard") {
                        Debug.Log("This object: " + obj.name + " in scene: " + EditorSceneManager.GetActiveScene().name + " has the tag: " + obj.tag);
                        trueIfSceneHasTag = true;
                    }
                }
                // If the scene does not have the tag on an object, print to console
                if (trueIfSceneHasTag == false) {
                    testFails = true;
                    Debug.Log("No Ground tag set in scene: " + EditorSceneManager.GetActiveScene().name);
                }
            }

            //Pass or fail test if atleast 1 scene does not have an object with one of the tags.
            if(testFails == true) {
                Assert.Pass();
            }
            else {
                Assert.Fail();
            }
        }
    }
}





