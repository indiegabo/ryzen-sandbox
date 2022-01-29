
using System;
using System.Collections.Generic;
using UnityEngine;

public class RyzenRunningState : RyzenGroundedState
{
    public RyzenRunningState(StateMachine stateMachine, Ryzen ryzen) : base(stateMachine, ryzen)
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
        this._ryzen.SetVelocityX(this._ryzen.core.inputHandler.currentHorizontalMovement.x * this._ryzen.core.data.runningSpeed);
        this.EvaluateFlip();
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

    public void EvaluateFlip()
    {
        if (this._ryzen.core.rgbd.velocity.x > 0 && !this._ryzen.core.facingRight
        || this._ryzen.core.rgbd.velocity.x < 0 && this._ryzen.core.facingRight)
        {
            this._ryzen.core.facingRight = !this._ryzen.core.facingRight;
            this._ryzen.FlipPlayer();
        }
    }
}
