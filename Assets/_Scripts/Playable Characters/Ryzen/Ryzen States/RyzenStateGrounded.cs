using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenStateGrounded : RyzenState
{
    protected bool _canShoot = false;
    Func<State> DescendingState() => () => this._ryzen.descendingState;
    Func<bool> IsDescending() => () => this._ryzen.core.rgbd.velocity.y < 0;

    public RyzenStateGrounded(Ryzen ryzen) : base(ryzen)
    {
        this.AddTransition(this.DescendingState(), this.IsDescending());
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();

        if (this._ryzen.core.inputHandler.attemptingToJump)
        {
            this._ryzen.ChangeState(this._ryzen.ascendingState);
        }

        if (this._ryzen.core.inputHandler.attemptingToAttack)
        {
            this._ryzen.ChangeState(this._ryzen.loadingShootState);
        }
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
        RyzenInputHandler.OnDashAttempt += DashAttempt;
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        RyzenInputHandler.OnDashAttempt -= DashAttempt;
    }

    public void DashAttempt()
    {
        // Only Dashes again after the given time between dashes
        if (this._ryzen.dashEnabled)
        {
            this._ryzen.JustDashed();
            this._ryzen.ChangeState(this._ryzen.dashingState);
        }
    }
}
