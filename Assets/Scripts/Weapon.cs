using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //goes on enemy  weapon + convex mesh collider(((each weapon)!!!
    public float damage = 20;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         //   _P.Hit(damage);
        }
    }
}
