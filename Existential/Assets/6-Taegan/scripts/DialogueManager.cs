using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text Textname;
    public Text DialogueText;

    //public Dialogue dialogue;
    private void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        Textname.text = dialogue.name;
        Debug.Log("Starting conversation with " + dialogue.name);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialouge()
    {
        Debug.Log("End of Conversation");
    }
}
