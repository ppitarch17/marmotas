using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Light pointLight;
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            print("Jugador paso por checkpoint " + this.gameObject.name);
            LoseGame.UpdateLastCheckPoint(this);
        }
        
    }

    //TODO correct z axis??
    public Vector3 GetPosition(){
        return new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void TurnCheckPointLightOn(){
        pointLight.enabled = true;
    }

    public void TurnCheckPointLightOff(){
        pointLight.enabled = false;
    }
}
