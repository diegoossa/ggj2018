using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizatedText : MonoBehaviour
{
    private Text text;

    [Multiline]
    public string englishDialogue;
    [Multiline]
    public string spanishDialogue;
    [Multiline]
    public string russianDialogue;

    // Use this for initialization
    void Awake()
    {
        text = GetComponent<Text>();

    }

    void Start()
    {
        switch (GameManager.Instance.currentLanguage)
        {
            case "English":
                text.text = englishDialogue;
                break;
            case "Spanish":
                text.text = spanishDialogue;
                break;
            case "Italian":
                text.text = russianDialogue;
                break;
            default:
                text.text = spanishDialogue;
                break;
        }
    }
}
