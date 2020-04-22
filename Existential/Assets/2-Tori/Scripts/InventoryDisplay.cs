
/***********************
Implemented by Victoria Gehring
This script handles the addition of new inventory items
by checking the mouse position is over an inventory item
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public Camera cam;
    
    public void Start(){
        cam = GetComponent<Camera>();
    }

    public void Update(){
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        // [DEPRECATED] RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        // IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        
        if (hit.collider != null){
            IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
            if(item != null){
                Debug.Log("[InventoryDisplay] adding item");
                inventory.AddItem(item);
            }
        }
    
    }
    /*
    // [DEPRECATED] Used in minimum runnable code demo
    public void Drop()
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.DropItem(item);
        }
    }
    */
    /*
    public Text inventoryText;
    public Text itemPickupText;
    public Camera cam;
    public List<GameObject> inventoryList;
   
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObjectInv = GameObject.Find("InventoryTotal");
        inventoryText = gameObjectInv.GetComponent<Text>();
        GameObject gameObjectItemPickup = GameObject.Find("ItemPickup");
        itemPickupText = gameObjectItemPickup.GetComponent<Text>();
        cam = GetComponent<Camera>();
        itemPickupText.enabled = false;
        // TODO: link drop item button from inv menu to this 
        // so that objects reappear when dropped
        GameObject.Find("apple").SetActive(true);
        GameObject.Find("axe").SetActive(true);
        GameObject.Find("axe1").SetActive(true);
    }

    // Update is called once per frame
    public void Update()
    {
         if (Input.GetKey("escape")){
            Application.Quit();
        }
        inventoryText.text = "INVENTORY : " + inventoryList.Count;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            if(hit.collider.gameObject == GameObject.Find("apple"))
            {
                Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false);
                inventoryList.Add(hit.collider.gameObject);
                StartCoroutine(ShowTextPopup(hit.collider.gameObject, 2));
                
            }
            if (hit.collider.gameObject == GameObject.Find("axe"))
            {
                Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false);
                inventoryList.Add(hit.collider.gameObject);
                StartCoroutine(ShowTextPopup(hit.collider.gameObject, 2));
            }
            if (hit.collider.gameObject == GameObject.Find("axe1"))
            {
                Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false);
                inventoryList.Add(hit.collider.gameObject);
                StartCoroutine(ShowTextPopup(hit.collider.gameObject, 2));
            }

        }
        
    }

    IEnumerator ShowTextPopup(GameObject gameobj, float delay)
    {
        itemPickupText.text = "You found an " + gameobj.name;
        itemPickupText.enabled = true;
        yield return new WaitForSeconds(delay);
        itemPickupText.enabled = false;
    }
    */
}

