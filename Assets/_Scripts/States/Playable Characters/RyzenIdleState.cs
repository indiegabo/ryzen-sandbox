
using UnityEngine;

public class RyzenIdleState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly Ryzen _ryzen;
    private readonly RyzenCore _core;

    public RyzenIdleState(StateMachine stateMachine, Ryzen ryzen, RyzenCore core)
    {
        this._stateMachine = stateMachine;
        this._ryzen = ryzen;
        this._core = core;
    }

    /// <summary>
    /// Ticked on every frame
    /// </summary>
    public void Tick()
    {

    }

    /// <summary>
    /// Ticked on every physics update
    /// </summary>
    public void FixedTick()
    {

    }
    /// <summary>
    /// Ticked when the state machine enter this state
    /// </summary>
    public void OnEnter()
    {
        this._core.anim.SetBool(RyzenState.Idle, true);
        this._ryzen.SetVelocityX(0f);
    }

    /// <summary>
    /// Ticked when the state machine exit this state
    /// </summary>
    public void OnExit()
    {
        this._core.anim.SetBool(RyzenState.Idle, false);
    }
}
