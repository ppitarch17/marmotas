using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public bool destroyAfterTriggerEnter = false;
    
    /* 
   private void OnTriggerEnter(Collider other){
       //print("ENTER TRIGGER COLLIDER ARROW: " + other.name);
        if(other.CompareTag("Player")){
            print("Jugador murio :( por " + this.gameObject.name);
            LoseGame.KillPlayer();
        }
        
    } */

    void OnCollisionEnter(Collision collision){
        //print("ENTER COLLIDER COLLIDER ARROW: " + collision.gameObject.name);

        if(collision.gameObject.CompareTag("Player")){
            //LoseGame.KillPlayer();
            LoseGame.KillPlayerByPrefab();
        }
        
        if(destroyAfterTriggerEnter)
            Destroy(gameObject);
        
        
    }

}
