using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenStateHit : RyzenState
{

    public RyzenStateHit(Ryzen ryzen) : base(ryzen)
    {
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();
        if (this._ryzen.currentAnimationEnded)
            this._ryzen.ChangeState(this._ryzen.idleState);
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
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Hit, true);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Hit, false);
    }

    public void HandleHit()
    {

    }
}
