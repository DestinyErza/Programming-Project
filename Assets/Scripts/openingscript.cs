using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingscript : MonoBehaviour
{
    public GameObject openingPanel;
   



    public void CloseOpening()
    {
        openingPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
