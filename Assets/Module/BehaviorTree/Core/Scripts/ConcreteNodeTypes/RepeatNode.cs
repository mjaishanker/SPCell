using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : DecoratorNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override EState OnUpdate()
    {
        ChildNode.Update();
        return EState.Running;
    }
}
