using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenStateDescending : RyzenStateOnAir
{

    public RyzenStateDescending(Ryzen ryzen) : base(ryzen)
    {
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();

        if (Mathf.Abs(this._ryzen.core.rgbd.velocity.y) == 0 && this._ryzen.grounded)
        {
            this._ryzen.ChangeState(this._ryzen.idleState);
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
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Descending, true);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Descending, false);
    }
}
