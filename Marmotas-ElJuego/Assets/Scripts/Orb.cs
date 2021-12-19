using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public OrbPillar pillarAsociated;
    public bool teleportToHall;
    public Transform hall;

    
    // Cuando el jugador toma un orbe se activa su pilar correspondiente y se destruye el orbe
    void OnCollisionEnter(Collision collision){
         if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BoxDoor")){
            pillarAsociated.SetPillarOn();
            if(teleportToHall) {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = hall.position;
            }
            Destroy(gameObject);
         }
         
    }
}
