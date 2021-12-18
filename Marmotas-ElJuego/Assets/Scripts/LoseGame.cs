using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    static GameObject player;
    static GravityController gravityController;
    static PlayerController playerController;
    static Rigidbody playerRigidBody;
    static CheckPoint lastCheckPoint;
    static Vector3 posIni;

    static float loseCoolDown = 0.5f;
    public GameObject I_playerPrefab;
    static GameObject playerPrefab;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        gravityController = player.GetComponentInChildren<GravityController>();
        playerController = player.GetComponentInChildren<PlayerController>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        posIni = player.transform.position;
        playerPrefab = I_playerPrefab;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            //KillPlayer();
            KillPlayerByPrefab();
        }

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
        //gravityController.resetRotation();
        //gravityController.setGravityColdDown(loseCoolDown);
        //Poner velocidad a 0
        playerRigidBody.velocity = Vector3.zero;
    }

    public static void KillPlayerByPrefab()
    {
        gravityController.ChangeGravity(GravityController.Direction.Down);
        
        //obtener ultima posicion (ini si no hay)
        Vector3 posSpawn = posIni;
        if (lastCheckPoint != null) {
            posSpawn = lastCheckPoint.GetPosition();
        }

        //crea nuevo jugador y elimina jugador actual
        GameObject newPlayer = Instantiate(playerPrefab, posSpawn, Quaternion.Euler(new Vector3(0,-90, 0)));
        Destroy(player);
        player = newPlayer;
        gravityController = player.GetComponentInChildren<GravityController>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        CamerasManager.updatePlayerReferenceOnVirtualCameras(player.transform);
        //Las camaras no funcan bien si hacemos esto. Quien se encarga de determinar donde deben mirar las camaras?
    }
    
    public static void UpdateLastCheckPoint(CheckPoint newCheckPoint){
        if(lastCheckPoint != null)
            lastCheckPoint.TurnCheckPointLightOff();
        lastCheckPoint = newCheckPoint;
        lastCheckPoint.TurnCheckPointLightOn();
    }
}
