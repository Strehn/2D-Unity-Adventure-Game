// Written by Sam Spalding

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
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

        [UnityTest]
        public IEnumerator LevelSelectorTest() {

            Scene currentScene;

            SceneManager.LoadScene(0);
            yield return null;
            Button levelSelectBtn = GameObject.Find("LevelSelectButton").GetComponent<Button>();
            levelSelectBtn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            Button level1Btn = GameObject.Find("Level1Button").GetComponent<Button>();
            Assert.IsNotNull(level1Btn);
            level1Btn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            currentScene = SceneManager.GetActiveScene();
            Debug.Log("Current Scene: " + currentScene.name);

            if (currentScene.name != "SamScene")
            {
                Assert.Fail();
            }

            SceneManager.LoadScene(0);
            yield return null;
            levelSelectBtn = GameObject.Find("LevelSelectButton").GetComponent<Button>();
            levelSelectBtn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            Button level2Btn = GameObject.Find("Level2Button").GetComponent<Button>();
            Assert.IsNotNull(level2Btn);
            level2Btn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            currentScene = SceneManager.GetActiveScene();
            Debug.Log("Current Scene: " + currentScene.name);

            if (currentScene.name != "Isabel Level")
            {
                Assert.Fail();
            }

            SceneManager.LoadScene(0);
            yield return null;
            levelSelectBtn = GameObject.Find("LevelSelectButton").GetComponent<Button>();
            levelSelectBtn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            /*Button level3Btn = GameObject.Find("Level3Button").GetComponent<Button>();
            Assert.IsNotNull(level3Btn);
            level3Btn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            currentScene = SceneManager.GetActiveScene();

            if(currentScene.name != "SydneyForestScene")
            {
                Assert.Fail();
            }

            SceneManager.LoadScene(0);
            yield return null;
            levelSelectBtn = GameObject.Find("LevelSelectButton").GetComponent<Button>();
            levelSelectBtn.onClick.Invoke();

            yield return new WaitForSeconds(3);
            */

            Button level4Btn = GameObject.Find("Level4Button").GetComponent<Button>();
            Assert.IsNotNull(level4Btn);
            level4Btn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            currentScene = SceneManager.GetActiveScene();
            Debug.Log("Current Scene: " + currentScene.name);

            if (currentScene.name != "ToriScene")
            {
                Assert.Fail();
            }

            SceneManager.LoadScene(0);
            yield return null;
            levelSelectBtn = GameObject.Find("LevelSelectButton").GetComponent<Button>();
            levelSelectBtn.onClick.Invoke();

            yield return new WaitForSeconds(1);
            
            Button level5Btn = GameObject.Find("Level5Button").GetComponent<Button>();
            Assert.IsNotNull(level5Btn);
            level5Btn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            currentScene = SceneManager.GetActiveScene();
            Debug.Log("Current Scene: " + currentScene.name);

            if (currentScene.name != "TaeganScene")
            {
                Assert.Fail();
            }

            SceneManager.LoadScene(0);
            yield return null;
            levelSelectBtn = GameObject.Find("LevelSelectButton").GetComponent<Button>();
            levelSelectBtn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            Button level6Btn = GameObject.Find("Level6Button").GetComponent<Button>();
            Assert.IsNotNull(level6Btn);
            level6Btn.onClick.Invoke();

            yield return new WaitForSeconds(1);

            currentScene = SceneManager.GetActiveScene();
            Debug.Log("Current Scene: " + currentScene.name);

            if (currentScene.name != "RonnieScene")
            {
                Assert.Fail();
            }

            yield return null;
        }

        [UnityTest]
        public IEnumerator SpawnDialogueCanvasTest()
        {

            var T = 1 / Time.deltaTime;
            for (int i = 0; i < 100; i++)
            {

                T = 1 / Time.deltaTime;
                for (int j = 0; j < 100; j++)
                {
                    MonoBehaviour.Instantiate(Resources.Load<GameObject>("SamPrefabs/EveryLevelPrefabs/DialogueCanvas"));
                }
                T = 1 / Time.deltaTime;
                Debug.Log(T);
                yield return new WaitForSeconds(1);
                if (T < 15)
                {
                    Debug.Log((i + 1) * 100);
                    if (i < 10) Assert.Fail();
                    yield break;
                }
            }
        }
    }
}
