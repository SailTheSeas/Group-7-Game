using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextAreaAttribute] public string[] dialogueLines;
    public int totalDialogue;

    public int GetTotalDialogueCount()
    {
        return totalDialogue;
    }

    public string[] GetDialogueLines()
    {
        return dialogueLines;
    }


}
