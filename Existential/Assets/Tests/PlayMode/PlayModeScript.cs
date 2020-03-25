using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System;

namespace Tests{
    public class PlayModeScript{
        //Written by Sam Spalding
        //Test to check to see if the game object "MainCharacter" is present in each scene
        //This may actually be a test for Isabel since she's the own in charge of the main character, but I don't know anymore.
        [Test]
        public void Check_For_Main_Character_In_Scene_Test(){
            var MC = GameObject.Find("MainCharacter"); //create a variable that holds a gameobject call "MainCharacter"

            //for each scene index in the Build Settings
            for (int i = 1; i < 8; i++){
                SceneManager.LoadScene(i); //Load the scene indicated by the scene index

                //an output for which scene doesn't have a "MainCharacter" game object
                string failOutput = "Main Character not found in scene index " + i + "."; 

                //Check to see that variable MC "is not null" (or holds *something* where that something should be the MainCharacter. 
                //If variale MC is found to be NULL, then print the FailOutput
                Assert.IsNotNull(MC, failOutput); 
            }
        }
    }
}
