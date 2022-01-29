using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenAscendingState : RyzenOnAirState
{

    private float _ascendingTimeCounter = 0;
    private bool _ascending = false;
    public RyzenAscendingState(StateMachine stateMachine, Ryzen ryzen) : base(stateMachine, ryzen)
    {
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();

        if (this._ryzen.core.inputHandler.attemptingToJump && this._ascending)
        {
            this._ryzen.SetVelocityY(this._ryzen.core.data.jumpForce);
            this._ascendingTimeCounter -= Time.deltaTime;
        }

        if (this._ascendingTimeCounter <= 0 || !this._ryzen.core.inputHandler.attemptingToJump)
        {
            this._ascending = false;
            this._stateMachine.SetActiveState(this._ryzen.descendingState);
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
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Ascending, true);
        this._ascending = true;
        this._ascendingTimeCounter = this._ryzen.core.data.ascendingLimit;
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Ascending, false);
        this._ascendingTimeCounter = 0;
        this._ascending = false;
        this._ryzen.core.inputHandler.attemptingToJump = false;

    }
}
