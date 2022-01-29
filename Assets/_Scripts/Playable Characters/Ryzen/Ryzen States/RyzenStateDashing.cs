using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenStateDashing : RyzenState
{
    Func<State> RunningState() => () => this._ryzen.idleState;
    Func<bool> HasDashEnded() => () => this._currentDashTimeRemaining <= 0;
    private float _currentDashTimeRemaining = 0;

    public RyzenStateDashing(Ryzen ryzen) : base(ryzen)
    {
        this.AddTransition(this.RunningState(), this.HasDashEnded());
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
        this.PerformDash();
    }
    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Dashing, true);
        this._currentDashTimeRemaining = this._ryzen.core.data.dashDuration;
        Debug.Log("Entered Dash State");
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Dashing, false);
    }

    private void PerformDash()
    {
        this._currentDashTimeRemaining -= Time.deltaTime;
        if (this._ryzen.core.facingRight)
        {
            this._ryzen.SetVelocityX(this._ryzen.core.data.dashSpeed);
        }
        else
        {
            this._ryzen.SetVelocityX(-this._ryzen.core.data.dashSpeed);
        }
    }
}
