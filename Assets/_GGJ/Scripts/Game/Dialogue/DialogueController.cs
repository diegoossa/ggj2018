using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : Singleton<DialogueController>
{
    [SerializeField]
    private float characterSpeed = 0.05f;
    [Header("Dialogue")]
    [SerializeField]
    private GameObject dialogueObject;
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    public GameObject closeOption;
    [Header("Comments")]
    [SerializeField]
    private GameObject commentObject;
    [SerializeField]
    private Text commentText;

    private string dialogue;
    private bool completed;
    private bool closePosible;

    private void Start()
    {
        closeOption.SetActive(false);
        dialogueObject.SetActive(false);
        commentObject.SetActive(false);
        //Testing
        //ShowDialogue("Hola como estás?? \nOhh que bien!");
        ShowComment("Hola como estás?? \nOhh que bien!");
    }

    public void ShowDialogue(string text)
    {
        dialogueObject.SetActive(true);
        completed = false;
        closePosible = false;
        dialogue = text;
        StartCoroutine(ShowDialogueCoroutine());
    }

    public void ShowComment(string text)
    {
        commentObject.SetActive(true);
        StartCoroutine(ShowCommentCoroutine(text));
    }

    private IEnumerator ShowCommentCoroutine(string text)
    {
        commentText.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            commentText.text += text[i];
            yield return new WaitForSeconds(characterSpeed);
        }
        yield return new WaitForSeconds(1f);
        commentObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (closePosible)
            {
                dialogueObject.SetActive(false);
                closeOption.SetActive(false);
            }
            else if (!completed)
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
