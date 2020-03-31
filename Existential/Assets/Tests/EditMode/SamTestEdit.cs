using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tests {

    public class SamTestEdit {

        [UnityTest]
        public IEnumerator LevelSelectorTest() {

            EditorSceneManager.OpenScene("Assets/3-Sam/Scenes/MainMenu", OpenSceneMode.Single);


            yield return null;
        }
    }
}
