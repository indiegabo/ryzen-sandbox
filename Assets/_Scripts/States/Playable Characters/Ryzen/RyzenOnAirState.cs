using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenOnAirState : RyzenState
{

    public RyzenOnAirState(StateMachine stateMachine, Ryzen ryzen) : base(stateMachine, ryzen)
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
        this._ryzen.SetVelocityX(this._ryzen.core.inputHandler.currentHorizontalMovement.x * this._ryzen.core.data.horizontalMovementSpeed);
    }

    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
    }


}
