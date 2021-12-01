using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : GameBehaviour
{
    public GameObject particles;

    //for some reason this is not activating
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("enemy hit");
            collision.gameObject.GetComponent<Enemy>().Hit(5);
            //report to enemy that it has hit
            //   need something to determine amount of damage 
            Instantiate(particles, collision.collider.transform.position, collision.collider.transform.rotation);
            Destroy(this.gameObject);
        }

    }
}
