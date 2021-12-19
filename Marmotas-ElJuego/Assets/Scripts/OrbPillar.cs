using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPillar : MonoBehaviour
{
    public WinGame winGame;
    public Material onMaterial;

    private void Start()
    {
        //asi no tenemos que modificar winGame cada vez que añadimos un nuevo orbe al nivel
        winGame.orbsNedded++;
    }

    public void SetPillarOn(){
        print("Pillar ON!!");
        gameObject.GetComponentInChildren<MeshRenderer>().material = onMaterial;
        gameObject.GetComponentInChildren<Light>().enabled = true;
        winGame.newOrbFound(); // Un nuevo orbe fue encontrado
    }
}
