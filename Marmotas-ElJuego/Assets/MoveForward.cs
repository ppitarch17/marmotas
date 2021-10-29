using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float DestoyAfter = 5f;
    public float velocity = 1f;
    public float timer = 0f;
    void Update()
    {
        transform.position += transform.forward * velocity;

        if(timer >= DestoyAfter){
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
    }
}
