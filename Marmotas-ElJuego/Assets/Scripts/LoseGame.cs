using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    static GameObject player;
    static GravityController gravityController;
    static Rigidbody playerRigidBody;
    static CheckPoint lastCheckPoint;
    static Vector3 posIni;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        gravityController = player.GetComponentInChildren<GravityController>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        posIni = player.transform.position;
    }
    public static void KillPlayer(){
        //Cambiar pos del jugador
        if (lastCheckPoint != null) {
            player.transform.position = lastCheckPoint.GetPosition();
        }
        else {
            player.transform.position = posIni;
        }
        
        //Cambiar la gravedad Down
        gravityController.ChangeGravity(GravityController.Direction.Down);
        gravityController.resetRotation();

        //Poner velocidad a 0
        playerRigidBody.velocity = Vector3.zero;
    }

    public static void UpdateLastCheckPoint(CheckPoint newCheckPoint){
        if(lastCheckPoint != null)
            lastCheckPoint.TurnCheckPointLightOff();
        lastCheckPoint = newCheckPoint;
        lastCheckPoint.TurnCheckPointLightOn();
    }
}
