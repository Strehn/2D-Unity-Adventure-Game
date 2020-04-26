/***********************
Implemented by Victoria Gehring
This script overrides the OnDrop for normal flowers
instead of returning the item to it's initial position
it will disappear from the level.
***********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftInvItem : FlowerInvItem{

    public bool giftedItem = false;

    public override void OnDrop(){
        giftedItem = true;
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
