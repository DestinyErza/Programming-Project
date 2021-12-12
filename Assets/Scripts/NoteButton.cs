using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButton : Note
{

    public GameObject DisplayText;
    // Start is called before the first frame update
    void Start()
    {
        DisplayText.GetComponent<Text>();
      //  text.text = note
            //i think i need the last bit there
            _I.notesGO[_I.notes.Count].GetComponent<Note>().note = (other.gameObject.GetComponent<Note>().note);
        //  DisplayText.GetComponent<Text>() = "test" + note;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
