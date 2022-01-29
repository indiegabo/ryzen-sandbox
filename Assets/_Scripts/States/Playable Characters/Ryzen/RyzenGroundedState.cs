using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenGroundedState : RyzenState
{
    protected bool _allowedToJump = true;

    // Needed Components
    public RyzenGroundedState(StateMachine stateMachine, Ryzen ryzen) : base(stateMachine, ryzen)
    {
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();
        if (this._ryzen.core.inputHandler.jumpButtonPressed && this._allowedToJump)
        {
            this._stateMachine.SetActiveState(this._ryzen.ascendingState);
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
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
    }
}
