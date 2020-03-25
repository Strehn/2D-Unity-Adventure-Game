using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tests
{
    public class TaeganTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Check_For_Ground_Tag()
        {
            bool trueIfSceneHasTag = false;
            bool testFails = false;

            var assets = AssetDatabase.FindAssets("t:Scene");
            for (int i = 0; i < assets.Length; ++i)
            {
                var path = AssetDatabase.GUIDToAssetPath(assets[i]);
                EditorSceneManager.OpenScene(path, OpenSceneMode.Single);
                foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
                {
                    //Debug.Log(obj.tag);
                    if (obj.tag == "rock" || obj.tag == "snow" || obj.tag == "wood" || obj.tag == "town" || obj.tag == "forest" || obj.tag == "grass" || obj.tag == "house" || obj.tag == "graveyard")
                    {
                        Debug.Log("This object: " + obj.name + " in scene: " + EditorSceneManager.GetActiveScene().name + "has the tag: " + obj.tag);
                        trueIfSceneHasTag = true;
                    }
                }
                if (trueIfSceneHasTag == false)
                {
                    testFails = true;
                    Debug.Log("No Ground tag set in scene: " + EditorSceneManager.GetActiveScene().name);

                }
            }
                
                if(testFails == true) {
                    Assert.Fail();
                }
                else
                {
                    Assert.Pass();
                }
        }


        

    }
}





