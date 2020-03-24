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
        [Test]
        public void Check_For_Main_Character_In_Scene_Test()
        {
            var MC = GameObject.Find("MainCharacter");

            for (int i = 1; i < 8; i++)
            {
                SceneManager.LoadScene(i);
                string FailOutput = "Main Character not found in scene index " + i + ".";
                Assert.IsNotNull(MC, FailOutput);
            }
        }
    }
}
