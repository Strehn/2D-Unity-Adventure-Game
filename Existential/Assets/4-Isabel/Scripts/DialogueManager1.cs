// Created by Isabel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager1 : MonoBehaviour{
    public Text nameText;
    public Text dialogueText;

    private Queue <string> sentences;

    // Start is called before the first frame update
    void Start(){
        sentences = new Queue <string>();
    }

    public void StartDialogue(Dialogue1 dialogue1){
        nameText.text = dialogue1.name;
        sentences.Clear();

        foreach (string sentence in dialogue1.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        Debug.Log("End of conversation.");
    }
}
