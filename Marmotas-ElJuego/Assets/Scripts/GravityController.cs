using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerAnimatorController playerAnimatorController;
    public float gravityForce = 9.8f;
    public float timeBeforeStartingRotation = 0.5f;
    public float rotationDuration = 1f;
    public bool isRotating;
    public Direction lastDirection = Direction.Down;

    public enum Direction{
        Up, 
        Down,
        Left,
        Right,
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController._isGrounded)
            return;

        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            ChangeGravity(Direction.Up);
            StartCoroutine(RotateObject(gameObject, new Vector3(0, 0, -180f), rotationDuration, Direction.Up));
            lastDirection = Direction.Up;
        }
            
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            ChangeGravity(Direction.Down);
            StartCoroutine(RotateObject(gameObject, new Vector3(0, 0, 180), rotationDuration, Direction.Down));
            lastDirection = Direction.Down;
        }
            
        // if(Input.GetKeyDown(KeyCode.LeftArrow)){
        //     ChangeGravity(Direction.Left);
        //     //StartCoroutine(RotatePlayer(Direction.Left, rotationDuration));
        // }
        //     
        // if(Input.GetKeyDown(KeyCode.RightArrow)){
        //     ChangeGravity(Direction.Right);
        //     //StartCoroutine(RotatePlayer(Direction.Right, rotationDuration));
        // }
            


    }

    public void ChangeGravity(Direction direction){

        if(lastDirection == direction)
            return;

        Physics.gravity = direction switch
        {
            Direction.Up => new Vector3(0, gravityForce, 0),
            Direction.Down => new Vector3(0, -gravityForce, 0),
            Direction.Left => new Vector3(-gravityForce, 0, 0),
            Direction.Right => new Vector3(gravityForce, 0, 0),
            _ => Physics.gravity
        };

        playerAnimatorController.ChangeAnimation(PlayerAnimatorController.AnimationName.Jump1Normal, 0.1f, false);
    }
    IEnumerator RotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration, Direction direction){
        if (isRotating || lastDirection == direction)
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
