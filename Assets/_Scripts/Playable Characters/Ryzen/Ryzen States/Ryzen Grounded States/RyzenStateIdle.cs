
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RyzenStateIdle : RyzenStateGrounded
{
    Func<State> RunningState() => () => this._ryzen.runningState;
    Func<bool> InputNotZero() => () => this._ryzen.core.inputHandler.currentHorizontalMovement.x != 0f;

    public RyzenStateIdle(Ryzen ryzen) : base(ryzen)
    {
        // Register Transitions
        this.AddTransition(this.RunningState(), this.InputNotZero());
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
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Idle, true);
        this._ryzen.SetVelocityX(0f);

    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Idle, false);
    }

}
