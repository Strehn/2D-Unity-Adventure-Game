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

    //Start function, called once at the start
    public void Start() {
        enabledArrows = false; // initialize the boolean as false
        allArrows = GameObject.FindGameObjectsWithTag("bcArrow");
    }


    //function is called when the BC Button is clicked. Enables and disables the BC Arrow Game Objects
    public void ShowMeTheWay2() {   
        if (enabledArrows == false) {

            foreach (GameObject arrow in allArrows) {
                arrow.SetActive(true);
                enabledArrows = true;
            }
        }
        else {
            foreach (GameObject arrow in allArrows) {
                arrow.SetActive(false);
                enabledArrows = false;
            }
        }  
     }
 }