using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceMove : MonoBehaviour
{
    public bool activeButton = false;
    public bool timer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Debug.Log("activeButtonOn!");
            activeButton = true;
            timer = false;
            StartCoroutine(Countdown());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("activeButtonOff!");
        if (timer == true)
        {
            activeButton = false;
            timer = false;
        }
        
    }

    private IEnumerator Countdown()
    {
        float duration = 0.1f; // 3 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        timer = true;
    }
}
