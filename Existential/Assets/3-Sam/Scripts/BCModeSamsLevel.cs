
/***********************
Implemented by Victoria Gehring
When BC Mode button is clicked spawn
arrows and popup text to lead player to success
***********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BCModeSamsLevel : MonoBehaviour
{
    public int delay = 5;

    public void ShowMeTheWay()
    {
        GameObject firstArrow = GameObject.Find("thiswaybc");
        firstArrow.GetComponent<SpriteRenderer>().enabled = true;
        // Activate arrows that show path to success
        int i;
        for (i = 0; i < 16; i++)
        {
            try
            {
                string arrow;
                arrow = string.Format("thiswaybc ({0})", i);
                // Debug.Log("arrow is: " + arrow);
                GameObject hintArrow = GameObject.Find(arrow);
                // Debug.Log("hintArrow is: " + hintArrow);
                SpriteRenderer spriteArrow = hintArrow.GetComponent<SpriteRenderer>();
                spriteArrow.enabled = true;

            }
            catch
            {

            }
                
        }
        // Instantiate all the flowers needed for the level
        /*
        GameObject bcFlower1 = Instantiate(flowerPrefab1) as GameObject;
        bcFlower1.SetActive(true);
        bcFlower1.transform.position = new Vector2(5, 4f);

        GameObject bcFlower2 = Instantiate(flowerPrefab2) as GameObject;
        bcFlower2.SetActive(true);
        bcFlower2.transform.position = new Vector2(5, 6f);

        GameObject bcFlower3 = Instantiate(flowerPrefab3) as GameObject;
        bcFlower3.SetActive(true);
        bcFlower3.transform.position = new Vector2(4, 6f);

        GameObject bcFlower4 = Instantiate(flowerPrefab4) as GameObject;
        bcFlower4.SetActive(true);
        bcFlower4.transform.position = new Vector2(4, 3f);

        GameObject bcFlower5 = Instantiate(flowerPrefab5) as GameObject;
        bcFlower5.SetActive(true);
        bcFlower5.transform.position = new Vector2(4, 5f);

        GameObject bcFlower6 = Instantiate(flowerPrefab6) as GameObject;
        bcFlower6.SetActive(true);
        bcFlower6.transform.position = new Vector2(6, 3f);

        GameObject bcFlower7 = Instantiate(flowerPrefab7) as GameObject;
        bcFlower7.SetActive(true);
        bcFlower7.transform.position = new Vector2(6, 5f);

        GameObject bcFlower8 = Instantiate(flowerPrefab7) as GameObject;
        bcFlower8.SetActive(true);
        bcFlower8.transform.position = new Vector2(6, 4f);
        */
        // Show popup hint
        GameObject popUpHint = GameObject.Find("PopUpHint");
        StartCoroutine(ShowPathPopup(popUpHint));

    }

    IEnumerator ShowPathPopup(GameObject gameobj)
    {
        GameObject popup = GameObject.Find("PopUpHint");
        popup.GetComponent<Text>().enabled = true;
        gameobj.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(delay);
        GameObject bcbutton = GameObject.Find("BCMode");
        bcbutton.SetActive(false);
        gameobj.GetComponent<Text>().enabled = false;
    }

}

