using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenAscendingState : RyzenState
{

    public RyzenAscendingState(StateMachine stateMachine, Ryzen ryzen) : base(stateMachine, ryzen)
    {
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();
    }

    /// <summary>
    /// Ticked on every physics update
    /// </summary>
    public override void FixedTick()
    {
        base.FixedTick();
    }
    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        // start jump logic
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
    }
}
