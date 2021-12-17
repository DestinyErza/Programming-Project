using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator _anim;

  private void Start()
    {
        _anim = GetComponent<Animator>();
    }


    //sets bool to true allowing the doors to open
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag( "Player"))
        {
            _anim.SetBool("Open", true);
        }
   
    }
}
