// Sydney Petrehn

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BCForest : MonoBehaviour{

        //moves player to end and spawns four orbs needed to end level.
        public void forestBCMode(){

        GameObject mainChar = GameObject.Find("MainCharacter");
        Vector2 EndLocation = new Vector2(23, 15);
        Vector2 OrbLocation = new Vector2(21, 15);
        GameObject SpiritOrb1 = GameObject.Find("SpiritOrb");
        GameObject SpiritOrb2 = GameObject.Find("SpiritOrb (1)");
        GameObject SpiritOrb3 = GameObject.Find("SpiritOrb (2)");
        GameObject SpiritOrb4 = GameObject.Find("SpiritOrb (3)");

         //Move to end location
         mainChar.transform.position = EndLocation;

         //Move orbs to end location
         SpiritOrb1.transform.position = OrbLocation;
         SpiritOrb2.transform.position = OrbLocation;
         SpiritOrb3.transform.position = OrbLocation;
         SpiritOrb4.transform.position = OrbLocation;
    }
}
         

