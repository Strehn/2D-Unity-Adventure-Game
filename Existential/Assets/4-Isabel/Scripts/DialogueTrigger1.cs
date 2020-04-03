using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger1 : MonoBehaviour{
    public Dialogue1 dialogue1;
    
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager1>().StartDialogue(dialogue1);
    }
}
