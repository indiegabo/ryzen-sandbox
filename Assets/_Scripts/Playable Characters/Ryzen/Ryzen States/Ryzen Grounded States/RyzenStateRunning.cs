
using System;
using System.Collections.Generic;
using UnityEngine;

public class RyzenStateRunning : RyzenStateGrounded
{
    Func<State> IdleState() => () => this._ryzen.idleState;
    Func<bool> InputZero() => () => this._ryzen.core.inputHandler.currentHorizontalMovement.x == 0f;
    public RyzenStateRunning(Ryzen ryzen) : base(ryzen)
    {
        // Register Default Transitions
        this.AddTransition(this.IdleState(), this.InputZero());
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
        this._ryzen.SetVelocityX(this._ryzen.core.inputHandler.currentHorizontalMovement.x * this._ryzen.core.data.horizontalMovementSpeed);
    }

    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Running, true);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Running, false);
    }
}
