using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public PlayerController playerController;
    public float gravityForce = 9.8f;
    public float timeBeforeStartingRotation = 0.5f;
    public float rotationDuration = 1f;
    public bool isRotating = false;

    public enum Direction{
        Up, 
        Down,
        Left,
        Right,
    }

    void Start()
    {
        //playerController = GetComponent<PlayerController>();
        //rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController._isGrounded)
            return;

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            ChangeGravity(Direction.Up);
            //StartCoroutine(RotatePlayer(Direction.Up, rotationDuration));
            StartCoroutine(rotateObject(gameObject, new Vector3(0, 0, -180f), rotationDuration));
        }
            
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            ChangeGravity(Direction.Down);
            //StartCoroutine(RotatePlayer(Direction.Down, rotationDuration));
             StartCoroutine(rotateObject(gameObject, new Vector3(0, 0, 180), rotationDuration));
        }
            
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            ChangeGravity(Direction.Left);
            StartCoroutine(RotatePlayer(Direction.Left, rotationDuration));
        }
            
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            ChangeGravity(Direction.Right);
            StartCoroutine(RotatePlayer(Direction.Right, rotationDuration));
        }
            


    }

    public void ChangeGravity(Direction direction){

        switch(direction){
            case Direction.Up:
                Physics.gravity = new Vector3(0, gravityForce, 0);
                break;
            case Direction.Down:
                Physics.gravity = new Vector3(0, -gravityForce, 0);
                break;
            case Direction.Left:
                Physics.gravity = new Vector3(-gravityForce, 0, 0);
                break;
            case Direction.Right:
                Physics.gravity = new Vector3(gravityForce, 0, 0);
                break;        
        }
    }

    IEnumerator RotatePlayer(Direction direction, float duration){
        yield return new WaitForSeconds(timeBeforeStartingRotation);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation;
        Vector3 endRotationVector = transform.position;

        switch(direction){
            case Direction.Up:
                endRotation = Quaternion.Euler(new Vector3(0, 0, -180f));
                endRotationVector = new Vector3(0, 0, -180f);
                break;
            case Direction.Down:
                endRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                endRotationVector = new Vector3(0, 0, 0);
                break;
            case Direction.Left:
                endRotation = Quaternion.Euler(new Vector3(0, 0, -90f));
                break;
            case Direction.Right:
                endRotation = Quaternion.Euler(new Vector3(0, 0, 90f));
                break;        
        }
        float t = 0.0f;
        while ( t  < duration ){

            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);

            yield return null;
            Debug.Log("dentro");
        }
         
    }

    IEnumerator rotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration){
        if (isRotating)
        {
            yield break;
        }
        
        isRotating = true;
        //Debug.Log("inside with: " + eulerAngles);
        yield return new WaitForSeconds(timeBeforeStartingRotation);

        Vector3 newRot = gameObjectToMove.transform.eulerAngles + eulerAngles;

        Vector3 currentRot = gameObjectToMove.transform.eulerAngles;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObjectToMove.transform.eulerAngles = Vector3.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        isRotating = false;
    }
}
