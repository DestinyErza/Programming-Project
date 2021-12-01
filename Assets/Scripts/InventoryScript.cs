using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryScript : Singleton<InventoryScript>
{
    public List<Note> notes;
    public GameObject inventory;
    bool isInventory = false;

    void Start()
    {
        Time.timeScale = 1;
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
}
