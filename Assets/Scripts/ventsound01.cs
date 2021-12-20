using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ventsound01 : MonoBehaviour
{
    public AudioSource audioSource;
    //plays sound on trigger enter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("no shit sherlock");
            audioSource.Play();
            audioSource.loop = true;
        }

    }

    //stops sound on exit
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.loop = false;
            audioSource.Stop();
        }
    }
}
