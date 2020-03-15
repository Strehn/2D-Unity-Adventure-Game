using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceMove : MonoBehaviour
{
    public bool activeButton = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Debug.Log("activeButtonOn!");
            activeButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("activeButtonOff!");
        activeButton = false;
    }

}
