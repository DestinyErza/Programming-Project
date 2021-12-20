using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FiringPoint : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed = 1000f;
    public Transform firingpoint;

    public int ammo = 10;
   
    public TMP_Text ammocount;

    private void Start()
    {
        ammo = 10;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire2") & ammo >= 0)
        {
            //instantiates bullet prefab to fire
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, firingpoint.position, firingpoint.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingpoint.forward * projectileSpeed);
            Destroy(projectileInstance, 3f);
            ammo -= 1;
        }
  
        //displays ammo count, and on ammo count = 0 displays a message
        if(ammo <= 0)
        {
            ammocount.text = "You have no more ammo, good luck";
        }
        else
        {
            ammocount.text = "You have " + ammo + " ammo use it wisely";
        }


        
    
    }
   
}
