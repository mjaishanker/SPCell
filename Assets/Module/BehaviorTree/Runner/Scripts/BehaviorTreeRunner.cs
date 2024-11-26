using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeRunner : MonoBehaviour
{
    BehaviorTree _tree;

    private void Start()
    {
        _tree = ScriptableObject.CreateInstance<BehaviorTree>();

        DebugLogNode log1 =  ScriptableObject.CreateInstance<DebugLogNode>();
        log1.Message = "!!!!!! Hello 1";

        WaitNode pause1 = ScriptableObject.CreateInstance<WaitNode>();
        pause1.SetWaitDuration(1);

        DebugLogNode log2 = ScriptableObject.CreateInstance<DebugLogNode>();
        log2.Message = "!!!!!! Hello 2";

        WaitNode pause2 = ScriptableObject.CreateInstance<WaitNode>();
        pause2.SetWaitDuration(2);

        DebugLogNode log3 = ScriptableObject.CreateInstance<DebugLogNode>();
        log3.Message = "!!!!!! Hello 3";

        WaitNode pause3 = ScriptableObject.CreateInstance<WaitNode>();
        pause3.SetWaitDuration(3);

        SequencerNode sequencerNode = ScriptableObject.CreateInstance<SequencerNode>();
        sequencerNode.AddChildToChildrenNodes(log1);
        sequencerNode.AddChildToChildrenNodes(pause1);
        sequencerNode.AddChildToChildrenNodes(log2);
        sequencerNode.AddChildToChildrenNodes(pause2);
        sequencerNode.AddChildToChildrenNodes(log3);
        sequencerNode.AddChildToChildrenNodes(pause3);

        RepeatNode loop = ScriptableObject.CreateInstance<RepeatNode>();
        loop.ChildNode = sequencerNode;

        _tree.SetRootNode(loop);
    }

    private void Update()
    {
        _tree.Update();
    }
}
