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
