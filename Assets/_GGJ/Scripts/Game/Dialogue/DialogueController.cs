using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : Singleton<DialogueController>
{
    [Header("Dialogue List")]
    [SerializeField]
    private DialogueList dialogues;
    [Header("Dialogue Settings")]
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
    private string comment;
    private bool completed;
    private bool closePosible;
    private AudioSource audioSource;

    public AudioClip[] talks;

    private void Start()
    {
        closeOption.SetActive(false);
        dialogueObject.SetActive(false);
        commentObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void ShowDialogue(string text)
    {
        dialogueObject.SetActive(true);
        completed = false;
        closePosible = false;
        dialogue = text;
        StartCoroutine(ShowDialogueCoroutine());
    }

    public void ShowDialogue(int id)
    {
        dialogue = "";
        dialogueObject.SetActive(true);
        completed = false;
        closePosible = false;



        audioSource.clip = talks[Random.Range(0, talks.Length)];
        audioSource.Play();


        switch (GameManager.Instance.currentLanguage)
        {
            case "English":
                dialogue = dialogues.dialogues[id].englishDialogue;
                break;
            case "Spanish":
                dialogue = dialogues.dialogues[id].spanishDialogue;
                break;
            case "Italian":
                dialogue = dialogues.dialogues[id].russianDialogue;
                break;
            default:
                dialogue = dialogues.dialogues[id].spanishDialogue;
                break;
        }

        StartCoroutine(ShowDialogueCoroutine());
    }

    public void ShowComment(string text)
    {

        audioSource.clip = talks[Random.Range(0, talks.Length)];
        audioSource.Play();

        commentObject.SetActive(true);
        comment = text;
        StartCoroutine(ShowCommentCoroutine());
    }

    public void ShowComment(int id)
    {

        audioSource.clip = talks[Random.Range(0, talks.Length)];
        audioSource.Play();

        comment = "";
        commentObject.SetActive(true);
        switch (GameManager.Instance.currentLanguage)
        {
            case "English":
                comment = dialogues.dialogues[id].englishDialogue;
                break;
            case "Spanish":
                comment = dialogues.dialogues[id].spanishDialogue;
                break;
            case "Italian":
                comment = dialogues.dialogues[id].russianDialogue;
                break;
            default:
                comment = dialogues.dialogues[id].spanishDialogue;
                break;
        }

        StartCoroutine(ShowCommentCoroutine());
    }

    private IEnumerator ShowCommentCoroutine()
    {
        CancelInvoke("DeactiveComment");
        commentText.text = "";
        for (int i = 0; i < comment.Length; i++)
        {
            commentText.text += comment[i];
            yield return new WaitForSeconds(characterSpeed);
        }
        Invoke("DeactiveComment", 2f);
    }

    private void DeactiveComment()
    {
        commentObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(JsonUtility.ToJson(dialogues));

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
