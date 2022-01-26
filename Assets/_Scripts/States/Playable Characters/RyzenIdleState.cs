
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RyzenIdleState : State
{
    // Needed Components
    private readonly StateMachine _stateMachine;
    private readonly Ryzen _ryzen;
    private readonly RyzenCore _core;

    public RyzenIdleState(StateMachine stateMachine, Ryzen ryzen, RyzenCore core)
    {
        this._stateMachine = stateMachine;
        this._ryzen = ryzen;
        this._core = core;
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
        this._core.anim.SetBool(RyzenState.Idle, true);
        this._ryzen.SetVelocityX(0f);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        this._core.anim.SetBool(RyzenState.Idle, false);
    }

}
