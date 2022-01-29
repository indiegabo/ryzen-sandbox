using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyzenSpawnState : RyzenState
{
    public RyzenSpawnState(StateMachine stateMachine, Ryzen ryzen) : base(stateMachine, ryzen)
    {
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public override void Tick()
    {
        base.Tick();

        if (this._ryzen.core.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            this._stateMachine.SetActiveState(this._ryzen.idleState);
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
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Spawn, true);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        this._ryzen.core.anim.SetBool(RyzenStateEnum.Spawn, false);
    }

    private void EvaluateAnimationEnd()
    {
        if (this._ryzen.core.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            this._stateMachine.SetActiveState(this._ryzen.idleState);
        }
    }
}

