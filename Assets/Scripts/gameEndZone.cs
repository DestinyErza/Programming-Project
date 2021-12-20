using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameEndZone : GameBehaviour
{
     //  public AudioSource audioSource;

       public GameObject endScreen;
       bool isInventory = false;
       private void OnTriggerEnter(Collider other)
       {
          // audioSource.Play();
           ToggleInventory();
       }

       public void ToggleInventory()
       {
           //when inventory is on time is paused and cursor is unlocked
           isInventory = !isInventory;
           if (isInventory)
           {
               endScreen.SetActive(true);
               Time.timeScale = 0;
               Cursor.lockState = CursorLockMode.None;
               _P.audioSource.Pause();
           }
           //when inventory is closed the game can be played and the cursor is locked
           else
           {
               endScreen.SetActive(false);
               Time.timeScale = 1;
               //  Cursor.visible = false;
               //removes cursor from the screen
               Cursor.lockState = CursorLockMode.Locked;
           }

       }
 
    

}
