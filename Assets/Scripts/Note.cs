using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    public string note;

    public TMP_Text DisplayText;
    public TMP_Text NoteCount;


    public void SetText(string text)
    {
        DisplayText.text = note;
    }


}
