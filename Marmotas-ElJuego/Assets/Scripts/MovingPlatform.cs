using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main menu / final screen
// hub

public class MovingPlatform : MonoBehaviour
{
 //platform position A
        private Vector3 pointA;
        //platform position B
        public Transform destinationB;
        private Vector3 pointB;
        //platform speed
        public float speed = 5;
        //bool to determine if we should ping pong between a or b
        bool toggle = false;
        //cached lerp value
        float lerpValue = 0;

        public bool movingPlayer = false;

        private void Start(){
            pointA = gameObject.transform.position;
            pointB = destinationB.position;
        }

        void FixedUpdate()
        {
            if (toggle)
            {
                //if toggle = true
                //add time to the lerp value
                lerpValue += Time.fixedDeltaTime * speed;
                //if the lerp is greater or equal to 1 
                if (lerpValue >= 1f)
                {
                    //snap the lerp value to 1 in case it was over 1
                    lerpValue = 1f;
                    //toggle is now false
                    toggle = false;
                }
            }
            else
            {
                //if toggle = false
                //subtract time from lerp value
                lerpValue -= Time.fixedDeltaTime * speed;
                //if the lerp is less or equal to 0f
                if (lerpValue <= 0f)
                {
                    //snap lerp to 0 in case it was below 0
                    lerpValue = 0f;
                    //toggle is now true
                    toggle = true;
                }
            }

            //lerp the transform position between pointA and pointB based off the lerp value
            transform.position = Vector3.Lerp(pointA, pointB, lerpValue);
        }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            setParent(collision.gameObject, this.transform);
            movingPlayer = true;
        }
    }

    void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            setParent(collision.gameObject, null);
            movingPlayer = true;
        }
    }
    
    public void setParent(GameObject player, Transform parent){
        player.transform.parent = parent;
    }
}

