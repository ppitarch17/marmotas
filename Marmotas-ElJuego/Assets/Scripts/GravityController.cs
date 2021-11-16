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

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController._isGrounded)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        { //Va a techo
            ChangeGravity(Direction.Up);

            /* if (lastDirection == Direction.Down)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(0, 0, -180), rotationDuration, Direction.Up));
            }
            else if (lastDirection == Direction.Right)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(90, 0, -180), rotationDuration, Direction.Up));
            }
            else if (lastDirection == Direction.Left)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(-90, 0, -180), rotationDuration, Direction.Up));
            } */

            StartCoroutine(RotatePlayer(Direction.Up, rotationDuration));

            lastDirection = Direction.Up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        { //Va a piso
            ChangeGravity(Direction.Down);

            /* if (lastDirection == Direction.Up)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(0, 0, 180), rotationDuration, Direction.Down));
            }
            else if (lastDirection == Direction.Right)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(-90, 0, 0), rotationDuration, Direction.Down));
            }
            else if (lastDirection == Direction.Left)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(90, 0, 0), rotationDuration, Direction.Down));
            } */

            StartCoroutine(RotatePlayer(Direction.Down, rotationDuration));
            lastDirection = Direction.Down;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { // Va a pared izq
            ChangeGravity(Direction.Left);
/* 
            if (lastDirection == Direction.Up)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(90, 0, 180), rotationDuration, Direction.Left));
            }
            else if (lastDirection == Direction.Down)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(-90, 0, 0), rotationDuration, Direction.Left));
            }
            else if (lastDirection == Direction.Right)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(-180, 0, 0), rotationDuration, Direction.Left));
            } */

            StartCoroutine(RotatePlayer(Direction.Left, rotationDuration));
            lastDirection = Direction.Left;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        { // Va a pared der
            ChangeGravity(Direction.Right);
/* 
            if (lastDirection == Direction.Up)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(90, 0, 180), rotationDuration, Direction.Right));
            }
            else if (lastDirection == Direction.Down)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(90, 0, 0), rotationDuration, Direction.Right));
            }
            else if (lastDirection == Direction.Left)
            {
                StartCoroutine(RotateObject(gameObject, new Vector3(180, 0, 0), rotationDuration, Direction.Right));
            } */

            StartCoroutine(RotatePlayer(Direction.Right, rotationDuration));
            lastDirection = Direction.Right;
        }



    }

    public void ChangeGravity(Direction direction)
    {

        if (lastDirection == direction)
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
    IEnumerator RotateObject(GameObject gameObjectToMove, Vector3 eulerAngles, float duration, Direction direction)
    {
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

    public void resetRotation()
    {
        //StartCoroutine(RotateObject(gameObject, Vector3.zero, rotationDuration, Direction.Down));
        transform.rotation = Quaternion.Euler(new Vector3(0, -90f, 0f));
        lastDirection = Direction.Down;
    }

    IEnumerator RotatePlayer(Direction direction, float duration){

        if (isRotating || lastDirection == direction){
            yield break;
        }

        yield return new WaitForSeconds(timeBeforeStartingRotation);

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation;
        Vector3 endRotationVector = -transform.rotation.eulerAngles;
        Debug.Log("start: " + startRotation + "| endvector: " + endRotationVector);
        switch (direction)
        {
            case Direction.Up:
                endRotation = Quaternion.Euler(new Vector3(0, -90f, -180f));
                //endRotationVector = new Vector3(0, 0, -180f);
                break;
            case Direction.Down:
                endRotation = Quaternion.Euler(new Vector3(0, -90f, 0));
                //endRotationVector = new Vector3(0, 0, 0);
                break;
            case Direction.Left:
                endRotation = Quaternion.Euler(new Vector3(-90f, -90f, 0));
                break;
            case Direction.Right:
                endRotation = Quaternion.Euler(new Vector3(90f, -90f, 0));
                break;
        }
        float t = 0.0f;
        while (t < duration){

            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);

            yield return null;
            Debug.Log("dentro");
        }

    }
}
