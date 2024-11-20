using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    [SerializeField] private TMP_Text dialogueBox;
    [SerializeField] private Button nextDialogue;
    
    //[SerializeField] private Image imageDisplay;

    [SerializeField] private int totalDialogue;

    [SerializeField] private GameObject enemyDisp;

    [SerializeField] private float textStartDelay;
    [SerializeField] private float textCharacterDelay;
    [SerializeField] private string typingChar;
    [SerializeField] private bool hasTypingChar;
    [SerializeField] private string levelScene;
    [SerializeField] private GameObject nextLevelButton;

    [SerializeField] private bool startOnStart;

    private string[] dialogueLines;
    private bool isTyping, canClick;
    private string textWriter;
    private int dialogueTracker;   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        dialogueTracker = 0;
        totalDialogue = dialogue.GetTotalDialogueCount();
        dialogueLines = dialogue.GetDialogueLines();
        //dialogueBox.text = dialogueLines[dialogueTracker];
        textWriter = dialogueLines[dialogueTracker];
        dialogueTracker++;
        canClick = true;
        isTyping = true;
        if (startOnStart)
        {
            StartCoroutine(TypeTMP());            
        }
    }

    public void NextDialogue()
    {
        if (canClick)
        {
            if (!isTyping)
            {

                if (dialogueTracker < totalDialogue)
                {

                    dialogueBox.text = dialogueLines[dialogueTracker];
                    textWriter = dialogueLines[dialogueTracker];
                    dialogueTracker++;
                    isTyping = true;
                    StartCoroutine(TypeTMP());                   

                }
                else
                {
                    if (!startOnStart)
                        nextLevelButton.SetActive(true);
                    Debug.Log("The End");
                }
            }
            else
            {
                StopCoroutine(TypeTMP());
                isTyping = false;
                dialogueBox.text = textWriter;
            }
        }
    }
   

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(levelScene);
    }

    public void StopText()
    {
        StopCoroutine(TypeTMP());
        isTyping = false;
        dialogueBox.text = "";
    }

    public void StartText()
    {
        StartCoroutine(TypeTMP());
    }

    IEnumerator TypeTMP()
    {
        if (hasTypingChar)
            dialogueBox.text = typingChar;
        else
            dialogueBox.text = "";

        yield return new WaitForSeconds(textStartDelay);

        foreach (char c in textWriter)
        {
            if (isTyping)
            {
                if (dialogueBox.text.Length > 0)
                {
                    dialogueBox.text = dialogueBox.text.Substring(0, dialogueBox.text.Length - typingChar.Length);
                }
                dialogueBox.text += c;
                dialogueBox.text += typingChar;
                yield return new WaitForSeconds(textCharacterDelay);
            }
        }

        if (typingChar != "" && isTyping)
        {
            dialogueBox.text = dialogueBox.text.Substring(0, dialogueBox.text.Length - typingChar.Length);
        }
        isTyping = false;
        
    }
}
