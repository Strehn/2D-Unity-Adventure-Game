using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SamTest
    {
        [Test]
        public void CheckForMyPrefabsInSceneTest()
        {
            EditorSceneManager.OpenScene("Assets/3-Sam/Scenes/SamScene.unity", OpenSceneMode.Single);
            var go = GameObject.Find("MainCharacter");
            Assert.IsNotNull(go, "MainCharacter not found in scene.");
            Assert.Null(go, "MainCharacter was found in the scene.");
            
        }
    }
}

