using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorLocked : MonoBehaviour
{
    public TMP_Text doorlocked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //ui proimpt
            doorlocked.text = ("The LAB02 seems to be locked, maybe there is another way around");

            StartCoroutine(ResetText());
        }
    }
    
    IEnumerator ResetText()
    {
        yield return new WaitForSeconds(2);
        doorlocked.text = "";
    }
}
