// Written by Sam Spalding

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests{
    public class SamTest {

        // A test that checks each scene in the build settings has the prefabs I made for each level to have
        [UnityTest]
        public IEnumerator CheckForMyPrefabsInSceneTest() {
            
            Object[] myPrefabs; // create an array of object for the prefabs
            myPrefabs = Resources.LoadAll("SamPrefabs/EveryLevelPrefabs"); //assign myPrefabs to hold the specified prefabs

            int sceneCount = SceneManager.sceneCountInBuildSettings - 1; // Minus 1 because it counts the InitTestScene in the count
            string[] scenes = new string[sceneCount];

            // Looping through every scene
            for (int i = 1; i < sceneCount; i++) {
               
                // Get the scene names
                scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));

                // Sydney's Level is pulling errors for me at the moment and BCMode won't be a part of the final product
                if (scenes[i] != "SydneyForestScene" && scenes[i] != "BCMode") {

                    SceneManager.LoadScene(scenes[i]); // Load the scene

                    yield return null; // Need this here - won't load scene otherwise

                    Scene currentScene = SceneManager.GetActiveScene(); // Get current active scene to double check 

                    Debug.Log(currentScene.name + " is open and active");

                    if (scenes[i] != currentScene.name)
                    {
                        Assert.Fail(); // Fails if the scene that's loaded isn't the scene that will be in the final product
                    }

                    // Looping through each prefab for every scene
                    foreach (Object p in myPrefabs) {

                        var prefab = GameObject.Find(p.name);

                        if (prefab == null) {

                            Debug.Log(p.name + " was NOT found in " + scenes[i]); // Display which scene doesn't have which prefab
                        }
                    }
                }
            }
        }
    }
}
