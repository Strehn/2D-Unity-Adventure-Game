using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{

    private int inventory = 0;
    public Text inventoryText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        inventoryText.text = "INVENTORY : " + inventory;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory++;
        }
    }
}
