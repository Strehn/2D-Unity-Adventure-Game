using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCScript: MonoBehaviour
{

    // Grabbed Toris Function from BcModeToriLevel
    public void ShowMeTheWay2()
    {
        //if (flag == 0)
        //{
        //    flag = 1;
        //}
        //else
        //{
        //    flag = 0;
        //}
             // look for the image in the scene to show where all the flowers are
            int i;
        for (i = 4; i < 35; i++)
        {
            string arrow;
            arrow = string.Format("thiswaybc ({0})", i);
            Debug.Log("arrow is: " + arrow);
            GameObject hintArrow = GameObject.Find(arrow);
            Debug.Log("hintArrow is: " + hintArrow);
            SpriteRenderer spriteArrow = hintArrow.GetComponent<SpriteRenderer>();
            spriteArrow.enabled = true;
            //hintArrow.SetActive(true);
        }

    }
}