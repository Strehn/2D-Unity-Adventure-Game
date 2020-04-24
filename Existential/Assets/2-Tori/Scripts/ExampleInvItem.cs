using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ExampleInvItem : ToolInvItem{

    IEnumerator ShowItemPopup(){
        GameObject gameobj = GameObject.Find("exampleInvItemText");
        if (!gameobj.GetComponent<Text>().enabled){
            gameobj.GetComponent<Text>().enabled = true;
            yield return new WaitForSeconds(3);
            gameobj.GetComponent<Text>().enabled = false;
        }
        else{
            gameobj.GetComponent<Text>().enabled = false;
        }
    }
}
