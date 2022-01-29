using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenStateGrounded : RyzenState
{

    // Needed Components
    public RyzenStateGrounded(Ryzen ryzen) : base(ryzen)
    {
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
