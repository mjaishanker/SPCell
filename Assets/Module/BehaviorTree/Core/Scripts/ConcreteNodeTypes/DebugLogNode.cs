using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogNode : ActionNode
{
    public string Message;

    protected override void OnStart()
    {
        Debug.Log("On Start: " + Message);
    }

    protected override void OnStop()
    {
        Debug.Log("On Stop: " + Message);
    }

    protected override EState OnUpdate()
    {
        Debug.Log("On Update: " + Message);
        return EState.Success;
    }
}
