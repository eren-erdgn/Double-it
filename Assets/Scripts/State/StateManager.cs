using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState _currentState;

    BaseState _previousState;
    public ColumnChoosing ColumnChoosingState = new();
    public Moving MovingState = new();
    public Settle SettleState = new();
    public Merge MergeState = new();
    
    void Start()
    {
        _currentState = ColumnChoosingState;
        _currentState.EnterState(this);
    }

    void Update()
    {
        
        _currentState.UpdateState(this);
        
    }

    public void SwitchState(BaseState newState)
    {
        
        _previousState = _currentState;
        _currentState = newState;
        newState.EnterState(this);
    }
    
    public bool CheckPreviousState(BaseState state)
    {
        if(_previousState == state)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
