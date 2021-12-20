using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledMovement : MonoBehaviour
{
    public float waitTime = 1;
    public float moveSpeed = 2;
    public Transform[] moveToPositions;
    int currentPosition = 0;



    //allows object to move only when the player collides with the collider, subtle "jmpscr"
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(MoveInDirection());
        }
    }
   


    //controls movement from one point to another
    IEnumerator MoveInDirection()
    {
        Vector3 _newPos = moveToPositions[currentPosition].position;
        while (Vector3.Distance(transform.position, _newPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _newPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        //makes it loop through all points
        yield return new WaitForSeconds(waitTime);

        if (currentPosition != moveToPositions.Length - 1)
            currentPosition = currentPosition + 1;
        else
            currentPosition = 0;
        StartCoroutine(MoveInDirection());
    }

   
}
