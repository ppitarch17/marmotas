using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public OpenDoor door;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("BoxDoor"))
            door.setCanBeOpened();
    }
}
