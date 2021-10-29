using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
   private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            print("Jugador murio :( por " + this.gameObject.name);
            LoseGame.KillPlayer();
        }
        
    }
}
