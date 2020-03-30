// Written by Sam Spalding

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests{
    public class SamTest {

        // Test to check to see if the my prefabs are present in each scene
        [UnityTest]
        public IEnumerator CheckForMyPrefabsInSceneTest() {
            
            Object[] myPrefabs;
            myPrefabs = Resources.LoadAll("SamPrefabs");

            int sceneCount = SceneManager.sceneCountInBuildSettings - 1; // Minus 1 because it counts the InitTestScene in the count
            string[] scenes = new string[sceneCount];

            for (int i = 1; i < sceneCount; i++) {
               
                scenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));

                if (scenes[i] != "SydneyForestScene" && scenes[i] != "BCMode") {

                    SceneManager.LoadScene(scenes[i]);

                    yield return null;

                    Scene currentScene = SceneManager.GetActiveScene();
                    Debug.Log(currentScene.name + " is open and active");

                    foreach (Object p in myPrefabs) {

                        var prefab = GameObject.Find(p.name);

                        if (prefab == null) {

                            Debug.Log(p.name + " was NOT found in " + scenes[i]);
                        }
                    }
                }
            }

            Assert.Fail();
        }
    }
}
