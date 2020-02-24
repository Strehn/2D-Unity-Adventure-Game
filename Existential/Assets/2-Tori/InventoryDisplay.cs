using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    //public int inventory = 0;
    public Text inventoryText;
    public Camera cam;
    public List<GameObject> inventoryList;
   
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObjectInv = GameObject.Find("InventoryTotal");
        inventoryText = gameObjectInv.GetComponent<Text>();
        cam = GetComponent<Camera>();
        // TODO: link drop item button from inv menu to this 
        // so that objects reappear when dropped
        GameObject.Find("apple").SetActive(true);
        GameObject.Find("axe").SetActive(true);
    }

    // Update is called once per frame
    public void Update()
    {
        inventoryText.text = "INVENTORY : " + inventoryList.Count;
        Debug.Log(inventoryList.Count);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            if(hit.collider.gameObject == GameObject.Find("apple"))
            {
                Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false);
                inventoryList.Add(hit.collider.gameObject);
            }
            if (hit.collider.gameObject == GameObject.Find("apple"))
            {
                Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false);
                inventoryList.Add(hit.collider.gameObject);
            }
            if (hit.collider.gameObject == GameObject.Find("axe"))
            {
                Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false);
                inventoryList.Add(hit.collider.gameObject);
            }

        }
        
    }

}
