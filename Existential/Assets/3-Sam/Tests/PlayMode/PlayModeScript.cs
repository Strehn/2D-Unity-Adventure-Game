using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;

namespace Tests
{
    public class PlayModeScript
    {
        
        [UnityTest]
        public IEnumerator Max_Inventory_Size()
        {
            SetUpScene("ToriScene");

            yield return null;
        }

        public void SetUpScene(string scenename)
        {
            SceneManager.LoadScene(scenename);
        }

    }
}
