using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SequencerNode : CompositeNode
{
    private int _currentChild;
    protected override void OnStart()
    {
        _currentChild = 0;
    }

    protected override void OnStop()
    {
    }

    protected override EState OnUpdate()
    {
        Node child = ChildrenNodes[_currentChild];
        if (child != null) 
        {
            switch (child.Update())
            {
                case EState.Running:
                    return EState.Running;
                case EState.Success:
                    _currentChild++;
                    break;
                case EState.Failure:
                    return EState.Failure;
                default:
                    break;
            }

            return _currentChild < ChildrenNodes.Count ? EState.Running : EState.Success;
        }
        else
        {
            Debug.LogError("The child node of: " + ChildrenNodes.ToString() + " is null!");
            return EState.Failure;
        }
    }

    public void AddChildToChildrenNodes(Node childNode)
    {
        if(ChildrenNodes != null)
            ChildrenNodes.Add(childNode);
    }

}