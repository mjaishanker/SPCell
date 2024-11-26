using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum EState
    {
        Running,
        Success,
        Failure
    }


    public EState State { get { return _state; } }
    public bool Started { get { return _started; } }

    private bool _started = false;
    private EState _state = EState.Running;

    public EState Update()
    {
        if (!Started)
        {
            OnStart();
            _started = true;
        }

        _state = OnUpdate();

        if (State == EState.Failure || State == EState.Success)
        {
            OnStop();
            _started = false;
        }

        return State;
    }

    // All the subtypes of nodes will implement these functions 
    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract EState OnUpdate();

}
