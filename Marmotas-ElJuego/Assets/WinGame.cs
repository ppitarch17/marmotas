using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public int orbsNedded = 0;
    public int orbsFound = 0;

    public void newOrbFound(){
        orbsFound++;
        if(orbsFound >= orbsNedded){
            Win();
        }
    }

    private void Win(){
        print("You won the gameeeee!!!");
    }
}
