﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {

            FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
    }
}
