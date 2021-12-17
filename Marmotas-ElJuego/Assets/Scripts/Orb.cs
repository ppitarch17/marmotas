using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public OrbPillar pillarAsociated;
    
    // Cuando el jugador toma un orbe se activa su pilar correspondiente y se destruye el orbe
    void OnCollisionEnter(Collision collision){
         if(collision.gameObject.CompareTag("Player")){
            pillarAsociated.SetPillarOn();
            Destroy(gameObject);
         }
    }
}
