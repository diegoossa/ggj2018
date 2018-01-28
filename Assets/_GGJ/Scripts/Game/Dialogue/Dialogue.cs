using System;
using UnityEngine;

[Serializable]
public struct Dialogue
{
    public int id;
    [Multiline]
    public string englishDialogue;
    [Multiline]
    public string spanishDialogue;
    [Multiline]
    public string russianDialogue;
}
