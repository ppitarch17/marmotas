using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{

    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    private float timer;
    public float waitBetweenShoots = 1f;
    public float arrowInitialForce = 15f;

    public bool arrowsReactToGravity = true;

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
            ShootArrow();
            timer = waitBetweenShoots;
        }
        timer -= Time.deltaTime;
    }

    public void ShootArrow(){
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        arrow.GetComponent<Arrow>().initialForce = arrowInitialForce;

        if(!arrowsReactToGravity)
            arrow.GetComponent<Rigidbody>().isKinematic = true;
    }
}
