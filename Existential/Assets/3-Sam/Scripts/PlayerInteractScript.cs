using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractScript : MonoBehaviour
{
    private GameObject triggeringObject;
    private bool isTrigger;

    public GameObject text;

     void Update()
    {
        if (isTrigger)
        {
            text.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                triggeringObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
        else
        {
            text.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "interObject")
        {
            isTrigger = true;
            triggeringObject = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "interObject")
        {
            isTrigger = false;
            triggeringObject = null;
        }
    }
}