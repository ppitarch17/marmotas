using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPillar : MonoBehaviour
{
    public WinGame winGame;
    public void SetPillarOn(){
        print("Pillar ON!!");
        winGame.newOrbFound(); // Un nuevo orbe fue encontrado
    }
}
