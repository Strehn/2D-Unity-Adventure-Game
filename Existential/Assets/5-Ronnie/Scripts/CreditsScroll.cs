/**********************
 * Ronnie Keating
 * User input to read text at own pace
 * Pair Programming
 *********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroll : MonoBehaviour
{
    float positiony; //position y
    float positionx; // position x
    // Update is called once per frame
    void Update()
    {
        positiony = this.GetComponent<RectTransform>().position.y; //initialize each time
        positionx = this.GetComponent<RectTransform>().position.x;
        this.GetComponent<RectTransform>().position = new Vector2(positionx, positiony + 1f); //move text up 1f from curr y

        //buttons allow user to read credits at their own pace

        //if up arrow, move faster
        if(Input.GetKey("up"))
        {
            this.GetComponent<RectTransform>().position = new Vector2(positionx, positiony + 4f);
        }
        //if down arrow, scroll back down
        if(Input.GetKey("down"))
        {
            this.GetComponent<RectTransform>().position = new Vector2(positionx, positiony - 4f);
        }
    }
}
