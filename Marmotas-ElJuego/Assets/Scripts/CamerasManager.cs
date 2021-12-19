using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    static CinemachineVirtualCamera[] virtualCameras;
    
    // Start is called before the first frame update
    void Start()
    {
        virtualCameras = Resources.FindObjectsOfTypeAll(typeof(CinemachineVirtualCamera)) as CinemachineVirtualCamera[];
    }

    // Update is called once per frame
    public static void updatePlayerReferenceOnVirtualCameras(Transform player)
    {
        foreach (CinemachineVirtualCamera camera in virtualCameras) {
            camera.Follow = player;
        }
    }
}
