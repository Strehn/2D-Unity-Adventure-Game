using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCModeToriLevel : MonoBehaviour{
    public int delay = 5;
    public GameObject flowerPrefab1;
    public GameObject flowerPrefab2;
    public GameObject flowerPrefab3;
    public GameObject flowerPrefab4;
    public GameObject flowerPrefab5;
    public GameObject flowerPrefab6;
    public GameObject flowerPrefab7;
    public GameObject flowerPrefab8;
    public GameObject flowerPrefab9;
    public GameObject flowerPrefab10;

    public void ShowMeTheWay(){
        // look for the image in the scene to show where all the flowers are
        int i;
        for(i = 1; i < 9; i++){
            string arrow;
            arrow = string.Format("thiswaybc ({0})", i);
            // Debug.Log("arrow is: " + arrow);
            GameObject hintArrow = GameObject.Find(arrow);
            // Debug.Log("hintArrow is: " + hintArrow);
            SpriteRenderer spriteArrow = hintArrow.GetComponent<SpriteRenderer>();
            spriteArrow.enabled = true;
            //hintArrow.SetActive(true);
        }
        Instantiate(flowerPrefab1, new Vector3(45, 3, 90), Quaternion.identity);
        Instantiate(flowerPrefab2, new Vector3(45, 3, 90), Quaternion.identity);
        Instantiate(flowerPrefab3, new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(flowerPrefab4, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Instantiate(flowerPrefab5, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Instantiate(flowerPrefab6, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Instantiate(flowerPrefab7, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Instantiate(flowerPrefab8, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Instantiate(flowerPrefab9, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        Instantiate(flowerPrefab10, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        GameObject popUpHint = GameObject.Find("PopUpHint");
        StartCoroutine(ShowPathPopup(popUpHint));

    }

    IEnumerator ShowPathPopup(GameObject gameobj){
        gameobj.SetActive(true);
        yield return new WaitForSeconds(delay);
    }
   
}
