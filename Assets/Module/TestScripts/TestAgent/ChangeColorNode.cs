using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorNode : ActionNode
{
    Material _material;
    Color _originalColor;
    Color _newColor;
    Color _currentColor;

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
        _currentColor = _originalColor;
    }

    protected override EState OnUpdate()
    {
        if(_material == null)
        {
            return EState.Failure;
        }
            
        if(_currentColor == _newColor)
        {
            return EState.Success;
        }

        _currentColor = Color.Lerp(_material.color, _newColor, 0.7f *Time.deltaTime);
        return EState.Running;
    }

    public void SetColors(Material material, Color newColor)
    {
        _material = material;
        _originalColor = _material.color;
        _newColor = newColor;
    }
}
