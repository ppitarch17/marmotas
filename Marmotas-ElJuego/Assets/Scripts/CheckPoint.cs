using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Light pointLight;
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            print("Jugador paso por checkpoint " + this.gameObject.name);
            LoseGame.UpdateLastCheckPoint(transform.position, this);
        }
        
    }

    public void TurnCheckPointLightOn(){
        pointLight.enabled = true;
    }

    public void TurnCheckPointLightOff(){
        pointLight.enabled = false;
    }
}
