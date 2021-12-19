using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinGame : MonoBehaviour
{
    public int orbsNedded = 0;
    public int orbsFound = 0;
    private TextMeshProUGUI texto;
    public GameObject UITextObject;
    public float showTimer = 1f;
    private IEnumerator coroutine;

    private void Start()
    {
        texto = UITextObject.GetComponentInChildren<TextMeshProUGUI>();
        //texto.text = orbsFound + "/" + orbsNedded;
        UITextObject.SetActive(false);
        
    }

    public void newOrbFound(){
        orbsFound++;
        if(orbsFound >= orbsNedded){
            Win();
        }
        
        //Mostrar texto por un tiempo
        texto.text = orbsFound + "/" + orbsNedded;
        coroutine = showTemporarily();
        if (!UITextObject.activeSelf) { // ya se esta mostrando el texto
            StartCoroutine(coroutine);
        }
        

        
    }
    
    IEnumerator showTemporarily() {

        if (UITextObject.activeSelf) {
            
        }
        
        UITextObject.SetActive(true);
        yield return new WaitForSeconds(showTimer);
        UITextObject.SetActive(false);
    }

    public void showTemporarly()
    {
        
    }

    private void Win(){
        print("You won the gameeeee!!!");
        LoseGame.KillPlayerByPrefab();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
