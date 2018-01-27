using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : Singleton<DialogueBox>
{
    public string dialogue;
    public float characterSpeed = 0.05f;
    public GameObject closeOption;
    public CanvasGroup canvasGroup;

    private Text dialogueText;
    private bool completed;
    private bool closePosible;    

    private void Awake()
    {
        dialogueText = GetComponent<Text>();
        canvasGroup.alpha = 0;
        closeOption.SetActive(false);
    }

    private void Start()
    {
        //Testing
        ShowDialogue("Hola como estás?? \nOhh que bien!");
    }

    public void ShowDialogue(string text)
    {
        canvasGroup.alpha = 1;
        completed = false;
        closePosible = false;
        dialogue = text;
        StartCoroutine(ShowDialogueCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (closePosible)
            {
                canvasGroup.alpha = 0;
                closeOption.SetActive(false);
            }
            else if(!completed)
            {
                ShowDialogue();
            }
            
        }
    }

    private void ShowDialogue()
    {
        completed = true;
        dialogueText.text = dialogue;
        StartCoroutine(ShowCloseDialogue());
    }

    private IEnumerator ShowDialogueCoroutine()
    {
        dialogueText.text = "";
        for (int i = 0; i < dialogue.Length; i++)
        {
            if (completed)
                yield break;
            dialogueText.text += dialogue[i];
            yield return new WaitForSeconds(characterSpeed);
        }
        completed = true;
        StartCoroutine(ShowCloseDialogue());
        yield return null;
    }

    private IEnumerator ShowCloseDialogue()
    {
        yield return new WaitForSeconds(1);
        closeOption.SetActive(true);
        closePosible = true;
    }
}
