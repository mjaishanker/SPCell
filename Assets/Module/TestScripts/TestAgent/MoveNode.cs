using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNode : ActionNode
{
    Transform _currentTransform;
    Vector3 _targetPoint;
    float _moveSpeed;

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override EState OnUpdate()
    {
        if(_currentTransform == null)
            return EState.Failure;

        if (Vector3.Distance(_currentTransform.position, _targetPoint) < 0.1f)
        {
            return EState.Success;
        }
        else
        {
            //Debug.Log("!!!!!! MOVING: " + _currentTransform.name + " TARGET POSITION: " + _targetPoint);
            Vector3 dir = (_targetPoint - _currentTransform.position).normalized;
            _currentTransform.Translate(dir * _moveSpeed * Time.deltaTime);
            return EState.Running;
        }

    }

    public void MoveTransformToPoint(Transform transform, Vector3 movePoint, float moveSpeed)
    {
        if(transform != null)
        {
            _currentTransform = transform;
        }
        _targetPoint = movePoint;
        _moveSpeed = moveSpeed;
    }

}
