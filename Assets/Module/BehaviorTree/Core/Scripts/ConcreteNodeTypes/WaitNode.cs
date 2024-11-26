using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : ActionNode
{
    public float Duration { get { return _duration; } }
    private float _duration = 1f;
    private float _startTime;

    protected override void OnStart()
    {
        _startTime = Time.time;
    }

    protected override void OnStop()
    {
    }

    protected override EState OnUpdate()
    {
        if(Time.time - _startTime > _duration)
        {
            Debug.Log("!!!!!! WAIT COMPLETE");
            return EState.Success;
        }
        return EState.Running;
    }

    public void SetWaitDuration(float waitDuration)
    {
        _duration = waitDuration;
    }

}
