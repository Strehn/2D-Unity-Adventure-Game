/***********************
Implemented by Victoria Gehring
This script overrides the OnPickup for normal flowers
and spawns a large unlockable flower on pickup
***********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInvItem : FlowerInvItem{

    public GameObject unlockFlower;
    public bool shrink = false;
    private IEnumerator coroutine;

    public override void OnPickup(){
        GameObject unlockFlowerObj = Instantiate(unlockFlower) as GameObject;
        unlockFlowerObj.SetActive(true);
        // unlockFlowerObj.transform.position = new Vector2(1, 1f);
        // Debug.Log("[ToolInvItem]");
        shrink = true;
        // shrinkItem();
        gameObject.SetActive(false);
    }
    /*
    public void shrinkItem(){
        GameObject unlockedItem = GameObject.Find("unlockflower_0(Clone)");
        Debug.Log("in shrink item");
        if (unlockedItem != null && shrink == true){
            coroutine = Wait(unlockedItem);
            StartCoroutine(coroutine);
            // unlockedItem.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
    */
    /*
    public IEnumerator ShrinkOverTime(){

    }
    */
    /*
    private IEnumerator Wait(GameObject gameObject){
        Vector3 shrink = new Vector3(0.5f, 0.5f, 0.5f);
        while (true)
        {
            Debug.Log("in shrink");
            yield return new WaitForSeconds(2);
            gameObject.transform.localScale -= shrink;
            yield return new WaitForSeconds(2);
            gameObject.transform.localScale -= shrink;
            yield return new WaitForSeconds(2);
            gameObject.transform.localScale -= shrink;
            yield return new WaitForSeconds(2);
            gameObject.transform.localScale -= shrink;

        }
    }
    */
}
