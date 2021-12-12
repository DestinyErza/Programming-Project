using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryScript : Singleton<InventoryScript>
{
    public List<Note> notes;
    public List<GameObject> notesGO;
   
   

    void Start()
    {
    //for loop that allows the inventory no0tes to work
        for(int I = 0; I < notesGO.Count; I ++) { notesGO[I].SetActive(false);}
    }



}
