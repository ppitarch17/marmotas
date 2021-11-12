using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public BoxCollider cameraBox;
    public Transform transformRotation;
    public Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            transformRotation.rotation(y, -90);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            transformRotation.rotation(y, 0);

        }
    }
}
