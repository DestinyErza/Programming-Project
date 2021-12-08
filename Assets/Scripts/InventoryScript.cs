using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryScript : Singleton<InventoryScript>
{
    public List<Note> notes;
    public List<GameObject> notesGO;
    public GameObject inventory;
    bool isInventory = false;

    void Start()
    {
        Time.timeScale = 1;
        for(int I = 0; I < notesGO.Count; I ++) { notesGO[I].SetActive(false);}
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }


    public void ToggleInventory()
    {
        isInventory = !isInventory;
        if (isInventory)
        {
            inventory.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            inventory.SetActive(false);
            Time.timeScale = 1;
        }
    }
  //buttons: create new for each note
  //instanstiate a new note button and adds note to the button//getcomponent buttonnotes.note = pickedupnote

    //need to display text in new text when button is pressed
}
