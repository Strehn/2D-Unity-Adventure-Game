using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueScript {

    public string NPCname;

    [TextArea(3, 10)]
    public string[] sentences;
}
