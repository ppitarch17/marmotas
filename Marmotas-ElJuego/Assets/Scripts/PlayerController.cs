using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GravityController gravityController;
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;

    public float Speed = 5f;

    [Header("Ground Check")]
    public bool _isGrounded = false;
    //public Transform _groundChecker;
    //public float GroundDistance = 0.2f;
    public Vector3 checkGroundBoxSize = Vector3.one / 2;
    public LayerMask GroundLayer;
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //_isGrounded = Physics.CheckSphere(transform.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        _isGrounded = Physics.CheckBox(transform.position, checkGroundBoxSize, Quaternion.identity, GroundLayer, QueryTriggerInteraction.Ignore);

        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");


        if(_inputs.magnitude < 0.1f){
            PlayerAnimatorController.ChangeAnimation(PlayerAnimatorController.AnimationName.Idle, 0f);    
        }
        if (_inputs != Vector3.zero && !gravityController.isRotating)
            transform.forward = _inputs;
           
    }

    void FixedUpdate()
    {
        if(_isGrounded  && !gravityController.isRotating){
            _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
            PlayerAnimatorController.ChangeAnimation(PlayerAnimatorController.AnimationName.Walk, 0f);            
        }

    }

    void OnDrawGizmosSelected(){
         //Gizmos.DrawSphere(transform.position, GroundDistance);
         Gizmos.DrawCube(transform.position, checkGroundBoxSize);
    }

}
