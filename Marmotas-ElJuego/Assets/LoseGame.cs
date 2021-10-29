using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour{

    //CheckPoint Information
    static PlayerController playerController;
    static GravityController gravityController;
    static Vector3 positionCheckPoint;
    static Quaternion rotationPlayerAtCheckPoint;
    static GravityController.Direction directionPlayerAtCheckPoint;
    static Transform playerTransform;

    static CheckPoint lastCheckPoint;


    void Start(){
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        gravityController = playerTransform.GetComponentInChildren<GravityController>();
        playerController = playerTransform.GetComponent<PlayerController>();

        //Hace que el primer Checkpoint sea donde el jugador empieza el juego (objeto checkpoint es null)
        UpdateLastCheckPoint(playerTransform.position, null);
    }
    public static void KillPlayer(){
        
        //Cambia la posicion del jugador en x y (no en z para que continue en la misma linea)
        playerTransform.position = new Vector3(positionCheckPoint.x, positionCheckPoint.y, playerTransform.position.z);

        //Cambia la direccion de la gravedad para .Down
        gravityController.ChangeGravity(GravityController.Direction.Down);
        gravityController.SetRotation(Quaternion.Euler(new Vector3(0,-90,0)));
        gravityController.setLastDirection(GravityController.Direction.Down);

        //Reset en la velcidad (para que no haga spawn en movimiento)
        playerController.resetRigidBodyVelocity();

    }
    public static void UpdateLastCheckPoint(Vector3 newPosition, CheckPoint newCheckPoint){

        //Cuando el jugador entra en un Checkpoint se llama a este metodo
        //Actualiza la posicion al ultimo Checkpoint
        positionCheckPoint = newPosition;

        //Enciende las luces del nuevo Checkpoint y apaga las del viejo
        if(lastCheckPoint != null)
            lastCheckPoint.TurnCheckPointLightOff();
        if(newCheckPoint != null)
        newCheckPoint.TurnCheckPointLightOn();

        lastCheckPoint = newCheckPoint;

        //rotationPlayerAtCheckPoint = newRotationPlayer;
        //directionPlayerAtCheckPoint = gravityController.lastDirection;
    }
}
