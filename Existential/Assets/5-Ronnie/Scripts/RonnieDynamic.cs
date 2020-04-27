/**********************
 * Ronnie Keating - Static and Dynamic binding
 *
 * There are two classes: snow and the child of snow confetti
 *********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent class: snow
public class Snow : MonoBehaviour {
    //all child classes will contain isSpawn since it is virtual
    //function creates random value between 1 and spawnspeed, 
    //if value is under 2f, and we are not out of objects (based on iterators isDone),
    //spawn the object
    virtual public bool isSpawn(int numOfObjects, float spawnSpeed) {
        float poss;
        poss = Random.Range(1f, spawnSpeed);
        if(poss <= 2f && !RonnieIterate.isDone(numOfObjects)) {
            return true;
        }
        else {
            return false;
        }
    }

    //we still have a virtual function, but we override this in the children classes
    //could not implement with static for some reason
    //just set to white in this case
    public virtual void changeColor(GameObject obj){
        Color newColor = new Color(255, 255, 255);
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        renderer.material.SetColor("_Color", newColor);
    }
}

//child class
public class Confetti : Snow {
    //set color values
    Color red = new Color(255, 0, 0); //red
    Color blue = new Color(0, 0, 255); //blue
    Color yellow = new Color(255, 255, 0); //yellow
    Color green = new Color(0, 128, 0); //green
    Color purple = new Color(128, 0, 128); //purple
    //override the changeColor function
    //randomize the color of the particle
    //fetch spriterenderer and set the color
    public override void changeColor(GameObject obj) {
        int rand = Random.Range(1, 5);
        if(rand == 1) {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            renderer.material.SetColor("_Color", red);
        }
        else if(rand == 2) {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            renderer.material.SetColor("_Color", blue);
        }
        else if(rand == 3) {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            renderer.material.SetColor("_Color", yellow);
        }
        else if(rand == 4) {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            renderer.material.SetColor("_Color", green);
        }
        else if(rand == 5) {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            renderer.material.SetColor("_Color", purple);
        }
    }
}