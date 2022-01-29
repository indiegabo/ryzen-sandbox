using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenState : State
{
    // Needed Components
    protected readonly StateMachine _stateMachine;
    protected readonly Ryzen _ryzen;

    public RyzenState(StateMachine stateMachine, Ryzen ryzen)
    {
        this._stateMachine = stateMachine;
        this._ryzen = ryzen;
    }


    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {

    }

    /// <summary>
    /// Ticked on every physics update
    /// </summary>
    public override void FixedTick()
    {

    }
    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
    }
}
