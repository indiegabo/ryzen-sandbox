
using System;
using System.Collections.Generic;
using UnityEngine;

public class RyzenRunningState : State
{
    private readonly StateMachine _stateMachine;
    private readonly Ryzen _ryzen;
    private readonly RyzenCore _core;
    private List<StateTransition> _transitions = new List<StateTransition>();

    public RyzenRunningState(StateMachine stateMachine, Ryzen ryzen, RyzenCore core)
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
        // _playerEntity.SetVelocityX(_core.inputHandler.currentInput.x * 100f * Time.deltaTime);
        // _playerEntity.FlipPlayer(_core.inputHandler.currentInput.x == -1f ? true : false);
    }

    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        this._core.anim.SetBool(RyzenState.Running, true);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        this._core.anim.SetBool(RyzenState.Running, false);
    }
}
