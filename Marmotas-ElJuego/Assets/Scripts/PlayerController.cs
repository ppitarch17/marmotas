using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform transformRotation;
    private GravityController gravityController;
    private PlayerAnimatorController playerAnimatorController;
    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;

    public float Speed = 5f;
    [Header("Ground Check")]
    public bool _isGrounded;
    public bool _isWalking;
    public bool _isIdle;
    //public Transform _groundChecker;
    public float GroundDistance = 0.2f;
    public Vector3 checkGroundBoxSize = Vector3.one / 2;
    public LayerMask GroundLayer;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        gravityController = GetComponentInChildren<GravityController>();
        playerAnimatorController = GetComponentInChildren<PlayerAnimatorController>();

    }

    //TODO cambiar controles
    void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, GroundDistance, GroundLayer, QueryTriggerInteraction.Ignore);
        //_isGrounded = Physics.CheckBox(transform.position, checkGroundBoxSize, Quaternion.identity, GroundLayer, QueryTriggerInteraction.Ignore);

        _inputs = HandleInputDependingOnDirection();
        
        

        if (_inputs != Vector3.zero && !gravityController.isRotating)
        {

            //transform.forward = _inputs;

            transformRotation.localRotation = HandleRotationDependingOnDirection();

            if (_isGrounded)
            {
                /*  _isWalking = true;
                 _isIdle = false; */
                playerAnimatorController.ChangeAnimation(PlayerAnimatorController.AnimationName.Run, 0.1f, true);
            }

        }
        else if (_inputs == Vector3.zero)
        {
            if (_isGrounded)
            {
                /*                 _isWalking = false;
                                _isIdle = true; */
                playerAnimatorController.ChangeAnimation(PlayerAnimatorController.AnimationName.Idle, 0.1f, true);
            }

        }

    }

    void FixedUpdate()
    {
        //if(_isGrounded  && !gravityController.isRotating){
        //if(!gravityController.isRotating){
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
        //_body.rotation = 
        //}
    }


    private Vector3 HandleInputDependingOnDirection()
    {
        Vector3 _inputs = Vector3.zero;

        //En techo/piso
        if (gravityController.lastDirection == GravityController.Direction.Down || gravityController.lastDirection == GravityController.Direction.Up)
        {
            _inputs.x = Input.GetAxis("Horizontal");
            _inputs.z = Input.GetAxis("Vertical");
        }
        else
        {

            //En pared derecha
/*             _inputs.y = Input.GetAxis("Horizontal");
            _inputs.z = Input.GetAxis("Vertical"); */

            _inputs.y = Input.GetAxis("Vertical");
            _inputs.z = Input.GetAxis("Horizontal");

            //En pared izquierda
            if (gravityController.lastDirection == GravityController.Direction.Right)
                _inputs.z = -_inputs.z;

            Debug.Log("HandleInput : en paredes");
        }

        return _inputs;
    }

    private Quaternion HandleRotationDependingOnDirection()
    {
        Vector3 _rotation = new Vector3(_inputs.z, 0, -_inputs.x);

        switch (gravityController.lastDirection)
        {
            case GravityController.Direction.Up: _rotation.x = -_inputs.z; break;
            case GravityController.Direction.Right: _rotation.z = -_inputs.y; break;
            case GravityController.Direction.Left: _rotation.z = _inputs.y; break;
        }
        /*         if(gravityController.lastDirection == GravityController.Direction.Up){
                    _rotation.x = -_inputs.z;
                } else if(gravityController.lastDirection == GravityController.Direction.Right){
                    _rotation.z = -_inputs.y;
                } else if(gravityController.lastDirection == GravityController.Direction.Left){
                    _rotation.z = _inputs.y;
                } */

        return Quaternion.LookRotation(_rotation);
    }

    void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(transform.position, GroundDistance);
        Gizmos.DrawCube(transform.position, checkGroundBoxSize);
        Gizmos.color = Color.red;
    }

    public void resetRigidBodyVelocity(){
        //_body.velocity = Vector3.zero;

        // Dejo solo la velocidad en y para que el jugador no quede flotando si se resetea la velocidad en el aire
        // (AKA cuando hace spawn en un checkpoint)
        _body.velocity = new Vector3(0, _body.velocity.y, 0);
    }


}
