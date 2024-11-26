using UnityEngine;

// Handles all of the Nodes
[CreateAssetMenu()]
public class BehaviorTree : ScriptableObject
{
    public Node RootNode { get; private set; }
    public Node.EState TreeState { get { return _treeState; } }

    private Node.EState _treeState = Node.EState.Running;

    public Node.EState Update()
    {
        if (RootNode.State == Node.EState.Running)
        {
            _treeState = RootNode.Update();
        }
        return TreeState;
    }

    public void SetRootNode(Node rootNode)
    {
        if (rootNode != null && RootNode == null)
        {
            RootNode = rootNode;
        }
    }

    public void ResetRootNode()
    {
        RootNode = null;
    }
}
