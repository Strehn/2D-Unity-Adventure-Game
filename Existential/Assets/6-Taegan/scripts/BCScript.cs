using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCScript: MonoBehaviour
{
    public bool enabledArrows;
    GameObject[] allArrows;
    // Grabbed Toris Function from BcModeToriLevel

    public void Start()
    {
        enabledArrows = false;
        allArrows = GameObject.FindGameObjectsWithTag("bcArrow");
    }


    public void ShowMeTheWay2()
    {
              
        
        if (enabledArrows == false)
        {
            foreach (GameObject arrow in allArrows)
            {
                arrow.SetActive(true);
                enabledArrows = true;
                Debug.Log("setActive");
            }
        }
        else
        {
            foreach (GameObject arrow in allArrows)
            {
                arrow.SetActive(false);
                enabledArrows = false;
                Debug.Log("TurnedOff");
            }
        }  
      }

 }