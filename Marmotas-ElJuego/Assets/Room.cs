using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room  : MonoBehaviour
{

    public GameObject vCam;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            vCam.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            vCam.SetActive(false);
        }
    }
}
