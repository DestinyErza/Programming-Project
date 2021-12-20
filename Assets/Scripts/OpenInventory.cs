using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : Singleton<OpenInventory>
{
    public GameObject inventory;
    bool isInventory = false;

    void Start()
    {
        //removes cursor from the screen, time = running
        Cursor.lockState = CursorLockMode.None;
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
        //when inventory is on time is paused and cursor is unlocked
        isInventory = !isInventory;
        if (isInventory)
        {
            inventory.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            _P.audioSource.Pause();
        }
        //when inventory is closed the game can be played and the cursor is locked
        else
        {
            inventory.SetActive(false);
            Time.timeScale = 1;
            //removes cursor from the screen
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
