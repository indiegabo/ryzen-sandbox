using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenState : State
{
    // Needed Components
    protected readonly Ryzen _ryzen;

    public RyzenState(Ryzen ryzen)
    {
        this._ryzen = ryzen;
    }


    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {

    }

    /// <summary>
    /// Ticked on every physics update
    /// </summary>
    public override void FixedTick()
    {

    }
    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public override void OnEnter()
    {
        RyzenUnit.OnRyzenGotHit += this.TookHit;
        RyzenUnit.OnRyzenDied += this.Died;
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        RyzenUnit.OnRyzenGotHit -= this.TookHit;
        RyzenUnit.OnRyzenDied -= this.Died;
    }

    private void TookHit()
    {
        this._ryzen.ChangeState(this._ryzen.hitState);
    }

    private void Died()
    {
        this._ryzen.ChangeState(this._ryzen.deadState);
    }
}
