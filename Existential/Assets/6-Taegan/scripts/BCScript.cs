using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* BCScript.cs
* A script to enable BC Arrows to better navigate the ice maze
* TW
*/
public class BCScript: MonoBehaviour {
    public bool enabledArrows;
    GameObject[] allArrows;

    //function is called when the BC Button is clicked. Enables and disables the BC Arrow Game Objects
    public void ShowMeTheWay2() {
        
        allArrows = GameObject.FindGameObjectsWithTag("bcArrow");
        if (enabledArrows == false) {
            Debug.Log("enabling BC MODE");
            foreach (GameObject arrow in allArrows) {
                arrow.GetComponent<SpriteRenderer>().enabled = true;
                //Debug.Log(arrow + "Active");
            }
            enabledArrows = true;
        }
        else {
            Debug.Log("disabling BC MODE");
            foreach (GameObject arrow in allArrows) {
                arrow.GetComponent<SpriteRenderer>().enabled = false;
                //Debug.Log(arrow + "Disabled");
            }
            enabledArrows = false;
        }  
     }
 }