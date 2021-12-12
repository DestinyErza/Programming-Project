using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed = 1000f;
    public Transform firingpoint;

   // public GameObject[] weaponSelect;

 


    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, firingpoint.position, firingpoint.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingpoint.forward * projectileSpeed);
            Destroy(projectileInstance, 3f);
        }
    }
}
