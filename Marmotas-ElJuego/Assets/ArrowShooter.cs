using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public float waitBetweenShoots = 1f;
    private float timer;

    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;
    void Start()
    {
        
    }

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
        Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
    }
}
