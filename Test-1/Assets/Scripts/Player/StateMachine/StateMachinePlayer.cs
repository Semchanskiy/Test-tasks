using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachinePlayer
{
    public State CurrentState;

    public void Initialize(State startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
            Debug.Log(CurrentState);
    }
}
