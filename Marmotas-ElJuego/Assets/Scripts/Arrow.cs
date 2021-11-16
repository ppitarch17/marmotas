using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody rb;
    public float DestoyAfter = 10f;
    public float initialForce = 10f;

    private float timer;

    void Start(){
        // Dispara la flecha con una fuerza inicial
        rb.velocity = transform.forward * initialForce;
    }
    void Update()
    {
        // Hace que la flecha apunte en direccion a la velocidad
        transform.rotation = Quaternion.LookRotation(rb.velocity);

        // Destruye la flecha si esta mucho tiempo activa
        if(timer >= DestoyAfter){
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
    }
}
