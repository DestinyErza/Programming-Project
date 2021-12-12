using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float xRotation = 0f;


   


    void Update()
    {
        //movement of camera aligned to mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //a clamp that locks the rotation to a min and max value
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      //uses player model as a base
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
