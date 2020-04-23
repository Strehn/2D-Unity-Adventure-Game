using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {
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

    public virtual void changeColor(GameObject obj){
        Color newColor = new Color(255, 255, 255);
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        renderer.material.SetColor("_Color", newColor);
    }
}

public class Confetti : Snow {
    Color red = new Color(255, 0, 0);
    Color blue = new Color(0, 0, 255);
    Color yellow = new Color(255, 255, 0);
    Color green = new Color(0, 128, 0);
    Color purple = new Color(128, 0, 128);
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