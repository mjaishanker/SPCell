using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallPlayer : MonoBehaviour
{
    [SerializeField]
    InputActionProperty _movementAction;
    [SerializeField]
    InputActionProperty _jumpAction;

    [SerializeField]
    private float _ballMaxSpeed = 10;
    [SerializeField]
    private float _ballAcceleration = 5;

    private Vector3 _ballFinalPosition;
    private float _ballCurrentSpeed;

    private Vector3 _ballForceDirection;

    private Transform _ballTransform;

    private enum EBallState
    {
        Idle,
        Moving,
        Jumping
    }

    private void Awake()
    {
        _ballTransform = this.transform;
    }

    private void OnEnable()
    {
        _movementAction.action.performed += (value) => { _ballForceDirection = value.ReadValue<Vector2>(); };
    }

    private void Update()
    {
        MoveBall();
    }

    private void FixedUpdate()
    { 
        _ballTransform.position = _ballFinalPosition;
    }

    private void MoveBall()
    {
        //Debug.Log("!!!!!!! MOVEMNT VALUE: " + contextCallback.ReadValue<Vector2>());

        //// Ball velocity is speed and direction
        //_ballCurrentSpeed = _ballMaxSpeed;
        //Vector3 ballVelocity = movementVector.magnitude * _ballCurrentSpeed;

        //// PositionFinal = PositionCurrent + Distance
        //// Distance = Velocity * Time
        // PositionFinal = PositionCurrent + Velocity * Time

        _ballFinalPosition += _ballForceDirection * _ballMaxSpeed * Time.deltaTime;

    }

    private void AdjustBallDirection(InputAction.CallbackContext callbackContext)
    {

    }

}
