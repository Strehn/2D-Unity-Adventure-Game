using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public int inventory = 0;
    public Text inventoryText;
    public Camera cam;
    bool ishit = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObjectInv = GameObject.Find("InventoryTotal");
        inventoryText = gameObjectInv.GetComponent<Text>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    public void Update()
    {
        
        inventoryText.text = "INVENTORY : " + inventory;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory++;
        }
        if (hit.collider != null)
        {
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            
            ishit = true;
            Debug.Log(hit.collider.gameObject);
            hit.collider.gameObject.SetActive(false);
            inventory++;
        }
        
    }

}
