using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAgentBT : MonoBehaviour
{
    private BehaviorTree _testAgentBT;

    [SerializeField]
    public List<Transform> POITransforms;

    public enum AgentState
    {
        Idle,
        Moving,
        Scanning
    }

    private AgentState _agentState;

    private void Awake()
    {
        _testAgentBT = ScriptableObject.CreateInstance<BehaviorTree>();

        SequencerNode patrolSequence = ScriptableObject.CreateInstance<SequencerNode>();

        foreach(var v in POITransforms)
        {
            MoveNode moveNode = ScriptableObject.CreateInstance<MoveNode>();
            moveNode.MoveTransformToPoint(this.transform, v.position, 5f);

            WaitNode waitNode = ScriptableObject.CreateInstance<WaitNode>();
            waitNode.SetWaitDuration(2f);

            patrolSequence.AddChildToChildrenNodes(moveNode);
            patrolSequence.AddChildToChildrenNodes(waitNode);
        }
        //MoveNode moveNode = ScriptableObject.CreateInstance<MoveNode>();
        //moveNode.MoveTransformToPoint(this.transform, POITransforms[0].position, 5f);
        
        //WaitNode waitNode = ScriptableObject.CreateInstance<WaitNode>();
        //waitNode.SetWaitDuration(2f);

        //ChangeColorNode changeColorNode = ScriptableObject.CreateInstance<ChangeColorNode>();
        //Material material = transform.GetComponent<Renderer>().material;
        //changeColorNode.SetColors(material, Color.green);


        //patrolSequence.AddChildToChildrenNodes(moveNode);
        //patrolSequence.AddChildToChildrenNodes(waitNode);


        RepeatNode loop = ScriptableObject.CreateInstance<RepeatNode>();
        loop.ChildNode = patrolSequence;
        _testAgentBT.SetRootNode(loop);

    }

    private void Update()
    {
        _testAgentBT.Update();
    }


}
